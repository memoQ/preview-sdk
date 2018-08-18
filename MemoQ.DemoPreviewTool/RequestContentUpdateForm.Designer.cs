namespace MemoQ.DemoPreviewTool
{
    partial class RequestContentUpdateForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblPreviewPartIds = new System.Windows.Forms.Label();
            this.tbPreviewPartIds = new System.Windows.Forms.TextBox();
            this.tbPreviewToolId = new System.Windows.Forms.TextBox();
            this.lblPreviewToolId = new System.Windows.Forms.Label();
            this.lblTargetLangCodes = new System.Windows.Forms.Label();
            this.tbTargetLangCodes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(420, 248);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(340, 248);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblPreviewPartIds
            // 
            this.lblPreviewPartIds.AutoSize = true;
            this.lblPreviewPartIds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPreviewPartIds.Location = new System.Drawing.Point(12, 36);
            this.lblPreviewPartIds.Name = "lblPreviewPartIds";
            this.lblPreviewPartIds.Size = new System.Drawing.Size(98, 13);
            this.lblPreviewPartIds.TabIndex = 2;
            this.lblPreviewPartIds.Text = "Preview part ids";
            // 
            // tbPreviewPartIds
            // 
            this.tbPreviewPartIds.Location = new System.Drawing.Point(156, 32);
            this.tbPreviewPartIds.Multiline = true;
            this.tbPreviewPartIds.Name = "tbPreviewPartIds";
            this.tbPreviewPartIds.Size = new System.Drawing.Size(340, 136);
            this.tbPreviewPartIds.TabIndex = 3;
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
            // lblTargetLangCodes
            // 
            this.lblTargetLangCodes.AutoSize = true;
            this.lblTargetLangCodes.Location = new System.Drawing.Point(12, 176);
            this.lblTargetLangCodes.Name = "lblTargetLangCodes";
            this.lblTargetLangCodes.Size = new System.Drawing.Size(117, 13);
            this.lblTargetLangCodes.TabIndex = 4;
            this.lblTargetLangCodes.Text = "Target language codes";
            // 
            // tbTargetLangCodes
            // 
            this.tbTargetLangCodes.Location = new System.Drawing.Point(156, 172);
            this.tbTargetLangCodes.Multiline = true;
            this.tbTargetLangCodes.Name = "tbTargetLangCodes";
            this.tbTargetLangCodes.Size = new System.Drawing.Size(340, 72);
            this.tbTargetLangCodes.TabIndex = 6;
            // 
            // RequestContentUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(502, 278);
            this.Controls.Add(this.tbTargetLangCodes);
            this.Controls.Add(this.lblTargetLangCodes);
            this.Controls.Add(this.tbPreviewToolId);
            this.Controls.Add(this.lblPreviewToolId);
            this.Controls.Add(this.tbPreviewPartIds);
            this.Controls.Add(this.lblPreviewPartIds);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestContentUpdateForm";
            this.ShowIcon = false;
            this.Text = "Request content update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblPreviewPartIds;
        private System.Windows.Forms.TextBox tbPreviewPartIds;
        private System.Windows.Forms.TextBox tbPreviewToolId;
        private System.Windows.Forms.Label lblPreviewToolId;
        private System.Windows.Forms.Label lblTargetLangCodes;
        private System.Windows.Forms.TextBox tbTargetLangCodes;
    }
}