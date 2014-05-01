using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VssDisk.UI;

namespace VssDisk
{
    public partial class FriendsList : Form
    {
        public FriendsList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 更新好友列表与好友消息列表
        /// </summary>
        private void ReadAllList()
        {
            UIController.GetFriends(ref listFriend);
            UIController.GetFriendsMessage(ref listMessage);
        }

        /// <summary>
        /// 当单击三个变化的好友消息按钮时，处理函数。
        /// </summary>
        /// <param name="sender"></param>
        private void BtnPress(object sender){
            Button btn = sender as Button;
            UIController.FriendsMessageCommand(btn.Text, ref listMessage);
            ReadAllList();
        }


        private void FriendsList_Load(object sender, EventArgs e)
        {
            ReadAllList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UIController.AddFriend();
            ReadAllList();
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            UIController.DelFriend(ref listFriend);
            ReadAllList();
        }

        private void listMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIController.SelectFriendsMessage(ref listMessage, ref btnAccept, ref btnIgnore, ref btnKnow);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            BtnPress(sender);
        }

        private void btnKnow_Click(object sender, EventArgs e)
        {
            BtnPress(sender);
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            BtnPress(sender);
        }
    }
}
