using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Thrift.Transport;
using Thrift.Collections;
using Thrift.Server;
using Thrift.Protocol;
using VssDisk.Datastruct;
using VssDisk.Example;
using VssDisk.UI;
using VssDisk.BLL;
using Vss;


namespace VssDisk
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {

#region Init UIController

            List<TextBox> listTextBox = new List<TextBox>();
            listTextBox.Add(tbFileID);
            listTextBox.Add(tbFileName);
            listTextBox.Add(tbFileKind);
            listTextBox.Add(tbFromApp);
            listTextBox.Add(tbFileSize);
            listTextBox.Add(tbCreateDate);
            UIController.InitUIController(ref treeView1, ref listView1, ref listTextBox, ref rtbFileInfo, this);

#endregion


#region For Login

            //进行通信，拉取用户的数据。

            FileTreeNode fileTreeNode = BLLControl.InitFileTree();
           
            UIController.InitData(fileTreeNode);
            //0是自己文件夹
            UIController.InitFolder(fileTreeNode.SubNodes[0], fileTreeNode.SubNodes[1], fileTreeNode.SubNodes[2], fileTreeNode.SubNodes[3]);


#endregion

            //Start the Timer. Just for Demo. Has poor performance.
            UpdateStateString();

            UIController.FillFileTreeByTimerLoadingMessage(ref treeView1);

            timerMessage.Start();


        }


        #region Public Logical Function

        private void AddNewFolder()
        {
            UIController.AddNewFolder();
        }

        private void UpdateStateString()
        {
            TNumber tNumber = BLLControl.GetNumber();

            tssFriendMessage.Text = tNumber.FriendMsgNum.ToString();

            tssMessage.Text = tNumber.ProvideMsgNum.ToString();
        }

        private void Rename()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            UIController.RenameNode((FileTreeNode)listView1.SelectedItems[0].Tag);
        }

        private void Download()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            FileTreeNode file = (FileTreeNode)listView1.SelectedItems[0].Tag;
            //文件实体已被删除
            if (file.FileID == "")
            {
                UIController.DeleteNode(file);
                MessageBox.Show("This file 's content have been deleted ! So you can not download ! The file's link will be delete !");
                return;
            }
            UIController.Download(file);
        }

        private void Cut()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            UIController.CutNode((FileTreeNode)listView1.SelectedItems[0].Tag);
        }

        private void Copy()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            UIController.CopyNode((FileTreeNode)listView1.SelectedItems[0].Tag);
        }

        private void Delete()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            UIController.DeleteNode((FileTreeNode)listView1.SelectedItems[0].Tag);
        }

        private void Destory()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            FileTreeNode file = (FileTreeNode)listView1.SelectedItems[0].Tag;
            if (file.FileOwner != BLLControl.GetValidator().VssID)
            {
                MessageBox.Show("This File is not belong to you ! You have no permission to dispose it !");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("If you dispose the file, all links to this file will lost! Continue ?", "Alarm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                UIController.DestroyNode(file);
                UIController.DeleteNodeByFileID(file.FileID);
            }

        }

        private void Provide()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a file to be shared !");
                return;
            }
            FriendForm friendForm = new FriendForm();
            friendForm.InitByFileID(((FileTreeNode)listView1.SelectedItems[0].Tag).FileID);
            friendForm.Show();
        }

        #endregion



        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UIController.TurnCurrentNode((FileTreeNode)e.Node.Tag);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            { 
                return;
            }
            
            UIController.SetFileInfoByObject((FileTreeNode)listView1.SelectedItems[0].Tag);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            FileTreeNode clickFileTreeNode = (FileTreeNode)listView1.SelectedItems[0].Tag;
            //判断是目录还是文件
            if (clickFileTreeNode.SubNodes != null)
            {
                UIController.TurnCurrentNode(clickFileTreeNode);
            }
            else
            {
                //说明是一个文件
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            AddNewFolder();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Delete();

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            UIController.PasteNode();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UIController.GoBack();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            UIController.GoForward();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            Provide();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            FriendsList friendList = new FriendsList();
            friendList.Show();
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewFolder();
        }

        private void newFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewFolder();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void renameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            UIController.Upload();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UIController.PasteNode();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Download();
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIController.Upload();
        }

        private void uploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UIController.Upload();
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Download();
        }

        private void downLoadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Download();
        }

        private void goBackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UIController.GoBack();
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIController.GoBack();
        }

        private void goForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIController.GoForward();
        }

        private void goNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIController.GoForward();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIController.PasteNode();
        }

        private void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void shareFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Provide();
        }

        private void shareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Provide();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            FileMessage fMessage = new FileMessage();
            fMessage.Show();
        }

        private void destroyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
            Destory();
            
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            FileTreeNode file = (FileTreeNode)listView1.SelectedItems[0].Tag;
            if (file.FileOwner != BLLControl.GetValidator().VssID)
            {
                MessageBox.Show("This File is not belong to you ! So you can not Destory it !");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("If you replace the FILE by what you upload later. All the functions which rely on the File will change. Do you stil want to Replace it?", "Replace Alarm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                UIController.Upload(file.FileID);
            }
            
        }

        private void timerMessage_Tick(object sender, EventArgs e)
        {
            //Just For Demo. Doing this has a poor performance !

            UpdateStateString();

            UIController.FillFileTreeByTimerLoadingMessage(ref treeView1);
        }
    }
}
