﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.Entities
{
    public enum ErrorCodes
    {
        InvalidRequestParameters,
        RegistrationRequestRefused,
        NoEnabledPreviewToolWithThisId,
        PreviewToolAlreadyConnectedWithThisId,
        UnexpectedError
    }
}
