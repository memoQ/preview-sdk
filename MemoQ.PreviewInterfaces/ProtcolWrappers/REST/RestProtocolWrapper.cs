using MemoQ.PreviewInterfaces.Entities;
using MemoQ.PreviewInterfaces.Exceptions;
using MemoQ.PreviewInterfaces.Interfaces;
using MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Callback;
using MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST
{
    internal class RestProtocolWrapper : ProtocolWrapperBase
    {
        public static readonly string MessageCorrelationIdHttpHeaderName = "MESSAGE-CORRELATION-ID";
        public static readonly string NumberOfMessagePartsHttpHeaderName = "NUMBER-OF-MESSAGE-PARTS";
        public static readonly string LastMessageHttpHeaderName = "LAST-MESSAGE";
        public static readonly int MaxRequestSize = 8 * 1024 * 1024;

        private readonly JsonSerializerSettings serializerSettings;
        private CallbackService callbackService;
        private string connectionKey;

        public RestProtocolWrapper(string baseAddress, CallbackHandler callbackHandler)
            : base(baseAddress, callbackHandler)
        {
            serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(new StringEnumConverter());

            Communication.Model.NegotiationResponse response;
            ErrorCodes? errorCode;
            string errorMessage;

            var request = new Communication.Model.NegotiationRequest() { KnownProtocolVersions = new string[] { Communication.Model.ProtocolVersions.V1 } };
            var result = sendRequest($"{BaseAddress}/{Process.GetCurrentProcess().SessionId}", HttpMethod.Post, JsonConvert.SerializeObject(request, request.GetType(), serializerSettings), out response, out errorCode, out errorMessage);

            if (result != HttpStatusCode.OK)
                throw new NegotiationFailedException();
            else
                connectionKey = response.ConnectionKey;
        }

        public override RequestStatus Register(RegistrationRequest registrationRequest)
        {
            var request = registrationRequest.Convert();
            return sendRequest(null, HttpMethod.Post, null, JsonConvert.SerializeObject(request, request.GetType(), serializerSettings));
        }

        public override RequestStatus Connect(Guid previewToolId)
        {
            return sendRequest(null, HttpMethod.Get, previewToolId, null);
        }

        public override RequestStatus RequestRuntimeSettingsChange(Guid previewToolId, ChangeRuntimeSettingsRequest changeRuntimeSettingsRequest)
        {
            var request = changeRuntimeSettingsRequest.Convert();
            return sendRequest(null, new HttpMethod("PATCH"), previewToolId, JsonConvert.SerializeObject(request, request.GetType(), serializerSettings));
        }

        public override RequestStatus RequestContentUpdate(Guid previewToolId, ContentUpdateRequestFromPreviewTool contentUpdateRequest)
        {
            string[] parameters;
            if (tryGetRequestParameters(items => new Communication.Model.ContentUpdateRequestFromPreviewTool() { PreviewPartIds = items, TargetLangCodes = contentUpdateRequest.TargetLangCodes }, contentUpdateRequest.PreviewPartIds, out parameters))
            {
                var correlationId = Guid.NewGuid();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var requestStatus = sendRequest("content", HttpMethod.Post, previewToolId, parameters[i]);
                    if (!requestStatus.RequestAccepted)
                        return requestStatus;
                }

                return RequestStatus.Success();
            }
            else
                return RequestStatus.Failed(ErrorCodes.UnexpectedError, "Unable to get the REST request parameters.");
        }

        public override RequestStatus RequestHighlightChange(Guid previewToolId, ChangeHighlightRequestFromPreviewTool changeHighlightRequest)
        {
            var request = changeHighlightRequest.Convert();
            return sendRequest("highlight", HttpMethod.Post, previewToolId, JsonConvert.SerializeObject(request, request.GetType(), serializerSettings));
        }

        public override RequestStatus RequestPreviewPartIdUpdate(Guid previewToolId)
        {
            return sendRequest("previewpartids", HttpMethod.Post, previewToolId, null);
        }

        public override RequestStatus Disconnect(Guid previewToolId)
        {
            var requestStatus = sendRequest(null, HttpMethod.Delete, previewToolId, null);

            if (requestStatus.RequestAccepted)
            {
                callbackService.Stop();
                connectionKey = null;
            }

            return requestStatus;
        }

        private bool tryGetRequestParameters<T>(Func<T[], object> createMessage, T[] items, out string[] parameters)
        {
            var message = createMessage(items);
            var json = JsonConvert.SerializeObject(message, message.GetType(), serializerSettings);

            parameters = null;

            if (json.Length < MaxRequestSize)
            {
                parameters = new string[] { json };
                return true;
            }
            else if (items.Length > 1)
            {
                var index = items.Length / 2;

                string[] firstPartParameters;
                string[] secondPartParameters;
                if (tryGetRequestParameters(createMessage, items.Take(index).ToArray(), out firstPartParameters) &&
                    tryGetRequestParameters(createMessage, items.Skip(index).ToArray(), out secondPartParameters))
                {
                    parameters = firstPartParameters.Concat(secondPartParameters).ToArray();
                    return true;
                }
            }

            return false;
        }

        private RequestStatus sendRequest(string relativeUrl, HttpMethod httpMethod, Guid? previewToolId, string parameters)
        {
            Communication.Model.ConnectionResponse response;
            ErrorCodes? errorCode;
            string errorMessage;

            var result = sendRequest(relativeUrl, httpMethod, previewToolId, parameters, out response, out errorCode, out errorMessage);

            if (result == HttpStatusCode.OK)
            {
                if (response != null)
                {
                    callbackService = new CallbackService(response.CallbackAddress, CallbackHandler, response.PingIntervalInSecs, onConnectionClosed);
                    callbackService.Start();
                }

                return RequestStatus.Success();
            }
            else
                return RequestStatus.Failed(errorCode.Value, errorMessage);
        }

        private HttpStatusCode sendRequest<T>(string relativeUrl, HttpMethod httpMethod, Guid? previewToolId, string parameters, out T response, out Entities.ErrorCodes? errorCode, out string errorMessage)
        {
            var url = $"{BaseAddress}/{Process.GetCurrentProcess().SessionId}/previewtools{(previewToolId.HasValue ? "/" + previewToolId.Value.ToString() : "")}{(!string.IsNullOrEmpty(relativeUrl) ? "/" + relativeUrl : "")}";
            return sendRequest(url, httpMethod, parameters, out response, out errorCode, out errorMessage);
        }

        private HttpStatusCode sendRequest<T>(string url, HttpMethod httpMethod, string parameters, out T response, out Entities.ErrorCodes? errorCode, out string errorMessage)
        {
            var webRequest = WebRequest.Create(url);

            webRequest.Method = httpMethod.Method;
            if (!string.IsNullOrEmpty(connectionKey))
                webRequest.Headers.Add("Authorization", "PREVIEW-TOOL-CONNECTION-KEY " + connectionKey);
            webRequest.ContentType = "application/json";

            HttpWebResponse webResponse;
            try
            {
                if (parameters != null)
                {
                    using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        streamWriter.Write(parameters);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
                else
                    webRequest.ContentLength = 0;


                webResponse = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException we) // Some statuscodes actually raise exceptions...
            {
                webResponse = we.Response as HttpWebResponse;
                if (webResponse == null)
                    throw new PreviewServiceUnavailableException();
            }

            string responseContent;
            using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                responseContent = streamReader.ReadToEnd();

            try
            {
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    response = JsonConvert.DeserializeObject<T>(responseContent);
                    errorCode = null;
                    errorMessage = null;
                }
                else
                {
                    response = default(T);
                    var errorDetails = JsonConvert.DeserializeObject<Communication.Model.ErrorDetails>(responseContent);
                    switch (errorDetails.ErrorCode)
                    {
                        case Communication.Model.ErrorCodes.InvalidRequestParameters:
                            errorCode = ErrorCodes.InvalidRequestParameters;
                            break;
                        case Communication.Model.ErrorCodes.RegistrationRequestRefused:
                            errorCode = ErrorCodes.RegistrationRequestRefused;
                            break;
                        case Communication.Model.ErrorCodes.NoEnabledPreviewToolWithThisId:
                            errorCode = ErrorCodes.NoEnabledPreviewToolWithThisId;
                            break;
                        case Communication.Model.ErrorCodes.PreviewToolAlreadyConnectedWithThisId:
                            errorCode = ErrorCodes.PreviewToolAlreadyConnectedWithThisId;
                            break;
                        case Communication.Model.ErrorCodes.InternalServerError:
                            errorCode = ErrorCodes.UnexpectedError;
                            break;
                        default:
                            throw new Exception($"Unexpected error code: {errorDetails.ErrorCode}");
                    }
                    errorMessage = errorDetails.ErrorMessage;
                }
            }
            catch (Exception e)
            {
                response = default(T);
                errorCode = ErrorCodes.UnexpectedError;
                errorMessage = e.ToString();
            }

            return webResponse.StatusCode;
        }

        private void onConnectionClosed()
        {
            callbackService.Stop();
            connectionKey = null;

            OnConnectionClosed();
        }
    }
}
