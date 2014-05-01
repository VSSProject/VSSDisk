using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VssDisk.Datastruct;
using Newtonsoft.Json;
using System.Timers;
using Microsoft.VisualBasic;
using Vss;
using VssDisk.BLL;


namespace VssDisk.UI
{
    class UIController
    {

        public static Main MainLink = null;

        #region Private


        /// <summary>
        /// 用于保存当前打开的目录，默认是根。
        /// </summary>
        private static FileTreeNode CurrentNode = null;

        /// <summary>
        /// Node类型
        /// </summary>
        public static string[] ContentKindString = { "Folder", "BinaryFile", "Weibo", "ShortMessage", "Picture", "Music", "Movie", "Email" };

        private static FileTreeNode PublishFolder = null, tempPublishFolder = null;
        private static FileTreeNode FocusFolder = null, tempFocusFolder = null;
        private static FileTreeNode ReceiveFolder = null, tempReceiveFolder = null;
        private static FileTreeNode FreeFolder = null;

        /// <summary>
        /// Cut时存储的缓存位置
        /// </summary>
        private static FileTreeNode CutTemp = null;

        private static TreeView uiTreeNode = null;
        private static ListView uiListView = null;
        private static List<TextBox> uiListTextBox = null;
        private static RichTextBox uiRichTextBox = null;

        private static Stack<FileTreeNode> uiStackFileTreeNode = null;
        private static Stack<FileTreeNode> uiGoForwardFileTreeNode = null;

        #endregion

        #region Init Controller

        /// <summary>
        /// 初始化所有UI组件
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="listView"></param>
        /// <param name="listTextbox"></param>
        /// <param name="richTextBox"></param>
        public static void InitUIController(ref TreeView treeView, ref ListView listView, ref List<TextBox> listTextbox, ref RichTextBox richTextBox, Main frmMain)
        {
            MainLink = frmMain;
            uiTreeNode = treeView;
            uiListView = listView;
            uiListTextBox = listTextbox;
            uiRichTextBox = richTextBox;
            uiStackFileTreeNode = new Stack<FileTreeNode>();
            uiGoForwardFileTreeNode = new Stack<FileTreeNode>();

            //设置几个UI相关的数据
            frmMain.tslUser.Text = BLLControl.GetValidator().VssID;
        }

        /// <summary>
        /// 初始化根节点数据
        /// </summary>
        /// <param name="fileTreeNode"></param>
        public static void InitData(FileTreeNode fileTreeNode)
        {
            BLLControl.SetRoot(fileTreeNode);
            SetFileTreeByObject(fileTreeNode);
            CurrentNode = fileTreeNode.SubNodes[0];
            SetFolderInfoByObject(CurrentNode);
            SetFileInfoByObject(CurrentNode);
            uiStackFileTreeNode.Push(CurrentNode);
        }

        /// <summary>
        /// 初始化三个VssDisk系统文件夹
        /// </summary>
        /// <param name="myShareNode"></param>
        /// <param name="myFocusNode"></param>
        /// <param name="myReceiveNode"></param>
        public static void InitFolder(FileTreeNode myFreeNode, FileTreeNode myShareNode, FileTreeNode myFocusNode, FileTreeNode myReceiveNode)
        {
            FreeFolder = myFreeNode;
            PublishFolder = myShareNode;
            FocusFolder = myFocusNode;
            ReceiveFolder = myReceiveNode;
        }

        #endregion

        #region User Control UI

        /// <summary>
        /// 通用，修改用户当前浏览的文件目录。
        /// </summary>
        /// <param name="fileNode"></param>
        public static void TurnCurrentNode(FileTreeNode fileNode, bool SetStack = true)
        {
            if (fileNode == null)
            {
                return;
            }
            if (SetStack)
            {
                //为后退提供依据，如果相等，则忽略，不会重复入栈。
                if (uiStackFileTreeNode.Count != 0)
                {
                    //Peek使用时，要求栈非空！
                    if (uiStackFileTreeNode.Peek() != fileNode)
                    {
                        uiStackFileTreeNode.Push(fileNode);
                    }
                }
                else
                {
                    uiStackFileTreeNode.Push(fileNode);
                }
            }
            //左侧 Tree 确定范围
            TreeNode treeNode = null;
            foreach (TreeNode node in uiTreeNode.Nodes)
            {
                treeNode = FindNodeInTree(node, fileNode);
                if (treeNode != null)
                {
                    break;
                }
            }
            //找不到选中的树，触发错误。
            if (treeNode == null)
            {
                throw new Exception("不存在指定节点");
            }
            //找到节点
            uiTreeNode.SelectedNode = treeNode;
            //右侧 List 的范围
            SetFolderInfoByObject(fileNode);
            //设置File Info 内容
            SetFileInfoByObject(fileNode);
            //设置最新的当前Node
            CurrentNode = fileNode;
        }

