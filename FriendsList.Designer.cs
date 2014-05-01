namespace VssDisk
{
    partial class FriendsList
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
            this.listFriend = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnKnow = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.listMessage = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listFriend);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 343);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Friends List";
            // 
            // listFriend
            // 
            this.listFriend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFriend.FormattingEnabled = true;
            this.listFriend.ItemHeight = 12;
            this.listFriend.Location = new System.Drawing.Point(3, 17);
            this.listFriend.Name = "listFriend";
            this.listFriend.Size = new System.Drawing.Size(327, 323);
            this.listFriend.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(12, 351);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 82);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operation";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(190, 35);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(117, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "-Unfollow";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(18, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "+Follow";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnKnow);
            this.groupBox3.Controls.Add(this.btnIgnore);
            this.groupBox3.Controls.Add(this.btnAccept);
            this.groupBox3.Location = new System.Drawing.Point(370, 352);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 82);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Command";
            // 
            // btnKnow
            // 
            this.btnKnow.Location = new System.Drawing.Point(68, 33);
            this.btnKnow.Name = "btnKnow";
            this.btnKnow.Size = new System.Drawing.Size(171, 23);
            this.btnKnow.TabIndex = 2;
            this.btnKnow.Text = "Dissmis";
            this.btnKnow.UseVisualStyleBackColor = true;
            this.btnKnow.Visible = false;
            this.btnKnow.Click += new System.EventHandler(this.btnKnow_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Location = new System.Drawing.Point(187, 33);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(105, 23);
            this.btnIgnore.TabIndex = 1;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(33, 33);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(105, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // listMessage
            // 
            this.listMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMessage.FormattingEnabled = true;
            this.listMessage.ItemHeight = 12;
            this.listMessage.Location = new System.Drawing.Point(3, 17);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(327, 323);
            this.listMessage.TabIndex = 0;
            this.listMessage.SelectedIndexChanged += new System.EventHandler(this.listMessage_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listMessage);
            this.groupBox4.Location = new System.Drawing.Point(367, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(333, 343);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Message Box";
            // 
            // FriendsList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(712, 441);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FriendsList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Friends Management";
            this.Load += new System.EventHandler(this.FriendsList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listFriend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ListBox listMessage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnKnow;
    }
}