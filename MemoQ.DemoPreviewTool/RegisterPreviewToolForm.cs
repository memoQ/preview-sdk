using MemoQ.PreviewInterfaces;
using MemoQ.PreviewInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoQ.DemoPreviewTool
{
    internal partial class RegisterPreviewToolForm : Form
    {
        private readonly PreviewServiceProxy proxy;

        public RegisterPreviewToolForm(PreviewServiceProxy proxy)
        {
            InitializeComponent();

            this.proxy = proxy;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            RegistrationRequest request;
            if (tryGetRequest(out request))
            {
                var requestStatus = proxy.Register(request);
                if (requestStatus.RequestAccepted)
                {
                    Log.Instance.WriteMessage("[MessageFromPreviewTool] - Register method has been called and the request was accepted.");
                    Close();
                }
                else
                    MessageBox.Show(this, $"Error code: {requestStatus.ErrorCode}\r\nError message: {requestStatus.ErrorMessage}", "Request rejected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool tryGetRequest(out RegistrationRequest request)
        {
            request = null;

            Guid previewToolId;
            if (!Guid.TryParse(tbPreviewToolId.Text, out previewToolId))
            {
                MessageBox.Show(this, "The preview tool id is missing or it is not a valid GUID.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbPreviewToolName.Text))
            {
                MessageBox.Show(this, "The name of the preview tool cannot be empty.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbPreviewPartIdRegex.Text))
            {
                MessageBox.Show(this, "The preview part id regex cannot be empty.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    var regex = new Regex(tbPreviewPartIdRegex.Text);
                }
                catch
                {
                    MessageBox.Show(this, "The preview part id regex is invalid.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            request = new RegistrationRequest(
                previewToolId,
                tbPreviewToolName.Text,
                tbPreviewToolDescription.Text,
                tbAutoStartupCommand.Text,
                tbPreviewPartIdRegex.Text,
                cbRequiresWebPreviewBaseUrl.Checked,
                rbContentComplexityMinimal.Checked ? ContentComplexityLevel.Minimal : ContentComplexityLevel.PlainWithInterpretedFormatting,
                tbRequiredProperties.Lines);
            return true;
        }
    }
}
