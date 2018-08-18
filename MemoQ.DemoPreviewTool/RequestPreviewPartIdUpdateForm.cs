using MemoQ.PreviewInterfaces;
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
    internal partial class RequestPreviewPartIdUpdateForm : Form
    {
        private readonly PreviewServiceProxy proxy;

        public RequestPreviewPartIdUpdateForm(PreviewServiceProxy proxy)
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
            if (tryGetPreviewToolId(out previewToolId))
            {
                var requestStatus = tbPreviewToolId.Enabled ? proxy.ConnectAndRequestPreviewPartIdUpdate(previewToolId) : proxy.RequestPreviewPartIdUpdate();
                if (requestStatus.RequestAccepted)
                {
                    Log.Instance.WriteMessage("[MessageFromPreviewTool] - RequestPreviewPartIdUpdate method has been called and the request was accepted.");
                    Close();
                }
                else
                    MessageBox.Show(this, $"Error code: {requestStatus.ErrorCode}\r\nError message: {requestStatus.ErrorMessage}", "Request rejected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool tryGetPreviewToolId(out Guid previewToolId)
        {
            if (!Guid.TryParse(tbPreviewToolId.Text, out previewToolId))
            {
                MessageBox.Show(this, "The preview tool id is missing or it is not a valid GUID.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
