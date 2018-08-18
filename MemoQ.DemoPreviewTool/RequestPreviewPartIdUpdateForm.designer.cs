namespace MemoQ.DemoPreviewTool
{
    partial class RequestPreviewPartIdUpdateForm
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
            this.tbPreviewToolId = new System.Windows.Forms.TextBox();
            this.lblPreviewToolId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(420, 32);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(340, 32);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 7;
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
            // RequestPreviewPartIdsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(502, 64);
            this.Controls.Add(this.tbPreviewToolId);
            this.Controls.Add(this.lblPreviewToolId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestPreviewPartIdsForm";
            this.ShowIcon = false;
            this.Text = "Request preview part id update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbPreviewToolId;
        private System.Windows.Forms.Label lblPreviewToolId;
    }
}