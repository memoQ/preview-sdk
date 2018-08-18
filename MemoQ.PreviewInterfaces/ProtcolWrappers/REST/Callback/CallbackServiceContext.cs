using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Callback
{
    internal class CallbackServiceContext : IDisposable
    {
        private static readonly object sync = new object();
        private static readonly string requestIdPropertyKey = "RequestId";
        private static readonly Dictionary<Guid, ICallbackHandler> callbackHanders = new Dictionary<Guid, ICallbackHandler>();

        private readonly Guid requestId;

        public CallbackServiceContext(HttpRequestMessage request, ICallbackHandler callbackHandler)
        {
            lock (sync)
            {
                requestId = Guid.NewGuid();

                request.Properties.Add(requestIdPropertyKey, requestId);
                callbackHanders.Add(requestId, callbackHandler);
            }
        }

        public static ICallbackHandler GetCallbackHandler(HttpRequestMessage request)
        {
            lock (sync)
            {
                return callbackHanders[(Guid)request.Properties[requestIdPropertyKey]];
            }
        }

        public void Dispose()
        {
            lock (sync)
            {
                callbackHanders.Remove(requestId);
            }
        }
    }
}
