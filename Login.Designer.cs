namespace VssDisk
{
    partial class Login
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
            this.txtVssId = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.ckbSavePsw = new System.Windows.Forms.CheckBox();
            this.lblMask = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtVssId
            // 
            this.txtVssId.BackColor = System.Drawing.Color.White;
            this.txtVssId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVssId.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVssId.Location = new System.Drawing.Point(448, 151);
            this.txtVssId.Name = "txtVssId";
            this.txtVssId.Size = new System.Drawing.Size(200, 17);
            this.txtVssId.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("SimSun", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassword.Location = new System.Drawing.Point(448, 206);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 17);
            this.txtPassword.TabIndex = 3;
            // 
            // ckbSavePsw
            // 
            this.ckbSavePsw.AutoSize = true;
            this.ckbSavePsw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(221)))), ((int)(((byte)(230)))));
            this.ckbSavePsw.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.ckbSavePsw.Location = new System.Drawing.Point(453, 243);
            this.ckbSavePsw.Name = "ckbSavePsw";
            this.ckbSavePsw.Size = new System.Drawing.Size(15, 14);
            this.ckbSavePsw.TabIndex = 4;
            this.ckbSavePsw.UseVisualStyleBackColor = false;
            // 
            // lblMask
            // 
            this.lblMask.BackColor = System.Drawing.Color.Transparent;
            this.lblMask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMask.Location = new System.Drawing.Point(468, 238);
            this.lblMask.Name = "lblMask";
            this.lblMask.Size = new System.Drawing.Size(115, 23);
            this.lblMask.TabIndex = 5;
            this.lblMask.Click += new System.EventHandler(this.lblMask_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogin.Location = new System.Drawing.Point(442, 271);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(97, 29);
            this.lblLogin.TabIndex = 6;
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            // 
            // lblExit
            // 
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Location = new System.Drawing.Point(570, 271);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(97, 29);
            this.lblExit.TabIndex = 7;
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(118)))), ((int)(((byte)(84)))));
            this.BackgroundImage = global::VssDisk.Properties.Resources.Login_Back;
            this.ClientSize = new System.Drawing.Size(710, 359);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblMask);
            this.Controls.Add(this.ckbSavePsw);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtVssId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "z";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(118)))), ((int)(((byte)(84)))));
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVssId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox ckbSavePsw;
        private System.Windows.Forms.Label lblMask;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblExit;
    }
}

