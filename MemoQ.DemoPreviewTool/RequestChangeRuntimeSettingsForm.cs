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
    internal partial class RequestChangeRuntimeSettingsForm : Form
    {
        private readonly PreviewServiceProxy proxy;

        public RequestChangeRuntimeSettingsForm(PreviewServiceProxy proxy)
        {
            InitializeComponent();

            this.proxy = proxy;

            updateControls();
        }

        private void updateControls()
        {
            if (proxy.ConnectedPreviewToolId != Guid.Empty)
            {
                tbPreviewToolId.Text = proxy.ConnectedPreviewToolId.ToString();
                tbPreviewToolId.Enabled = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Guid previewToolId;
            ChangeRuntimeSettingsRequest request;
            if (tryGetRequest(out previewToolId, out request))
            {
                var requestStatus = tbPreviewToolId.Enabled ? proxy.ConnectAndRequestRuntimeSettingsChange(previewToolId, request) : proxy.RequestRuntimeSettingsChange(request);
                if (requestStatus.RequestAccepted)
                {
                    Log.Instance.WriteMessage("[MessageFromPreviewTool] - RequestRuntimeSettingsChange method has been called and the request was accepted.");
                    Close();
                }
                else
                    MessageBox.Show(this, $"Error code: {requestStatus.ErrorCode}\r\nError message: {requestStatus.ErrorMessage}", "Request rejected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool tryGetRequest(out Guid previewToolId, out ChangeRuntimeSettingsRequest request)
        {
            request = null;

            if (!Guid.TryParse(tbPreviewToolId.Text, out previewToolId))
            {
                MessageBox.Show(this, "The preview tool id is missing or it is not a valid GUID.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            request = new ChangeRuntimeSettingsRequest(rbContentComplexityMinimal.Checked ? ContentComplexityLevel.Minimal : ContentComplexityLevel.PlainWithInterpretedFormatting, tbRequiredProperties.Lines);
            return true;
        }
    }
}
