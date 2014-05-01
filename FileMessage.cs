using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vss;
using VssDisk.UI;

namespace VssDisk
{
    public partial class FileMessage : Form
    {
        public FileMessage()
        {
            InitializeComponent();
        }

        private void FileMessage_Load(object sender, EventArgs e)
        {
            UIController.FillProvideMessage(ref listFriPub, ref listFriPro, ref listMyPub);
        }
    }
}
