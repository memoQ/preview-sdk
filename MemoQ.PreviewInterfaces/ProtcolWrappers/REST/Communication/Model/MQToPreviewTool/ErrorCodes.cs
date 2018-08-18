using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public static class ErrorCodes
    {
        public const string InvalidRequestParameters = "InvalidRequestParameters";
        public const string RegistrationRequestRefused = "RegistrationRequestRefused";
        public const string NoEnabledPreviewToolWithThisId = "NoEnabledPreviewToolWithThisId";
        public const string PreviewToolAlreadyConnectedWithThisId = "PreviewToolAlreadyConnectedWithThisId";
        public const string InternalServerError = "InternalServerError";
    }
}
