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
    public partial class FriendForm : Form
    {
        public FriendForm()
        {
            InitializeComponent();
        }

        private List<string> ProvideList, RecoverList;
        private bool bCurPublish;

        private string fileID;

        public void InitByFileID(string fID)
        {
            fileID = fID;
            ProvideList = new List<string>();
            RecoverList = new List<string>();
            UIController.FillProvideList(ref listAll, ref listShare, ref cbPublish, fileID);
            bCurPublish = cbPublish.Checked;
        }

        private void FriendForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (txtProvideName.Text == "")
            {
                MessageBox.Show("You must write a name to provide the file !");
                return;
            }
            UIController.SubmitProvide(fileID, ProvideList, RecoverList, ref cbPublish, bCurPublish, txtProvideName.Text);
            this.Close();
        }

        private void listAll_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listAll.SelectedIndex > -1)
            {
                UIController.AddFileProvide(ProvideList, RecoverList, ref listAll, ref listShare);
            }
        }

        private void listShare_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listShare.SelectedIndex > -1)
            {
                UIController.DelFileProvide(ProvideList, RecoverList, ref listAll, ref listShare);
            }
        }
    }
}
