namespace VssDisk
{
    partial class FileMessage
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listFriPro = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listFriPub = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listMyPub = new System.Windows.Forms.ListBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listFriPro);
            this.groupBox4.Location = new System.Drawing.Point(366, 218);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(333, 343);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shared with Me";
            // 
            // listFriPro
            // 
            this.listFriPro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFriPro.FormattingEnabled = true;
            this.listFriPro.ItemHeight = 12;
            this.listFriPro.Location = new System.Drawing.Point(3, 17);
            this.listFriPro.Name = "listFriPro";
            this.listFriPro.Size = new System.Drawing.Size(327, 323);
            this.listFriPro.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listFriPub);
            this.groupBox1.Location = new System.Drawing.Point(15, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 343);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Friends\' public sharing";
            // 
            // listFriPub
            // 
            this.listFriPub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFriPub.FormattingEnabled = true;
            this.listFriPub.ItemHeight = 12;
            this.listFriPub.Location = new System.Drawing.Point(3, 17);
            this.listFriPub.Name = "listFriPub";
            this.listFriPub.Size = new System.Drawing.Size(327, 323);
            this.listFriPub.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listMyPub);
            this.groupBox3.Location = new System.Drawing.Point(15, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(684, 201);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Shared";
            // 
            // listMyPub
            // 
            this.listMyPub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMyPub.FormattingEnabled = true;
            this.listMyPub.ItemHeight = 12;
            this.listMyPub.Location = new System.Drawing.Point(3, 17);
            this.listMyPub.Name = "listMyPub";
            this.listMyPub.Size = new System.Drawing.Size(678, 181);
            this.listMyPub.TabIndex = 0;
            // 
            // FileMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 575);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileMessage";
            this.Text = "Files Management";
            this.Load += new System.EventHandler(this.FileMessage_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listFriPro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listFriPub;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listMyPub;
    }
}