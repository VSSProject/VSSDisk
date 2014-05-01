using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VssDisk.BLL;
using Newtonsoft.Json;
using VssDisk.Datastruct;
using VssDisk.UI;


namespace VssDisk
{
    public partial class UploadForm : Form
    {
        public UploadForm()
        {
            InitializeComponent();
        }

        public string strUploadPath;
        public Main frmMain;
        public string fileID = "";

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            FileTreeNode file = null;

            //针对直接上传图片，却选择的是微博类型的情况做的特殊处理。
            do
            {
                if (strUploadPath.Substring(strUploadPath.LastIndexOf('.') + 1).ToLower() == "jpg")
                {
                    if (cbFileKind.Text == "Weibo")
                    {
                        file = BLLControl.UploadFile(strUploadPath, fileID, txtFileInfo.Text, ContentKind.Picture, "VssDisk");
                        break;
                    }
                }

                //正常情况
                file = BLLControl.UploadFile(strUploadPath, fileID, txtFileInfo.Text, (ContentKind)(cbFileKind.SelectedIndex + 1), "VssDisk");
                break;
            }
            while (true);


            //如果是上传不是替换
            if (fileID == "")
            {
                UIController.AddNode(file);
            }
            else
            {
                UIController.ReplaceNodeByFileID(fileID, null, file);
            }

            //如果上传的是一张图片
            if (strUploadPath.Substring(strUploadPath.LastIndexOf('.') + 1).ToLower() == "jpg")
            {
                if (cbFileKind.Text == "Weibo")
                {

                    BlogMsg blog = new BlogMsg();

                    blog.strUin = BLLControl.GetValidator().VssID;
                    blog.strFromClient = BLLControl.GetValidator().AppID;
                    blog.strObjPicUrl = file.FileID;
                    blog.strMsgID = "";
                    blog.strNickName = "";
                    blog.strContent = "";
                    DateTime dt = DateTime.Now;
                    blog.strWriteDate = dt.Year + "年" + dt.Month + "月" + dt.Day + "日 " + dt.Hour + ":" + dt.Minute + ":" + dt.Second;
                    blog.strObjKind = "None";

                    blog.imgHeadSrc = "";
                    file = BLLControl.UploadTextFile(JsonConvert.SerializeObject(blog), strUploadPath.Substring(strUploadPath.LastIndexOf("\\") + 1), "", txtFileInfo.Text, (ContentKind)(cbFileKind.SelectedIndex + 1), "VssDisk");
                    blog.strMsgID = file.FileID;
                    file = BLLControl.UploadTextFile(JsonConvert.SerializeObject(blog), strUploadPath.Substring(strUploadPath.LastIndexOf("\\") + 1), file.FileID, txtFileInfo.Text, (ContentKind)(cbFileKind.SelectedIndex + 1), "VssDisk");
                    UIController.AddNode(file);

                }
            }

            this.Close();
        }

        private void UploadForm_Load(object sender, EventArgs e)
        {
            cbFileKind.SelectedIndex = 0;
        }

    }
}