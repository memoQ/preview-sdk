using MemoQ.PreviewInterfaces;
using MemoQ.PreviewInterfaces.Entities;
using MemoQ.PreviewInterfaces.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoQ.DemoPreviewTool
{
    public partial class ClientForm : Form
    {
        private Form openedForm;
        private PreviewServiceProxy proxy;

        public ClientForm()
        {
            InitializeComponent();

            Log.Init(tbLog);
        }

        private void tbEndpointAddress_TextChanged(object sender, EventArgs e)
        {
            btnCreateProxy.Enabled = !string.IsNullOrEmpty(tbEndpointAddress.Text);
        }

        private void btnCreateProxy_Click(object sender, EventArgs e)
        {
            try
            {
                proxy = new PreviewServiceProxy(new CallbackHandler(onPreviewToolDisconnected), tbEndpointAddress.Text);
            }
            catch (NegotiationFailedException)
            {
                MessageBox.Show(this, "The protocol version negotiation has failed, memoQ does not support any of the known protocols.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (PreviewServiceUnavailableException)
            {
                MessageBox.Show(this, "The preview service is not available.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gbProxy.Enabled = false;
            tlpButtons.Enabled = true;
            updateButtonStates();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (proxy != null && proxy.ConnectedPreviewToolId != Guid.Empty)
            {
                proxy.Disconnect();
                proxy.Dispose();
            }
        }

        private void btnRegisterPreviewTool_Click(object sender, EventArgs e)
        {
            using (var registerPreviewToolFrom = new RegisterPreviewToolForm(proxy))
                showDialog(registerPreviewToolFrom);
        }

        private void btnConnectPreviewTool_Click(object sender, EventArgs e)
        {
            using (var connectPreviewToolFrom = new ConnectPreviewToolForm(proxy))
                showDialog(connectPreviewToolFrom);
        }

        private void btnRequestChangeRuntimeSettings_Click(object sender, EventArgs e)
        {
            using (var requestChangeRuntimeSettingsForm = new RequestChangeRuntimeSettingsForm(proxy))
                showDialog(requestChangeRuntimeSettingsForm);
        }

        private void btnRequestContentUpdate_Click(object sender, EventArgs e)
        {
            using (var requestContentUpdateForm = new RequestContentUpdateForm(proxy))
                showDialog(requestContentUpdateForm);
        }

        private void btnRequestChangeHighlight_Click(object sender, EventArgs e)
        {
            using (var requestChangeHighlightForm = new RequestChangeHighlightForm(proxy))
                showDialog(requestChangeHighlightForm);
        }

        private void btnRequestPreviewPartUpdate_Click(object sender, EventArgs e)
        {
            using (var requestPreviewPartIdsForm = new RequestPreviewPartIdUpdateForm(proxy))
                showDialog(requestPreviewPartIdsForm);
        }

        private void btnDisconnectPreviewTool_Click(object sender, EventArgs e)
        {
            var requestStatus = proxy.Disconnect();

            if (requestStatus.RequestAccepted)
            {
                Log.Instance.WriteMessage("[MessageFromPreviewTool] - Disconnect method has been called and the request was accepted.");
                gbProxy.Enabled = true;
                tlpButtons.Enabled = false;
            }
            else
                MessageBox.Show(this, requestStatus.ErrorMessage, "Request rejected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            tbLog.Clear();
        }

        private void showDialog(Form dialog)
        {
            try
            {
                openedForm = dialog;
                dialog.ShowDialog();
                openedForm = null;
                updateButtonStates();
            }
            catch (PreviewServiceUnavailableException)
            {
                MessageBox.Show(this, "The preview service is not available.", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, $"Unexpected error has occurred:\r\n{e.ToString()}", "Demo preview tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateButtonStates()
        {
            if (proxy.ConnectedPreviewToolId != Guid.Empty)
            {
                btnRegisterPreviewTool.Enabled = false;
                btnConnectPreviewTool.Enabled = false;
                btnDisconnectPreviewTool.Enabled = true;
            }
            else
            {
                btnRegisterPreviewTool.Enabled = true;
                btnConnectPreviewTool.Enabled = true;
                btnDisconnectPreviewTool.Enabled = false;
            }
        }

        private void onPreviewToolDisconnected()
        {
            if (InvokeRequired)
                Invoke(new Action(() => onPreviewToolDisconnected()));
            else
            {
                if (openedForm != null)
                {
                    openedForm.Close();
                    openedForm = null;
                }

                MessageBox.Show(this, "The connection has been closed by the remote end.", "Connection closed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                updateButtonStates();
            }
        }
    }
}
