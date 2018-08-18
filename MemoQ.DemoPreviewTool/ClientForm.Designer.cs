namespace MemoQ.DemoPreviewTool
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btnCreateProxy = new System.Windows.Forms.Button();
            this.btnRequestContentUpdate = new System.Windows.Forms.Button();
            this.btnRequestChangeHighlight = new System.Windows.Forms.Button();
            this.btnRegisterPreviewTool = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lblEndpointAddress = new System.Windows.Forms.Label();
            this.tbEndpointAddress = new System.Windows.Forms.TextBox();
            this.btnConnectPreviewTool = new System.Windows.Forms.Button();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnDisconnectPreviewTool = new System.Windows.Forms.Button();
            this.btnRequestPreviewPartIdUpdate = new System.Windows.Forms.Button();
            this.btnRequestChangeRuntimeSettings = new System.Windows.Forms.Button();
            this.gbProxy = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons.SuspendLayout();
            this.gbProxy.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLog
            // 
            this.tableLayoutPanel.SetColumnSpan(this.tbLog, 2);
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(3, 98);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(978, 395);
            this.tbLog.TabIndex = 2;
            // 
            // btnCreateProxy
            // 
            this.btnCreateProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateProxy.Location = new System.Drawing.Point(590, 19);
            this.btnCreateProxy.Name = "btnCreateProxy";
            this.btnCreateProxy.Size = new System.Drawing.Size(86, 23);
            this.btnCreateProxy.TabIndex = 5;
            this.btnCreateProxy.Text = "Create proxy";
            this.btnCreateProxy.UseVisualStyleBackColor = true;
            this.btnCreateProxy.Click += new System.EventHandler(this.btnCreateProxy_Click);
            // 
            // btnRequestContentUpdate
            // 
            this.btnRequestContentUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRequestContentUpdate.Location = new System.Drawing.Point(414, 3);
            this.btnRequestContentUpdate.Name = "btnRequestContentUpdate";
            this.btnRequestContentUpdate.Size = new System.Drawing.Size(136, 34);
            this.btnRequestContentUpdate.TabIndex = 3;
            this.btnRequestContentUpdate.Text = "Request content update";
            this.btnRequestContentUpdate.UseVisualStyleBackColor = true;
            this.btnRequestContentUpdate.Click += new System.EventHandler(this.btnRequestContentUpdate_Click);
            // 
            // btnRequestChangeHighlight
            // 
            this.btnRequestChangeHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRequestChangeHighlight.Location = new System.Drawing.Point(556, 3);
            this.btnRequestChangeHighlight.Name = "btnRequestChangeHighlight";
            this.btnRequestChangeHighlight.Size = new System.Drawing.Size(136, 34);
            this.btnRequestChangeHighlight.TabIndex = 4;
            this.btnRequestChangeHighlight.Text = "Request change highlight";
            this.btnRequestChangeHighlight.UseVisualStyleBackColor = true;
            this.btnRequestChangeHighlight.Click += new System.EventHandler(this.btnRequestChangeHighlight_Click);
            // 
            // btnRegisterPreviewTool
            // 
            this.btnRegisterPreviewTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegisterPreviewTool.Location = new System.Drawing.Point(3, 3);
            this.btnRegisterPreviewTool.Name = "btnRegisterPreviewTool";
            this.btnRegisterPreviewTool.Size = new System.Drawing.Size(131, 34);
            this.btnRegisterPreviewTool.TabIndex = 0;
            this.btnRegisterPreviewTool.Text = "Register preview tool";
            this.btnRegisterPreviewTool.UseVisualStyleBackColor = true;
            this.btnRegisterPreviewTool.Click += new System.EventHandler(this.btnRegisterPreviewTool_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(906, 499);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 3;
            this.btnClearLog.Text = "Clear log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // lblEndpointAddress
            // 
            this.lblEndpointAddress.AutoSize = true;
            this.lblEndpointAddress.Location = new System.Drawing.Point(12, 24);
            this.lblEndpointAddress.Name = "lblEndpointAddress";
            this.lblEndpointAddress.Size = new System.Drawing.Size(89, 13);
            this.lblEndpointAddress.TabIndex = 0;
            this.lblEndpointAddress.Text = "Endpoint address";
            // 
            // tbEndpointAddress
            // 
            this.tbEndpointAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEndpointAddress.Location = new System.Drawing.Point(112, 20);
            this.tbEndpointAddress.Name = "tbEndpointAddress";
            this.tbEndpointAddress.Size = new System.Drawing.Size(470, 20);
            this.tbEndpointAddress.TabIndex = 1;
            this.tbEndpointAddress.Text = "MQ_PREVIEW_PIPE";
            this.tbEndpointAddress.TextChanged += new System.EventHandler(this.tbEndpointAddress_TextChanged);
            // 
            // btnConnectPreviewTool
            // 
            this.btnConnectPreviewTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectPreviewTool.Location = new System.Drawing.Point(140, 3);
            this.btnConnectPreviewTool.Name = "btnConnectPreviewTool";
            this.btnConnectPreviewTool.Size = new System.Drawing.Size(131, 34);
            this.btnConnectPreviewTool.TabIndex = 1;
            this.btnConnectPreviewTool.Text = "Connect preview tool";
            this.btnConnectPreviewTool.UseVisualStyleBackColor = true;
            this.btnConnectPreviewTool.Click += new System.EventHandler(this.btnConnectPreviewTool_Click);
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 7;
            this.tableLayoutPanel.SetColumnSpan(this.tlpButtons, 2);
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.5F));
            this.tlpButtons.Controls.Add(this.btnDisconnectPreviewTool, 6, 0);
            this.tlpButtons.Controls.Add(this.btnRegisterPreviewTool, 0, 0);
            this.tlpButtons.Controls.Add(this.btnConnectPreviewTool, 1, 0);
            this.tlpButtons.Controls.Add(this.btnRequestChangeHighlight, 4, 0);
            this.tlpButtons.Controls.Add(this.btnRequestContentUpdate, 3, 0);
            this.tlpButtons.Controls.Add(this.btnRequestPreviewPartIdUpdate, 5, 0);
            this.tlpButtons.Controls.Add(this.btnRequestChangeRuntimeSettings, 2, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Enabled = false;
            this.tlpButtons.Location = new System.Drawing.Point(0, 55);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpButtons.Size = new System.Drawing.Size(984, 40);
            this.tlpButtons.TabIndex = 1;
            // 
            // btnDisconnectPreviewTool
            // 
            this.btnDisconnectPreviewTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisconnectPreviewTool.Location = new System.Drawing.Point(840, 3);
            this.btnDisconnectPreviewTool.Name = "btnDisconnectPreviewTool";
            this.btnDisconnectPreviewTool.Size = new System.Drawing.Size(141, 34);
            this.btnDisconnectPreviewTool.TabIndex = 6;
            this.btnDisconnectPreviewTool.Text = "Disconnect preview tool";
            this.btnDisconnectPreviewTool.UseVisualStyleBackColor = true;
            this.btnDisconnectPreviewTool.Click += new System.EventHandler(this.btnDisconnectPreviewTool_Click);
            // 
            // btnRequestPreviewPartIdUpdate
            // 
            this.btnRequestPreviewPartIdUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRequestPreviewPartIdUpdate.Location = new System.Drawing.Point(698, 3);
            this.btnRequestPreviewPartIdUpdate.Name = "btnRequestPreviewPartIdUpdate";
            this.btnRequestPreviewPartIdUpdate.Size = new System.Drawing.Size(136, 34);
            this.btnRequestPreviewPartIdUpdate.TabIndex = 5;
            this.btnRequestPreviewPartIdUpdate.Text = "Request preview part id update";
            this.btnRequestPreviewPartIdUpdate.UseVisualStyleBackColor = true;
            this.btnRequestPreviewPartIdUpdate.Click += new System.EventHandler(this.btnRequestPreviewPartUpdate_Click);
            // 
            // btnRequestChangeRuntimeSettings
            // 
            this.btnRequestChangeRuntimeSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRequestChangeRuntimeSettings.Location = new System.Drawing.Point(277, 3);
            this.btnRequestChangeRuntimeSettings.Name = "btnRequestChangeRuntimeSettings";
            this.btnRequestChangeRuntimeSettings.Size = new System.Drawing.Size(131, 34);
            this.btnRequestChangeRuntimeSettings.TabIndex = 2;
            this.btnRequestChangeRuntimeSettings.Text = "Request change runtime settings";
            this.btnRequestChangeRuntimeSettings.UseVisualStyleBackColor = true;
            this.btnRequestChangeRuntimeSettings.Click += new System.EventHandler(this.btnRequestChangeRuntimeSettings_Click);
            // 
            // gbProxy
            // 
            this.gbProxy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.gbProxy, 2);
            this.gbProxy.Controls.Add(this.lblEndpointAddress);
            this.gbProxy.Controls.Add(this.btnCreateProxy);
            this.gbProxy.Controls.Add(this.tbEndpointAddress);
            this.gbProxy.Location = new System.Drawing.Point(3, 3);
            this.gbProxy.Name = "gbProxy";
            this.gbProxy.Size = new System.Drawing.Size(978, 49);
            this.gbProxy.TabIndex = 0;
            this.gbProxy.TabStop = false;
            this.gbProxy.Text = "Proxy";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.gbProxy, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnClearLog, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.tlpButtons, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.tbLog, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(984, 525);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 525);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 564);
            this.Name = "ClientForm";
            this.Text = "Demo preview tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.tlpButtons.ResumeLayout(false);
            this.gbProxy.ResumeLayout(false);
            this.gbProxy.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnCreateProxy;
        private System.Windows.Forms.Button btnRequestContentUpdate;
        private System.Windows.Forms.Button btnRequestChangeHighlight;
        private System.Windows.Forms.Button btnRegisterPreviewTool;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label lblEndpointAddress;
        private System.Windows.Forms.TextBox tbEndpointAddress;
        private System.Windows.Forms.Button btnConnectPreviewTool;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnRequestPreviewPartIdUpdate;
        private System.Windows.Forms.Button btnRequestChangeRuntimeSettings;
        private System.Windows.Forms.GroupBox gbProxy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnDisconnectPreviewTool;
    }
}

