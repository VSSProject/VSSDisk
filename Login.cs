using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Thrift.Transport;
using Thrift.Collections;
using Thrift.Server;
using Thrift.Protocol;
using Vss;
using VssDisk.DAL;
using VssDisk.BLL;

namespace VssDisk
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        #region 窗体随鼠标移动

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        #endregion

        #region 保存密码的文字掩码控制CheckBox

        private void lblMask_Click(object sender, EventArgs e)
        {
            ckbSavePsw.Checked = !ckbSavePsw.Checked;
        }

        #endregion


        #region 主逻辑之登录

        private void lblLogin_Click(object sender, EventArgs e)
        {

            //调用登录验证逻辑！

            bool bPass = BLLControl.Login(txtVssId.Text, txtPassword.Text, "VssDisk");

            if (bPass)
            {
                MessageBox.Show("Wrong Username OR Password ! Please Retry !");
                return;
            }
            else
            {
                Main mainForm = new Main();
                mainForm.Show();
                this.Hide();
            }
        }

        #endregion

        

        #region 主逻辑之退出

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion




    }
}
