using MemoQ.PreviewInterfaces.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoQ.DemoPreviewTool
{
    public class Log
    {
        private readonly TextBox targetTextBox;
        private readonly JsonSerializerSettings jsonSerializerSettings;

        private Log(TextBox targetTextBox)
        {
            this.targetTextBox = targetTextBox;

            jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new StringEnumConverter());
        }

        private static Log instance;

        public static void Init(TextBox targetTextBox)
        {
            instance = new Log(targetTextBox);
        }

        public static Log Instance
        {
            get
            {
                if (instance == null)
                    throw new Exception("Log is not initialized yet.");

                return instance;
            }
        }

        public void WriteMessage(string message)
        {
            if (targetTextBox.InvokeRequired)
                targetTextBox.Invoke(new Action(() => WriteMessage(message)));
            else
                targetTextBox.AppendText(message + Environment.NewLine);
        }
    }
}
