namespace MemoQ.DemoPreviewTool
{
    partial class RequestChangeRuntimeSettingsForm
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
            this.lblContentComplexity = new System.Windows.Forms.Label();
            this.rbContentComplexityMinimal = new System.Windows.Forms.RadioButton();
            this.rbContentComplexityPlainWithFormatting = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbPreviewToolId = new System.Windows.Forms.TextBox();
            this.lblPreviewToolId = new System.Windows.Forms.Label();
            this.tbRequiredProperties = new System.Windows.Forms.TextBox();
            this.lblRequiredProperties = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblContentComplexity
            // 
            this.lblContentComplexity.AutoSize = true;
            this.lblContentComplexity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblContentComplexity.Location = new System.Drawing.Point(12, 36);
            this.lblContentComplexity.Name = "lblContentComplexity";
            this.lblContentComplexity.Size = new System.Drawing.Size(114, 13);
            this.lblContentComplexity.TabIndex = 10;
            this.lblContentComplexity.Text = "Content complexity";
            // 
            // rbContentComplexityMinimal
            // 
            this.rbContentComplexityMinimal.AutoSize = true;
            this.rbContentComplexityMinimal.Checked = true;
            this.rbContentComplexityMinimal.Location = new System.Drawing.Point(156, 34);
            this.rbContentComplexityMinimal.Name = "rbContentComplexityMinimal";
            this.rbContentComplexityMinimal.Size = new System.Drawing.Size(60, 17);
            this.rbContentComplexityMinimal.TabIndex = 11;
            this.rbContentComplexityMinimal.TabStop = true;
            this.rbContentComplexityMinimal.Text = "Minimal";
            this.rbContentComplexityMinimal.UseVisualStyleBackColor = true;
            // 
            // rbContentComplexityPlainWithFormatting
            // 
            this.rbContentComplexityPlainWithFormatting.AutoSize = true;
            this.rbContentComplexityPlainWithFormatting.Location = new System.Drawing.Point(224, 34);
            this.rbContentComplexityPlainWithFormatting.Name = "rbContentComplexityPlainWithFormatting";
            this.rbContentComplexityPlainWithFormatting.Size = new System.Drawing.Size(172, 17);
            this.rbContentComplexityPlainWithFormatting.TabIndex = 12;
            this.rbContentComplexityPlainWithFormatting.TabStop = true;
            this.rbContentComplexityPlainWithFormatting.Text = "Plain with interpreted formatting";
            this.rbContentComplexityPlainWithFormatting.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(420, 140);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(340, 140);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbPreviewToolId
            // 
            this.tbPreviewToolId.Location = new System.Drawing.Point(156, 8);
            this.tbPreviewToolId.Name = "tbPreviewToolId";
            this.tbPreviewToolId.Size = new System.Drawing.Size(340, 20);
            this.tbPreviewToolId.TabIndex = 1;
            this.tbPreviewToolId.Text = "15013B28-6C67-4164-BFAB-587EE3D180DA";
            // 
            // lblPreviewToolId
            // 
            this.lblPreviewToolId.AutoSize = true;
            this.lblPreviewToolId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPreviewToolId.Location = new System.Drawing.Point(12, 12);
            this.lblPreviewToolId.Name = "lblPreviewToolId";
            this.lblPreviewToolId.Size = new System.Drawing.Size(91, 13);
            this.lblPreviewToolId.TabIndex = 0;
            this.lblPreviewToolId.Text = "Preview tool id";
            // 
            // tbRequiredProperties
            // 
            this.tbRequiredProperties.Location = new System.Drawing.Point(156, 60);
            this.tbRequiredProperties.Multiline = true;
            this.tbRequiredProperties.Name = "tbRequiredProperties";
            this.tbRequiredProperties.Size = new System.Drawing.Size(340, 72);
            this.tbRequiredProperties.TabIndex = 18;
            // 
            // lblRequiredProperties
            // 
            this.lblRequiredProperties.AutoSize = true;
            this.lblRequiredProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRequiredProperties.Location = new System.Drawing.Point(12, 60);
            this.lblRequiredProperties.Name = "lblRequiredProperties";
            this.lblRequiredProperties.Size = new System.Drawing.Size(99, 13);
            this.lblRequiredProperties.TabIndex = 17;
            this.lblRequiredProperties.Text = "Required properties";
            // 
            // RequestChangeRuntimeSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(502, 173);
            this.Controls.Add(this.tbRequiredProperties);
            this.Controls.Add(this.lblRequiredProperties);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rbContentComplexityPlainWithFormatting);
            this.Controls.Add(this.rbContentComplexityMinimal);
            this.Controls.Add(this.tbPreviewToolId);
            this.Controls.Add(this.lblContentComplexity);
            this.Controls.Add(this.lblPreviewToolId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestChangeRuntimeSettingsForm";
            this.ShowIcon = false;
            this.Text = "Request change runtime settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblContentComplexity;
        private System.Windows.Forms.RadioButton rbContentComplexityMinimal;
        private System.Windows.Forms.RadioButton rbContentComplexityPlainWithFormatting;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbPreviewToolId;
        private System.Windows.Forms.Label lblPreviewToolId;
        private System.Windows.Forms.TextBox tbRequiredProperties;
        private System.Windows.Forms.Label lblRequiredProperties;
    }
}