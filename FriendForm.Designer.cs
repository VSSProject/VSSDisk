namespace VssDisk
{
    partial class FriendForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listAll = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listShare = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtProvideName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPublish = new System.Windows.Forms.CheckBox();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(579, 475);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(579, 366);
            this.splitContainer2.SplitterDistance = 284;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listAll);
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 356);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Friends List";
            // 
            // listAll
            // 
            this.listAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAll.FormattingEnabled = true;
            this.listAll.ItemHeight = 12;
            this.listAll.Location = new System.Drawing.Point(3, 17);
            this.listAll.Name = "listAll";
            this.listAll.Size = new System.Drawing.Size(265, 336);
            this.listAll.TabIndex = 0;
            this.listAll.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listAll_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listShare);
            this.groupBox2.Location = new System.Drawing.Point(11, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 356);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Share with";
            // 
            // listShare
            // 
            this.listShare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listShare.FormattingEnabled = true;
            this.listShare.ItemHeight = 12;
            this.listShare.Location = new System.Drawing.Point(3, 17);
            this.listShare.Name = "listShare";
            this.listShare.Size = new System.Drawing.Size(265, 336);
            this.listShare.TabIndex = 0;
            this.listShare.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listShare_MouseDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtProvideName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbPublish);
            this.groupBox3.Controls.Add(this.btnShare);
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(566, 95);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operation";
            // 
            // txtProvideName
            // 
            this.txtProvideName.Location = new System.Drawing.Point(113, 27);
            this.txtProvideName.Name = "txtProvideName";
            this.txtProvideName.Size = new System.Drawing.Size(294, 21);
            this.txtProvideName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID :";
            // 
            // cbPublish
            // 
            this.cbPublish.AutoSize = true;
            this.cbPublish.Location = new System.Drawing.Point(25, 65);
            this.cbPublish.Name = "cbPublish";
            this.cbPublish.Size = new System.Drawing.Size(336, 16);
            this.cbPublish.TabIndex = 2;
            this.cbPublish.Text = "Public on the VSS. Anyone who follows you can access";
            this.cbPublish.UseVisualStyleBackColor = true;
            // 
            // btnShare
            // 
            this.btnShare.Location = new System.Drawing.Point(439, 25);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(98, 23);
            this.btnShare.TabIndex = 1;
            this.btnShare.Text = "Confirm";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(439, 61);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 475);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FriendForm";
            this.Text = "Share...";
            this.Load += new System.EventHandler(this.FriendForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listShare;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.CheckBox cbPublish;
        private System.Windows.Forms.TextBox txtProvideName;
        private System.Windows.Forms.Label label1;
    }
}