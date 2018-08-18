using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    public class PipeCommand
    {
        public string CommandType;
        public object CommandParameters;

        public PipeCommand()
        { }

        public PipeCommand(string commandType, object commandParameters)
        {
            CommandType = commandType;
            CommandParameters = commandParameters;
        }
    }
}
