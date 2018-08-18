using MemoQ.PreviewInterfaces;
using MemoQ.PreviewInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoQ.DemoPreviewTool
{
    internal partial class RequestContentUpdateForm : Form
    {
        private readonly PreviewServiceProxy proxy;

        public RequestContentUpdateForm(PreviewServiceProxy proxy)
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
            ContentUpdateRequestFromPreviewTool request;
            if (tryGetRequest(out previewToolId, out request))
            {
                var requestStatus = tbPreviewToolId.Enabled ? proxy.ConnectAndRequestContentUpdate(previewToolId, request) : proxy.RequestContentUpdate(request);
                if (requestStatus.RequestAccepted)
                {
                    Log.Instance.WriteMessage("[MessageFromPreviewTool] - RequestContentUpdate method has been called and the request was accepted.");
                    Close();
                }
                else
                    MessageBox.Show(this, $"Error code: {requestStatus.ErrorCode}\r\nError message: {requestStatus.ErrorMessage}", "Request rejected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool tryGetRequest(out Guid previewToolId, out ContentUpdateRequestFromPreviewTool request)
        {
            request = null;

            if (!Guid.TryParse(tbPreviewToolId.Text, out previewToolId))
            {
                MessageBox.Show(this, "The preview tool id is missing or it is not a valid GUID.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbPreviewPartIds.Text))
            {
                MessageBox.Show(this, "At least one preview part id has to be specified.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var previewPartIds = tbPreviewPartIds.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();
            var targetLangCodes = tbTargetLangCodes.Lines.Where(l => !string.IsNullOrEmpty(l)).ToArray();

            request = new ContentUpdateRequestFromPreviewTool(previewPartIds, targetLangCodes.Length == 0 ? null : targetLangCodes);
            return true;
        }
    }
}
