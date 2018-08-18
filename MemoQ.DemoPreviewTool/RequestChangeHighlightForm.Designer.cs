namespace MemoQ.DemoPreviewTool
{
    partial class RequestChangeHighlightForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbSourceLangCode = new System.Windows.Forms.TextBox();
            this.tbPreviewPartId = new System.Windows.Forms.TextBox();
            this.lblPreviewPartId = new System.Windows.Forms.Label();
            this.lblSourceLangCode = new System.Windows.Forms.Label();
            this.lblTargetLanguageCode = new System.Windows.Forms.Label();
            this.lblSourceContent = new System.Windows.Forms.Label();
            this.lblTargetContent = new System.Windows.Forms.Label();
            this.lblSourceFocusedRange = new System.Windows.Forms.Label();
            this.lblSourceFocusedRangeStart = new System.Windows.Forms.Label();
            this.lblTargetFocusedRange = new System.Windows.Forms.Label();
            this.lblSourceFocusedRangeLength = new System.Windows.Forms.Label();
            this.tbTargetLangCode = new System.Windows.Forms.TextBox();
            this.cbSendTargetContent = new System.Windows.Forms.CheckBox();
            this.cbSendSourceFocusedRange = new System.Windows.Forms.CheckBox();
            this.cbSendTargetFocusedRange = new System.Windows.Forms.CheckBox();
            this.tbSourceContent = new System.Windows.Forms.TextBox();
            this.tbTargetContent = new System.Windows.Forms.TextBox();
            this.lblTargetFocusedRangeStart = new System.Windows.Forms.Label();
            this.nudSourceFocusedRangeStart = new System.Windows.Forms.NumericUpDown();
            this.nudTargetFocusedRangeStart = new System.Windows.Forms.NumericUpDown();
            this.lblTargetFocusedRangeLength = new System.Windows.Forms.Label();
            this.nudSourceFocusedRangeLength = new System.Windows.Forms.NumericUpDown();
            this.nudTargetFocusedRangeLength = new System.Windows.Forms.NumericUpDown();
            this.lblPreviewToolId = new System.Windows.Forms.Label();
            this.tbPreviewToolId = new System.Windows.Forms.TextBox();
            this.cbSendSourceContent = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudSourceFocusedRangeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetFocusedRangeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSourceFocusedRangeLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetFocusedRangeLength)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(340, 204);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 28;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(420, 204);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // tbSourceLangCode
            // 
            this.tbSourceLangCode.Location = new System.Drawing.Point(156, 56);
            this.tbSourceLangCode.Name = "tbSourceLangCode";
            this.tbSourceLangCode.Size = new System.Drawing.Size(100, 20);
            this.tbSourceLangCode.TabIndex = 6;
            // 
            // tbPreviewPartId
            // 
            this.tbPreviewPartId.Location = new System.Drawing.Point(156, 32);
            this.tbPreviewPartId.Name = "tbPreviewPartId";
            this.tbPreviewPartId.Size = new System.Drawing.Size(340, 20);
            this.tbPreviewPartId.TabIndex = 3;
            // 
            // lblPreviewPartId
            // 
            this.lblPreviewPartId.AutoSize = true;
            this.lblPreviewPartId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPreviewPartId.Location = new System.Drawing.Point(12, 36);
            this.lblPreviewPartId.Name = "lblPreviewPartId";
            this.lblPreviewPartId.Size = new System.Drawing.Size(92, 13);
            this.lblPreviewPartId.TabIndex = 2;
            this.lblPreviewPartId.Text = "Preview part id";
            // 
            // lblSourceLangCode
            // 
            this.lblSourceLangCode.AutoSize = true;
            this.lblSourceLangCode.Location = new System.Drawing.Point(12, 60);
            this.lblSourceLangCode.Name = "lblSourceLangCode";
            this.lblSourceLangCode.Size = new System.Drawing.Size(115, 13);
            this.lblSourceLangCode.TabIndex = 4;
            this.lblSourceLangCode.Text = "Source language code";
            // 
            // lblTargetLanguageCode
            // 
            this.lblTargetLanguageCode.AutoSize = true;
            this.lblTargetLanguageCode.Location = new System.Drawing.Point(12, 84);
            this.lblTargetLanguageCode.Name = "lblTargetLanguageCode";
            this.lblTargetLanguageCode.Size = new System.Drawing.Size(112, 13);
            this.lblTargetLanguageCode.TabIndex = 7;
            this.lblTargetLanguageCode.Text = "Target language code";
            // 
            // lblSourceContent
            // 
            this.lblSourceContent.AutoSize = true;
            this.lblSourceContent.Location = new System.Drawing.Point(12, 108);
            this.lblSourceContent.Name = "lblSourceContent";
            this.lblSourceContent.Size = new System.Drawing.Size(80, 13);
            this.lblSourceContent.TabIndex = 10;
            this.lblSourceContent.Text = "Source content";
            // 
            // lblTargetContent
            // 
            this.lblTargetContent.AutoSize = true;
            this.lblTargetContent.Location = new System.Drawing.Point(12, 132);
            this.lblTargetContent.Name = "lblTargetContent";
            this.lblTargetContent.Size = new System.Drawing.Size(77, 13);
            this.lblTargetContent.TabIndex = 13;
            this.lblTargetContent.Text = "Target content";
            // 
            // lblSourceFocusedRange
            // 
            this.lblSourceFocusedRange.AutoSize = true;
            this.lblSourceFocusedRange.Location = new System.Drawing.Point(12, 156);
            this.lblSourceFocusedRange.Name = "lblSourceFocusedRange";
            this.lblSourceFocusedRange.Size = new System.Drawing.Size(112, 13);
            this.lblSourceFocusedRange.TabIndex = 16;
            this.lblSourceFocusedRange.Text = "Source focused range";
            // 
            // lblSourceFocusedRangeStart
            // 
            this.lblSourceFocusedRangeStart.AutoSize = true;
            this.lblSourceFocusedRangeStart.Location = new System.Drawing.Point(156, 156);
            this.lblSourceFocusedRangeStart.Name = "lblSourceFocusedRangeStart";
            this.lblSourceFocusedRangeStart.Size = new System.Drawing.Size(29, 13);
            this.lblSourceFocusedRangeStart.TabIndex = 18;
            this.lblSourceFocusedRangeStart.Text = "Start";
            // 
            // lblTargetFocusedRange
            // 
            this.lblTargetFocusedRange.AutoSize = true;
            this.lblTargetFocusedRange.Location = new System.Drawing.Point(12, 180);
            this.lblTargetFocusedRange.Name = "lblTargetFocusedRange";
            this.lblTargetFocusedRange.Size = new System.Drawing.Size(109, 13);
            this.lblTargetFocusedRange.TabIndex = 22;
            this.lblTargetFocusedRange.Text = "Target focused range";
            // 
            // lblSourceFocusedRangeLength
            // 
            this.lblSourceFocusedRangeLength.AutoSize = true;
            this.lblSourceFocusedRangeLength.Location = new System.Drawing.Point(272, 156);
            this.lblSourceFocusedRangeLength.Name = "lblSourceFocusedRangeLength";
            this.lblSourceFocusedRangeLength.Size = new System.Drawing.Size(40, 13);
            this.lblSourceFocusedRangeLength.TabIndex = 20;
            this.lblSourceFocusedRangeLength.Text = "Length";
            // 
            // tbTargetLangCode
            // 
            this.tbTargetLangCode.Location = new System.Drawing.Point(156, 80);
            this.tbTargetLangCode.Name = "tbTargetLangCode";
            this.tbTargetLangCode.Size = new System.Drawing.Size(100, 20);
            this.tbTargetLangCode.TabIndex = 9;
            // 
            // cbSendTargetContent
            // 
            this.cbSendTargetContent.AutoSize = true;
            this.cbSendTargetContent.Checked = true;
            this.cbSendTargetContent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSendTargetContent.Location = new System.Drawing.Point(136, 132);
            this.cbSendTargetContent.Name = "cbSendTargetContent";
            this.cbSendTargetContent.Size = new System.Drawing.Size(15, 14);
            this.cbSendTargetContent.TabIndex = 14;
            this.cbSendTargetContent.UseVisualStyleBackColor = true;
            this.cbSendTargetContent.CheckedChanged += new System.EventHandler(this.cbSendTargetContent_CheckedChanged);
            // 
            // cbSendSourceFocusedRange
            // 
            this.cbSendSourceFocusedRange.AutoSize = true;
            this.cbSendSourceFocusedRange.Checked = true;
            this.cbSendSourceFocusedRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSendSourceFocusedRange.Location = new System.Drawing.Point(136, 156);
            this.cbSendSourceFocusedRange.Name = "cbSendSourceFocusedRange";
            this.cbSendSourceFocusedRange.Size = new System.Drawing.Size(15, 14);
            this.cbSendSourceFocusedRange.TabIndex = 17;
            this.cbSendSourceFocusedRange.UseVisualStyleBackColor = true;
            this.cbSendSourceFocusedRange.CheckedChanged += new System.EventHandler(this.cbSendSourceFocusedRange_CheckedChanged);
            // 
            // cbSendTargetFocusedRange
            // 
            this.cbSendTargetFocusedRange.AutoSize = true;
            this.cbSendTargetFocusedRange.Checked = true;
            this.cbSendTargetFocusedRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSendTargetFocusedRange.Location = new System.Drawing.Point(136, 180);
            this.cbSendTargetFocusedRange.Name = "cbSendTargetFocusedRange";
            this.cbSendTargetFocusedRange.Size = new System.Drawing.Size(15, 14);
            this.cbSendTargetFocusedRange.TabIndex = 23;
            this.cbSendTargetFocusedRange.UseVisualStyleBackColor = true;
            this.cbSendTargetFocusedRange.CheckedChanged += new System.EventHandler(this.cbSendTargetFocusedRange_CheckedChanged);
            // 
            // tbSourceContent
            // 
            this.tbSourceContent.Location = new System.Drawing.Point(156, 104);
            this.tbSourceContent.Name = "tbSourceContent";
            this.tbSourceContent.Size = new System.Drawing.Size(340, 20);
            this.tbSourceContent.TabIndex = 12;
            // 
            // tbTargetContent
            // 
            this.tbTargetContent.Location = new System.Drawing.Point(156, 128);
            this.tbTargetContent.Name = "tbTargetContent";
            this.tbTargetContent.Size = new System.Drawing.Size(340, 20);
            this.tbTargetContent.TabIndex = 15;
            // 
            // lblTargetFocusedRangeStart
            // 
            this.lblTargetFocusedRangeStart.AutoSize = true;
            this.lblTargetFocusedRangeStart.Location = new System.Drawing.Point(156, 180);
            this.lblTargetFocusedRangeStart.Name = "lblTargetFocusedRangeStart";
            this.lblTargetFocusedRangeStart.Size = new System.Drawing.Size(29, 13);
            this.lblTargetFocusedRangeStart.TabIndex = 24;
            this.lblTargetFocusedRangeStart.Text = "Start";
            // 
            // nudSourceFocusedRangeStart
            // 
            this.nudSourceFocusedRangeStart.Location = new System.Drawing.Point(192, 152);
            this.nudSourceFocusedRangeStart.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSourceFocusedRangeStart.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudSourceFocusedRangeStart.Name = "nudSourceFocusedRangeStart";
            this.nudSourceFocusedRangeStart.Size = new System.Drawing.Size(52, 20);
            this.nudSourceFocusedRangeStart.TabIndex = 19;
            // 
            // nudTargetFocusedRangeStart
            // 
            this.nudTargetFocusedRangeStart.Location = new System.Drawing.Point(192, 176);
            this.nudTargetFocusedRangeStart.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTargetFocusedRangeStart.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudTargetFocusedRangeStart.Name = "nudTargetFocusedRangeStart";
            this.nudTargetFocusedRangeStart.Size = new System.Drawing.Size(52, 20);
            this.nudTargetFocusedRangeStart.TabIndex = 25;
            // 
            // lblTargetFocusedRangeLength
            // 
            this.lblTargetFocusedRangeLength.AutoSize = true;
            this.lblTargetFocusedRangeLength.Location = new System.Drawing.Point(272, 180);
            this.lblTargetFocusedRangeLength.Name = "lblTargetFocusedRangeLength";
            this.lblTargetFocusedRangeLength.Size = new System.Drawing.Size(40, 13);
            this.lblTargetFocusedRangeLength.TabIndex = 26;
            this.lblTargetFocusedRangeLength.Text = "Length";
            // 
            // nudSourceFocusedRangeLength
            // 
            this.nudSourceFocusedRangeLength.Location = new System.Drawing.Point(316, 152);
            this.nudSourceFocusedRangeLength.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSourceFocusedRangeLength.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudSourceFocusedRangeLength.Name = "nudSourceFocusedRangeLength";
            this.nudSourceFocusedRangeLength.Size = new System.Drawing.Size(52, 20);
            this.nudSourceFocusedRangeLength.TabIndex = 21;
            // 
            // nudTargetFocusedRangeLength
            // 
            this.nudTargetFocusedRangeLength.Location = new System.Drawing.Point(316, 176);
            this.nudTargetFocusedRangeLength.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTargetFocusedRangeLength.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudTargetFocusedRangeLength.Name = "nudTargetFocusedRangeLength";
            this.nudTargetFocusedRangeLength.Size = new System.Drawing.Size(52, 20);
            this.nudTargetFocusedRangeLength.TabIndex = 27;
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
            // tbPreviewToolId
            // 
            this.tbPreviewToolId.Location = new System.Drawing.Point(156, 8);
            this.tbPreviewToolId.Name = "tbPreviewToolId";
            this.tbPreviewToolId.Size = new System.Drawing.Size(340, 20);
            this.tbPreviewToolId.TabIndex = 1;
            this.tbPreviewToolId.Text = "15013B28-6C67-4164-BFAB-587EE3D180DA";
            // 
            // cbSendSourceContent
            // 
            this.cbSendSourceContent.AutoSize = true;
            this.cbSendSourceContent.Checked = true;
            this.cbSendSourceContent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSendSourceContent.Location = new System.Drawing.Point(136, 108);
            this.cbSendSourceContent.Name = "cbSendSourceContent";
            this.cbSendSourceContent.Size = new System.Drawing.Size(15, 14);
            this.cbSendSourceContent.TabIndex = 11;
            this.cbSendSourceContent.UseVisualStyleBackColor = true;
            this.cbSendSourceContent.CheckedChanged += new System.EventHandler(this.cbSendSourceContent_CheckedChanged);
            // 
            // RequestChangeHighlightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(502, 235);
            this.Controls.Add(this.tbPreviewToolId);
            this.Controls.Add(this.lblPreviewToolId);
            this.Controls.Add(this.nudTargetFocusedRangeLength);
            this.Controls.Add(this.nudSourceFocusedRangeLength);
            this.Controls.Add(this.lblTargetFocusedRangeLength);
            this.Controls.Add(this.nudTargetFocusedRangeStart);
            this.Controls.Add(this.nudSourceFocusedRangeStart);
            this.Controls.Add(this.lblTargetFocusedRangeStart);
            this.Controls.Add(this.tbTargetContent);
            this.Controls.Add(this.tbSourceContent);
            this.Controls.Add(this.cbSendTargetFocusedRange);
            this.Controls.Add(this.cbSendSourceFocusedRange);
            this.Controls.Add(this.cbSendTargetContent);
            this.Controls.Add(this.cbSendSourceContent);
            this.Controls.Add(this.tbTargetLangCode);
            this.Controls.Add(this.lblSourceFocusedRangeLength);
            this.Controls.Add(this.lblTargetFocusedRange);
            this.Controls.Add(this.lblSourceFocusedRangeStart);
            this.Controls.Add(this.lblSourceFocusedRange);
            this.Controls.Add(this.lblTargetContent);
            this.Controls.Add(this.lblSourceContent);
            this.Controls.Add(this.lblTargetLanguageCode);
            this.Controls.Add(this.lblSourceLangCode);
            this.Controls.Add(this.lblPreviewPartId);
            this.Controls.Add(this.tbPreviewPartId);
            this.Controls.Add(this.tbSourceLangCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestChangeHighlightForm";
            this.ShowIcon = false;
            this.Text = "Request change highlight";
            ((System.ComponentModel.ISupportInitialize)(this.nudSourceFocusedRangeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetFocusedRangeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSourceFocusedRangeLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetFocusedRangeLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbSourceLangCode;
        private System.Windows.Forms.TextBox tbPreviewPartId;
        private System.Windows.Forms.Label lblPreviewPartId;
        private System.Windows.Forms.Label lblSourceLangCode;
        private System.Windows.Forms.Label lblTargetLanguageCode;
        private System.Windows.Forms.Label lblSourceContent;
        private System.Windows.Forms.Label lblTargetContent;
        private System.Windows.Forms.Label lblSourceFocusedRange;
        private System.Windows.Forms.Label lblSourceFocusedRangeStart;
        private System.Windows.Forms.Label lblTargetFocusedRange;
        private System.Windows.Forms.Label lblSourceFocusedRangeLength;
        private System.Windows.Forms.TextBox tbTargetLangCode;
        private System.Windows.Forms.CheckBox cbSendTargetContent;
        private System.Windows.Forms.CheckBox cbSendSourceFocusedRange;
        private System.Windows.Forms.CheckBox cbSendTargetFocusedRange;
        private System.Windows.Forms.TextBox tbSourceContent;
        private System.Windows.Forms.TextBox tbTargetContent;
        private System.Windows.Forms.Label lblTargetFocusedRangeStart;
        private System.Windows.Forms.NumericUpDown nudSourceFocusedRangeStart;
        private System.Windows.Forms.NumericUpDown nudTargetFocusedRangeStart;
        private System.Windows.Forms.Label lblTargetFocusedRangeLength;
        private System.Windows.Forms.NumericUpDown nudSourceFocusedRangeLength;
        private System.Windows.Forms.NumericUpDown nudTargetFocusedRangeLength;
        private System.Windows.Forms.Label lblPreviewToolId;
        private System.Windows.Forms.TextBox tbPreviewToolId;
        private System.Windows.Forms.CheckBox cbSendSourceContent;
    }
}