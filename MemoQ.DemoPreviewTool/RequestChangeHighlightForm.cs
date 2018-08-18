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
    internal partial class RequestChangeHighlightForm : Form
    {
        private readonly PreviewServiceProxy proxy;

        public RequestChangeHighlightForm(PreviewServiceProxy proxy)
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

        private void cbSendSourceContent_CheckedChanged(object sender, EventArgs e)
        {
            tbSourceContent.Enabled = cbSendSourceContent.Checked;
        }

        private void cbSendTargetContent_CheckedChanged(object sender, EventArgs e)
        {
            tbTargetContent.Enabled = cbSendTargetContent.Checked;
        }

        private void cbSendSourceFocusedRange_CheckedChanged(object sender, EventArgs e)
        {
            nudSourceFocusedRangeStart.Enabled = nudSourceFocusedRangeLength.Enabled = cbSendSourceFocusedRange.Checked;
        }

        private void cbSendTargetFocusedRange_CheckedChanged(object sender, EventArgs e)
        {
            nudTargetFocusedRangeStart.Enabled = nudTargetFocusedRangeLength.Enabled = cbSendTargetFocusedRange.Checked;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Guid previewToolId;
            ChangeHighlightRequestFromPreviewTool request;
            if (tryGetRequest(out previewToolId, out request))
            {
                var requestStatus = tbPreviewToolId.Enabled ? proxy.ConnectAndRequestHighlightChange(previewToolId, request) : proxy.RequestHighlightChange(request);
                if (requestStatus.RequestAccepted)
                {
                    Log.Instance.WriteMessage("[MessageFromPreviewTool] - RequestHighlightChange method has been called and the request was accepted.");
                    Close();
                }
                else
                    MessageBox.Show(this, $"Error code: {requestStatus.ErrorCode}\r\nError message: {requestStatus.ErrorMessage}", "Request rejected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool tryGetRequest(out Guid previewToolId, out ChangeHighlightRequestFromPreviewTool request)
        {
            request = null;

            if (!Guid.TryParse(tbPreviewToolId.Text, out previewToolId))
            {
                MessageBox.Show(this, "The preview tool id is missing or it is not a valid GUID.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbPreviewPartId.Text))
            {
                MessageBox.Show(this, "The preview part id cannot be empty.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbSendSourceFocusedRange.Checked)
            {
                if (nudSourceFocusedRangeStart.Value < 0 || nudSourceFocusedRangeLength.Value < 0 || !cbSendSourceContent.Checked ||
                    nudSourceFocusedRangeStart.Value + nudSourceFocusedRangeLength.Value > tbSourceContent.Text.Length)
                {
                    MessageBox.Show(this, "The source focused range is not valid.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (cbSendTargetFocusedRange.Checked)
            {
                if (nudTargetFocusedRangeStart.Value < 0 || nudTargetFocusedRangeLength.Value < 0 || !cbSendTargetContent.Checked ||
                    nudTargetFocusedRangeStart.Value + nudTargetFocusedRangeLength.Value > tbTargetContent.Text.Length)
                {
                    MessageBox.Show(this, "The target focused range is not valid.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            request = new ChangeHighlightRequestFromPreviewTool(
                tbPreviewPartId.Text,
                string.IsNullOrWhiteSpace(tbSourceLangCode.Text) ? null : tbSourceLangCode.Text,
                string.IsNullOrWhiteSpace(tbTargetLangCode.Text) ? null : tbTargetLangCode.Text,
                cbSendSourceContent.Checked ? tbSourceContent.Text : null,
                cbSendTargetContent.Checked ? tbTargetContent.Text : null,
                cbSendSourceFocusedRange.Checked ? new FocusedRange((int)nudSourceFocusedRangeStart.Value, (int)nudSourceFocusedRangeLength.Value) : null,
                cbSendTargetFocusedRange.Checked ? new FocusedRange((int)nudTargetFocusedRangeStart.Value, (int)nudTargetFocusedRangeLength.Value) : null);
            return true;
        }
    }
}
