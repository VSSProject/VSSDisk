namespace VssDisk
{
    partial class UploadForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFileKind = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFileKind);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFileInfo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Info";
            // 
            // cbFileKind
            // 
            this.cbFileKind.FormattingEnabled = true;
            this.cbFileKind.Items.AddRange(new object[] {
            "BinaryFile",
            "Weibo",
            "ShortMessage",
            "Picture",
            "Music",
            "Movie",
            "Email"});
            this.cbFileKind.Location = new System.Drawing.Point(20, 145);
            this.cbFileKind.Name = "cbFileKind";
            this.cbFileKind.Size = new System.Drawing.Size(191, 20);
            this.cbFileKind.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type：";
            // 
            // txtFileInfo
            // 
            this.txtFileInfo.Location = new System.Drawing.Point(19, 46);
            this.txtFileInfo.Multiline = true;
            this.txtFileInfo.Name = "txtFileInfo";
            this.txtFileInfo.Size = new System.Drawing.Size(290, 60);
            this.txtFileInfo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description：";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(289, 219);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(208, 219);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Confirm";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 260);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UploadForm";
            this.Text = "Upload..";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UploadForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFileKind;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpload;
    }
}