        /// <summary>
        /// 用于在TreeView中寻找某个FileTreeNode的存储节点。
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="fileNode"></param>
        /// <returns></returns>
        private static TreeNode FindNodeInTree(TreeNode treeNode, FileTreeNode fileNode)
        {
            if (treeNode.Tag == (object)fileNode)
            {
                return treeNode;
            }
            foreach (TreeNode node in treeNode.Nodes)
            {
                TreeNode retNode = FindNodeInTree(node, fileNode);
                if (retNode != null)
                {
                    return retNode;
                }
            }
            return null;
        }

        /// <summary>
        /// 内部使用，用于递归。
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="fileNode"></param>
        private static void SetTreeNodeByObject(ref TreeNode treeNode, FileTreeNode fileNode)
        {
            treeNode.Text = fileNode.NodeName;
            treeNode.Tag = fileNode;
            foreach (FileTreeNode subFileNode in fileNode.SubNodes)
            {
                if (subFileNode.SubNodes == null)
                {
                    //这是一个文件
                    continue;
                }
                TreeNode subTreeNode = new TreeNode();
                SetTreeNodeByObject(ref subTreeNode, subFileNode);
                treeNode.Nodes.Add(subTreeNode);
            }
        }

        /// <summary>
        /// 使用根结点来实现目录结构
        /// </summary>
        /// <param name="treeView">树型目录组件的引用</param>
        /// <param name="rootNode">根结点</param>
        private static void SetFileTreeByObject(FileTreeNode rootFileNode)
        {
            TreeNode rootNode = new TreeNode();
            SetTreeNodeByObject(ref rootNode, rootFileNode);
            uiTreeNode.Nodes.Clear();
            foreach (TreeNode node in rootNode.Nodes)
            {
                uiTreeNode.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 显示某个节点的所有下属信息
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="fileNode"></param>
        private static void SetFolderInfoByObject(FileTreeNode fileNode)
        {
            uiListView.Items.Clear();
            foreach (FileTreeNode subNode in fileNode.SubNodes)
            {
                ListViewItem item = new ListViewItem();
                item.Group = uiListView.Groups[(int)subNode.FileKind];
                item.ImageIndex = (int)subNode.FileKind;
                item.Text = subNode.NodeName;
                item.Tag = subNode;
                uiListView.Items.Add(item);
            }

        }

        /// <summary>
        ///  点一个数据然后填充信息
        /// </summary>
        /// <param name="form"></param>
        /// <param name="fileNode"></param>
        public static void SetFileInfoByObject(FileTreeNode fileNode)
        {
            uiListTextBox[0].Text = fileNode.FileID;
            uiListTextBox[1].Text = fileNode.NodeName;
            uiListTextBox[2].Text = ContentKindString[(int)fileNode.FileKind];
            uiListTextBox[3].Text = fileNode.FromApp;
            uiListTextBox[4].Text = fileNode.FileSize.ToString() + "Bytes";
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            startTime = startTime.AddSeconds((double)fileNode.CreateDate);
            uiListTextBox[5].Text = startTime.ToLongDateString() + " " + startTime.ToLongTimeString();
            uiRichTextBox.Text = fileNode.FileInfo;
        }


        #endregion

        #region User Operation



        public static void AddNode(FileTreeNode fileNode)
        {
            //加入当前节点中
            CurrentNode.SubNodes.Add(fileNode);
            //如果是增加一个文件，则不需要处理目录。
            if (fileNode.SubNodes != null)
            {
                //在TreeView中找到当前节点
                TreeNode treeNode = FindNodeInTree(uiTreeNode.TopNode, CurrentNode);
                //找不到选中的树，触发错误。
                if (treeNode == null)
                {
                    throw new Exception("不存在指定节点");
                }
                TreeNode newNode = new TreeNode();
                SetTreeNodeByObject(ref newNode, fileNode);
                treeNode.Nodes.Add(newNode);
            }
            TurnCurrentNode(CurrentNode);
            BLLControl.SaveDirectoryInfo();
        }

        /// <summary>
        /// 在当前目录下新建文件夹
        /// </summary>
        public static void AddNewFolder()
        {
            //获取用户输入
            string folderName = Interaction.InputBox("Please Set A name of new folder.");
            //如果为空，则忽略
            if (folderName == "")
            {
                return;
            }
            //创建一个新的逻辑节点
            FileTreeNode folderNode = new FileTreeNode
            {
                FileID = "0",
                FileKind = ContentKind.Folder,
                FileInfo = "用户自定义文件夹",
                FileSize = 0,
                FromApp = "Vss",
                NodeName = folderName,
                SubNodes = new List<FileTreeNode>()
            };
            //加入当前节点中
            AddNode(folderNode);
        }

        /// <summary>
        /// 修改某个节点的节点名字[文件名或目录名]
        /// </summary>
        /// <param name="fileNode"></param>
        public static void RenameNode(FileTreeNode fileNode)
        {
            if (fileNode == null)
            {
                MessageBox.Show("Please Select A file or folder In ViewList !", "Error");
                return;
            }
            //获取用户输入
            string folderName = Interaction.InputBox("Please Set A name of your selection.");
            //如果为空，则忽略
            if (folderName == "")
            {
                return;
            }
            //首先修改节点名字
            fileNode.NodeName = folderName;
            //设置ListView
            TurnCurrentNode(CurrentNode);
            //如果是文件夹，那么修改TreeView的内容项
            if (fileNode.SubNodes != null)
            {
                //在TreeView中找到当前节点
                TreeNode treeNode = FindNodeInTree(uiTreeNode.TopNode, fileNode);
                treeNode.Text = fileNode.NodeName;
            }
            BLLControl.SaveDirectoryInfo();
        }

        /// <summary>
        /// 删除某个节点
        /// </summary>
        /// <param name="fileNode"></param>
        /// <param name="bAsk"></param>
        public static void DeleteNode(FileTreeNode fileNode, bool bAsk = true)
        {
            if (fileNode == null)
            {
                MessageBox.Show("Please Select A file or folder In ViewList !", "Error");
                return;
            }
            //获取用户输入
            if (bAsk)
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete the selection file or folder ?", "Delete Asking", MessageBoxButtons.YesNo);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
            }
            //确认删除
            //首先从当前节点中删除掉这个节点
            CurrentNode.SubNodes.Remove(fileNode);
            if (fileNode.SubNodes != null)
            {
                //如果是一个文件夹，还需要去TreeView删除对应的TreeNode
                //寻找他的父节点
                TreeNode CurTreeNode = FindNodeInTree(uiTreeNode.TopNode, CurrentNode);
                TreeNode treeNode = FindNodeInTree(uiTreeNode.TopNode, fileNode);
                //删除被删除的节点
                CurTreeNode.Nodes.Remove(treeNode);
            }
            //设置ListView
            TurnCurrentNode(CurrentNode);
            BLLControl.SaveDirectoryInfo();
        }


        public static void ReplaceNodeByFileID(string fileID, FileTreeNode zoneNode, FileTreeNode destNode)
        {
            List<FileTreeNode> list = new List<FileTreeNode>();
            if(zoneNode == null)
            {
                zoneNode = FreeFolder;
            }
            FindNodeByFileID(fileID, zoneNode, list);
            foreach (FileTreeNode node in list)
            {
                node.CreateDate = destNode.CreateDate;
                node.FileInfo = destNode.FileInfo;
                node.FileKind = destNode.FileKind;
                node.FileSize = destNode.FileSize;
                node.FromApp = destNode.FromApp;
            }
            TurnCurrentNode(CurrentNode);
            BLLControl.SaveDirectoryInfo();
        }


        /// <summary>
        /// 遍历目录寻找指定fileID的文件。
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="node"></param>
        /// <param name="list"></param>
        private static void FindNodeByFileID(string fileID, FileTreeNode node, List<FileTreeNode> list)
        {
            if (node.SubNodes == null && node.FileID == fileID)
            {
                list.Add(node);
            }
            if (node.SubNodes != null)
            {
                foreach (FileTreeNode subNode in node.SubNodes)
                {
                    FindNodeByFileID(fileID, subNode, list);
                }
            }
        }

        /// <summary>
        /// 根据指定ID，递归删除文件夹下所有文件!
        /// </summary>
        /// <param name="node"></param>
        /// <param name="fileID"></param>
        private static void DeleteFileByID(FileTreeNode node, string fileID)
        {
            if (node.SubNodes != null)
            {
                List<int> listRemove = new List<int>();
                for (int i = 0; i < node.SubNodes.Count; i++)
                {
                    //如果是一个文件
                    if (node.SubNodes[i].SubNodes == null)
                    {
                        if (node.SubNodes[i].FileID == fileID)
                        {
                            listRemove.Add(i);

                        }
                    }
                    else
                    {
                        //DeleteFileByID(node.SubNodes[i], fileID);
                    }
                }
                foreach (int i in listRemove)
                {
                    node.SubNodes.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// 根据FileID来删除节点
        /// </summary>
        /// <param name="fileID"></param>
        public static void DeleteNodeByFileID(string fileID)
        {
            //从整个目录入手删除节点
            DeleteFileByID(BLLControl.RootFileTree, fileID);
            //从当前浏览页删除节点
            List<FileTreeNode> listNode = new List<FileTreeNode>();
            FindNodeByFileID(fileID, CurrentNode, listNode);
            foreach (FileTreeNode node in listNode)
            {
                CurrentNode.SubNodes.Remove(node);
            }
            TurnCurrentNode(CurrentNode);
            BLLControl.SaveDirectoryInfo();
        }

        /// <summary>
        /// 删除指定节点表示的文件！将破坏所有与此节点文件相关的Provide!
        /// </summary>
        /// <param name="fileNode"></param>
        public static void DestroyNode(FileTreeNode fileNode)
        {
            BLLControl.DestoryFile(fileNode.FileID);
        }

        /// <summary>
        /// 剪贴
        /// </summary>
        /// <param name="fileNode"></param>
        public static void CutNode(FileTreeNode fileNode)
        {
            CutTemp = fileNode;
            DeleteNode(fileNode, false);
            BLLControl.SaveDirectoryInfo();
        }

        /// <summary>
        /// 拷贝
        /// </summary>
        /// <param name="fileNode"></param>
        public static void CopyNode(FileTreeNode fileNode)
        {
            CutTemp = fileNode;
        }

        /// <summary>
        /// 粘帖数据
        /// </summary>
        public static void PasteNode()
        {

            if (CutTemp == null)
            {
                return;
            }
            AddNode((FileTreeNode)CutTemp.Clone());
            BLLControl.SaveDirectoryInfo();
        }

        /// <summary>
        /// 用户执行后退
        /// </summary>
        public static void GoBack()
        {
            if (uiStackFileTreeNode.Count < 2)
            {
                return;
            }
            uiGoForwardFileTreeNode.Push(uiStackFileTreeNode.Pop());
            TurnCurrentNode(uiStackFileTreeNode.Peek(), false);
        }

        /// <summary>
        /// 用户执行前进
        /// </summary>
        public static void GoForward()
        {
            if (uiGoForwardFileTreeNode.Count == 0)
            {
                return;
            }
            FileTreeNode fileNode = uiGoForwardFileTreeNode.Pop();
            TurnCurrentNode(fileNode);
        }


        /// <summary>
        /// 用户执行上传功能
        /// </summary>
        public static void Upload(string fileID = "")
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.Filter = "*.*|*.*";
            DialogResult dr = dia.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string strPath = dia.FileName;
                UploadForm frm = new UploadForm();
                frm.fileID = fileID;
                frm.strUploadPath = strPath;
                frm.Show();
            }
        }

        /// <summary>
        /// 用户执行下载功能
        /// </summary>
        public static void Download(FileTreeNode file)
        {
            SaveFileDialog dia = new SaveFileDialog();
            dia.Filter = "*.*|*.*";
            DialogResult dr = dia.ShowDialog();
            if (dr == DialogResult.OK)
            {
                BLLControl.DownloadFile(dia.FileName, file);
            }
        }

        #endregion

        #region Friends Command

        /// <summary>
        /// 获取朋友列表，填充到ListBox
        /// </summary>
        /// <param name="listBox"></param>
        public static void GetFriends(ref ListBox listBox)
        {
            listBox.Items.Clear();

            List<string> listID = BLLControl.GetFocusList();

            foreach (string s in listID)
            {
                listBox.Items.Add(s);
            }
        }

        /// <summary>
        /// 在朋友消息界面直接操作
        /// </summary>
        /// <param name="strCmd"></param>
        /// <param name="listBox"></param>
        public static void FriendsMessageCommand(string strCmd, ref ListBox listBox)
        {
            List<TFriendMessage> listMsg = (List<TFriendMessage>)listBox.Tag;
            if (listBox.SelectedIndex == -1)
            {
                return;
            }

            TFriendMessage msg = listMsg[listBox.SelectedIndex];

            switch (strCmd)
            {
                case "Accept":
                case "I Invite":
                    {
                        List<string> friList = new List<string>();
                        friList.Add(msg.FromVssID);
                        BLLControl.AddFocus(friList);
                        break;
                    }
                case "Stop Friend":
                    {
                        List<string> friList = new List<string>();
                        friList.Add(msg.FromVssID);
                        BLLControl.DelFocus(friList);
                        break;
                    }
                case "Ignore":
                case "I Know":
                default:
                    {
                        break;
                    }
            }

            BLLControl.DelFriendMessage(msg.MessageID);
        }

        /// <summary>
        /// 选择列表中消息
        /// </summary>
        /// <param name="listBox"></param>
        /// <param name="btnAccept"></param>
        /// <param name="btnIgnore"></param>
        /// <param name="btnKnow"></param>
        public static void SelectFriendsMessage(ref ListBox listBox, ref Button btnAccept, ref Button btnIgnore, ref Button btnKnow)
        {
            List<TFriendMessage> listMsg = (List<TFriendMessage>)listBox.Tag;
            TFriendMessage msg = listMsg[listBox.SelectedIndex];
            btnAccept.Visible = false;
            btnIgnore.Visible = false;
            btnKnow.Visible = false;

            if (msg.Operate == TFriendOperate.Add)
            {
                if (msg.LinkNum == 0)
                {
                    btnAccept.Text = "Accept";
                    btnIgnore.Text = "Ignore";
                    btnAccept.Visible = true;
                    btnIgnore.Visible = true;
                }
                else //LinkNum == 1
                {
                    btnKnow.Text = "I Know";
                    btnKnow.Visible = true;
                }
            }
            else
            {
                if (msg.LinkNum == 1)
                {
                    btnAccept.Text = "I Invite";
                    btnIgnore.Text = "Ignore";
                    btnAccept.Visible = true;
                    btnIgnore.Visible = true;
                }
                else //LinkNum == 2
                {
                    btnAccept.Text = "Stop Friend";
                    btnIgnore.Text = "Ignore";
                    btnAccept.Visible = true;
                    btnIgnore.Visible = true;
                }
            }
        }

        /// <summary>
        /// 获取朋友消息列表
        /// </summary>
        /// <param name="listBox"></param>
        public static void GetFriendsMessage(ref ListBox listBox)
        {
            listBox.Items.Clear();

            List<TFriendMessage> listMsg = BLLControl.GetFriendMessage();
            listBox.Tag = listMsg;



            foreach (TFriendMessage msg in listMsg)
            {
                DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(msg.OperateTime);
                string sItem = dtStart.ToShortDateString() + " " + dtStart.ToShortTimeString() + "  " + msg.FromVssID;
                if (msg.Operate == TFriendOperate.Add)
                {
                    if (msg.LinkNum == 0)
                    {
                        sItem += " Ask You to be Friend . ";
                    }
                    else //LinkNum == 1
                    {
                        sItem += " Accept Your Friend Invite . ";
                    }
                }
                else
                {
                    if (msg.LinkNum == 1)
                    {
                        sItem += " Disable the Friend Invite . ";
                    }
                    else //LinkNum == 2
                    {
                        sItem += " Stop Your Friendship . ";
                    }
                }
                listBox.Items.Add(sItem);
            }
        }

        /// <summary>
        /// 增加新朋友
        /// </summary>
        public static void AddFriend()
        {
            
            string friID = Interaction.InputBox("Input his/her VSSID please:");
            if (friID == "" || friID == BLLControl.GetValidator().VssID)
            {
                return;
            }
            List<string> friList = new List<string>();
            friList.Add(friID);
            BLLControl.AddFocus(friList);
        }

        /// <summary>
        /// 删除朋友
        /// </summary>
        /// <param name="listBox"></param>
        public static void DelFriend(ref ListBox listBox)
        {
            List<string> listFri = new List<string>();
            foreach (string s in listBox.SelectedItems)
            {
                listFri.Add(s);
            }
            BLLControl.DelFocus(listFri);
        }


        #endregion

        #region Provide File

        /// <summary>
        /// 提交授权信息
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="listAdd"></param>
        /// <param name="listDel"></param>
        /// <param name="cbPublish"></param>
        /// <param name="bCurPublish"></param>
        public static void SubmitProvide(string fileID, List<string> listAdd, List<string> listDel, ref CheckBox cbPublish, bool bCurPublish, string provideName)
        {
            if (bCurPublish != cbPublish.Checked)
            {
                //先进行公开授权
                if (cbPublish.Checked)
                {
                    BLLControl.PublishFile(fileID, provideName);
                }
                else
                {
                    BLLControl.RecallFile(fileID);
                }
            }
            //再进行单独授权，不冲突。
            if (listAdd.Count != 0)
            {
                BLLControl.ProvideFile(fileID, listAdd, provideName);
            }
            if (listDel.Count != 0)
            {
                BLLControl.RecoverFile(fileID, listDel);
            }

        }


        /// <summary>
        /// 添加一个VssID的授权
        /// </summary>
        /// <param name="listAdd"></param>
        /// <param name="listDel"></param>
        /// <param name="lbA"></param>
        /// <param name="lbF"></param>
        public static void AddFileProvide(List<string> listAdd, List<string> listDel, ref ListBox lbA, ref ListBox lbF)
        {
            //处理界面
            string sFri = (string)lbA.SelectedItem;
            lbA.Items.Remove(sFri);
            lbF.Items.Add(sFri);
            //如果本来是授权的，被删授权，再被加，那么直接取消删除授权。
            if (listDel.Contains(sFri))
            {
                listDel.Remove(sFri);
            }
            else
            {
                if (!listAdd.Contains(sFri))
                {
                    listAdd.Add(sFri);
                }
            }
        }

        /// <summary>
        /// 取消一个VssID的授权
        /// </summary>
        /// <param name="listAdd"></param>
        /// <param name="listDel"></param>
        /// <param name="lbA"></param>
        /// <param name="lbF"></param>
        public static void DelFileProvide(List<string> listAdd, List<string> listDel, ref ListBox lbA, ref ListBox lbF)
        {
            //处理界面
            string sFri = (string)lbF.SelectedItem;
            lbF.Items.Remove(sFri);
            lbA.Items.Add(sFri);
            //如果本来是没有授权的，被用户操作授权，再取消授权，那么直接取消增加授权。
            if (listAdd.Contains(sFri))
            {
                listAdd.Remove(sFri);
            }
            else
            {
                if (!listDel.Contains(sFri))
                {
                    listDel.Add(sFri);
                }
            }
        }


        /// <summary>
        /// 将数据填充到组件
        /// </summary>
        /// <param name="lbA"></param>
        /// <param name="lbF"></param>
        /// <param name="listA"></param>
        /// <param name="listF"></param>
        public static void FillProvideList(ref ListBox lbA, ref ListBox lbF, ref CheckBox cbPublish, string fileID)
        {
            lbA.Items.Clear();
            lbF.Items.Clear();

            List<string> listFollow = BLLControl.GetFollowList();
            List<string> listProvide = BLLControl.GetFilePrivideList(fileID);

            //If it is Publish
            if (listProvide.Count != 0)
            {
                if (listProvide[0] == "All")
                {
                    cbPublish.Checked = true;
                    listProvide.RemoveAt(0);
                }
                else
                {
                    cbPublish.Checked = false;
                }
            }

            //Fill the All Friends Who is not provided.
            foreach (string fid in listFollow)
            {
                if (!listProvide.Contains(fid))
                {
                    lbA.Items.Add(fid);
                }
            }

            //Fill the vssID who is provided
            foreach (string fid in listProvide)
            {
                lbF.Items.Add(fid);
            }

        }


        /// <summary>
        /// 填充信息
        /// </summary>
        /// <param name="listFriPub"></param>
        /// <param name="listFriPro"></param>
        /// <param name="listMyPub"></param>
        public static void FillProvideMessage(ref ListBox listFriPub, ref ListBox listFriPro, ref ListBox listMyPub)
        {
            //先填充自己的公布
            List<TMessages> list = BLLControl.GetPublishMessage(new List<string>() { BLLControl.GetValidator().VssID }, 500);
            listMyPub.Items.Clear();
            foreach (TMessages msg in list)
            {
                DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(msg.ProvideTime);
                string sItem = dtStart.ToShortDateString() + " " + dtStart.ToShortTimeString() + "  From App : " + msg.FromApp;
                sItem += "  Publish A File : [ " + msg.FileOject.FileId + " ]";
                sItem += " Size : " + msg.FileOject.FileSize + " Kind : " + msg.FileOject.FileKind.ToString();
                listMyPub.Items.Add(sItem);
            }
            //找自己关注的人列表，然后拉取他们的公开发布。
            List<string> listFriend = BLLControl.GetFocusList();
            if (listFriend.Count != 0)
            {
                list = BLLControl.GetPublishMessage(listFriend, 500);
                listFriPub.Items.Clear();
                foreach (TMessages msg in list)
                {
                    DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(msg.ProvideTime);
                    string sItem = dtStart.ToShortDateString() + " " + dtStart.ToShortTimeString() + "  From App : " + msg.FromApp;
                    sItem += "  Publish A File : [ " + msg.FileOject.FileId + " ]";
                    sItem += " Size : " + msg.FileOject.FileSize + " Kind : " + msg.FileOject.FileKind.ToString();
                    listFriPub.Items.Add(sItem);
                }
            }
            //找别人单独授权我的列表
            list = BLLControl.GetProvideMessage(500);
            listFriPro.Items.Clear();
            foreach (TMessages msg in list)
            {
                DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(msg.ProvideTime);
                string sItem = dtStart.ToShortDateString() + " " + dtStart.ToShortTimeString() + "  From App : " + msg.FromApp;
                sItem += "  Publish A File : [ " + msg.FileOject.FileId + " ]";
                sItem += " Size : " + msg.FileOject.FileSize + " Kind : " + msg.FileOject.FileKind.ToString();
                listFriPro.Items.Add(sItem);
            }
        }

        private static FileTreeNode CreateTreeNodeByMessage(TMessages msg)
        {
            FileTreeNode node = new FileTreeNode();
            TFile file = msg.FileOject;
            node.CreateDate = (uint)msg.ProvideTime;
            node.FileID = file.FileId;
            node.FileInfo = file.FileInfo;
            node.FileKind = (ContentKind)file.FileKind;
            node.FileSize = (ulong)file.FileSize;
            node.FromApp = msg.FromApp;
            node.NodeName = msg.ProvideName;
            node.SubNodes = null;
            return node;

        }

        private static bool CompareFileTreeNode(FileTreeNode org, FileTreeNode comp)
        {
            if (org.CreateDate != comp.CreateDate ||
                org.FileID != comp.FileID ||
                org.FileInfo != comp.FileInfo ||
                org.FileKind != comp.FileKind ||
                org.FileSize != comp.FileSize ||
                org.FromApp != comp.FromApp ||
                org.NodeName != comp.NodeName)
            {
                return false;
            }
            if (org.SubNodes == null && comp.SubNodes == null)
            {
                return true;
            }
            if (org.SubNodes != null && comp.SubNodes != null)
            {
                if (org.SubNodes.Count == 0 && comp.SubNodes.Count == 0)
                {
                    return true;
                }
                if (org.SubNodes.Count == comp.SubNodes.Count)
                {
                    for (int cur = 0; cur < org.SubNodes.Count; cur++)
                    {
                        if (!CompareFileTreeNode(org.SubNodes[cur], comp.SubNodes[cur]))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public static void FillFileTreeByTimerLoadingMessage(ref TreeView treeView)
        {

            //先填充自己的公布
            List<TMessages> list = BLLControl.GetPublishMessage(new List<string>() { BLLControl.GetValidator().VssID }, 500);
            List<TMessages> provideItems = BLLControl.GetProvideItems(500);
            list.AddRange(provideItems);
            TreeNode theTreeNode = treeView.Nodes[1];
            PublishFolder.SubNodes.Clear();
            foreach (TMessages msg in list)
            {
                PublishFolder.SubNodes.Add(CreateTreeNodeByMessage(msg));
            }
            //验证数据是否变化，再确定是否替换。
            bool needRefresh = true;
            if (tempPublishFolder != null)
            {
                if (CompareFileTreeNode(tempPublishFolder, PublishFolder))
                {
                    needRefresh = false;
                }
            }
            if (needRefresh)
            {
                theTreeNode.Nodes.Clear();
                SetTreeNodeByObject(ref theTreeNode, PublishFolder);
                tempPublishFolder = (FileTreeNode)PublishFolder.Clone();
            }


            //填充收听表
            Dictionary<string, List<TMessages>> dictMsg;

            List<string> friList = BLLControl.GetFocusList();
            if (friList.Count != 0)
            {
                list = BLLControl.GetPublishMessage(friList, 500);
                dictMsg = new Dictionary<string, List<TMessages>>();
                foreach (TMessages msg in list)
                {
                    if (!dictMsg.ContainsKey(msg.FromVssId))
                    {
                        dictMsg.Add(msg.FromVssId, new List<TMessages>());
                    }
                    dictMsg[msg.FromVssId].Add(msg);
                }
                theTreeNode = treeView.Nodes[2];
                FocusFolder.SubNodes.Clear();
                foreach (string key in dictMsg.Keys)
                {
                    FileTreeNode folder = new FileTreeNode();
                    folder.SubNodes = new List<FileTreeNode>();
                    folder.FileID = "0";
                    folder.FileKind = ContentKind.Folder;
                    folder.FileInfo = key + "'s Folder";
                    folder.FileSize = 0;
                    folder.FromApp = "Vss";
                    folder.NodeName = key;
                    folder.SubNodes = new List<FileTreeNode>();
                    foreach (TMessages msg in dictMsg[key])
                    {
                        folder.SubNodes.Add(CreateTreeNodeByMessage(msg));
                    }
                    FocusFolder.SubNodes.Add(folder);
                }

                //验证数据是否变化，再确定是否替换。
                needRefresh = true;
                if (tempFocusFolder != null)
                {
                    if (CompareFileTreeNode(tempFocusFolder, FocusFolder))
                    {
                        needRefresh = false;
                    }
                }

                if (needRefresh)
                {
                    theTreeNode.Nodes.Clear();
                    SetTreeNodeByObject(ref theTreeNode, FocusFolder);
                    tempFocusFolder = (FileTreeNode)FocusFolder.Clone();
                }

            }


            //下面填充我Receive的列表

            list = BLLControl.GetProvideMessage(500);
            dictMsg = new Dictionary<string, List<TMessages>>();
            foreach (TMessages msg in list)
            {
                if (!dictMsg.ContainsKey(msg.FromVssId))
                {
                    dictMsg.Add(msg.FromVssId, new List<TMessages>());
                }
                dictMsg[msg.FromVssId].Add(msg);
            }
            theTreeNode = treeView.Nodes[3];
            ReceiveFolder.SubNodes.Clear();
            foreach (string key in dictMsg.Keys)
            {
                FileTreeNode folder = new FileTreeNode();
                folder.SubNodes = new List<FileTreeNode>();
                folder.FileID = "0";
                folder.FileKind = ContentKind.Folder;
                folder.FileInfo = key + "'s Folder";
                folder.FileSize = 0;
                folder.FromApp = "Vss";
                folder.NodeName = key;
                folder.SubNodes = new List<FileTreeNode>();
                foreach (TMessages msg in dictMsg[key])
                {
                    folder.SubNodes.Add(CreateTreeNodeByMessage(msg));
                }
                ReceiveFolder.SubNodes.Add(folder);
            }

            //验证数据是否变化，再确定是否替换。
            needRefresh = true;
            if (tempReceiveFolder != null)
            {
                if (CompareFileTreeNode(tempReceiveFolder, ReceiveFolder))
                {
                    needRefresh = false;
                }
            }

            if (needRefresh)
            {
                theTreeNode.Nodes.Clear();
                SetTreeNodeByObject(ref theTreeNode, ReceiveFolder);
                tempReceiveFolder = (FileTreeNode)ReceiveFolder.Clone();
            }


        }

        #endregion



    }
}
