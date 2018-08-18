using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    public static class ErrorCodes
    {
        public const string RegistrationRequestRefused = "registration-request-refused";
        public const string NoEnabledPreviewToolWithThisId = "no-enabled-preview-tool-with-this-id";
        public const string PreviewToolAlreadyConnectedWithThisId = "preview-tool-already-connected-with-this-id";
    }
}
