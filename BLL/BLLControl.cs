using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Protocol;
using Thrift.Collections;
using Thrift.Server;
using Thrift.Transport;
using VssDisk.Datastruct;
using Newtonsoft.Json;
using System.IO;
using VssDisk.DAL;
using VssDisk.Example;
using Vss;

namespace VssDisk.BLL
{

    public static class BLLControl
    {

        #region 目录结构

        public static FileTreeNode RootFileTree;

        public static void SetRoot(FileTreeNode rootFileTree)
        {
            RootFileTree = rootFileTree;
        }

        public static void DestoryFile(string fileID)
        {
            ClientAdapt.Open();
            TVssService.Client client = ClientAdapt.GetClient();
            client.Del(GetValidator(), fileID);
            ClientAdapt.Close();
        }

        public static bool SaveDirectoryInfo()
        {
            ClientAdapt.Open();
            TVssService.Client client = ClientAdapt.GetClient();
            TCommandResult tResult = client.SaveFileTree(BLLControl.GetValidator(), JsonConvert.SerializeObject(RootFileTree));
            ClientAdapt.Close();

            return tResult == TCommandResult.SUCCESS;
        }

        public static bool Login(string vssID, string vssPsw, string vssApp)
        {
            ClientAdapt.Open();
            TVssService.Client client = ClientAdapt.GetClient();
            SetValidator(vssID, vssPsw, vssApp);
            TLoginResult tLoginState = client.Login(GetValidator());
            ClientAdapt.Close();
            return tLoginState != TLoginResult.SUCCESS;
        }

        public static FileTreeNode InitFileTree()
        {
            //进行通信，拉取用户的数据。
            ClientAdapt.Open();
            TVssService.Client client = ClientAdapt.GetClient();
            string strTree = client.GetFileTree(GetValidator());
            ClientAdapt.Close();
            if (strTree == "None")
            {
                return ExampleData.getInitUserFileTree();

            }
            else
            {
                return JsonConvert.DeserializeObject<FileTreeNode>(strTree);
            }
        }

        #endregion

        #region 验证信息

        private static TValidator tValidator = null;

        public static void SetValidator(string vssID, string vssPsw, string vssAPP)
        {
            tValidator = new TValidator(vssID, vssPsw, vssAPP);
        }

        public static TValidator GetValidator()
        {
            return tValidator;
        }

        #endregion

        #region 文件系统存取


        public static FileTreeNode UploadTextFile(string sContent, string nodeName ,string strID, string strInfo, ContentKind cKind, string strApp)
        {
            TFile file = new TFile();
            file.FileContent = System.Text.Encoding.UTF8.GetBytes(sContent);
            file.FileId = strID;
            file.FileInfo = strInfo;
            file.FileKind = (TContentKind)cKind;
            file.FileSize = file.FileContent.Length;
            file.FromApp = strApp;
            file.FileOwner = GetValidator().VssID;
            ClientAdapt.Open();
            TVssService.Client client = ClientAdapt.GetClient();
            string strNewID = client.Put(GetValidator(), file);
            ClientAdapt.Close();

            FileTreeNode fileTreeNode = new FileTreeNode();
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            fileTreeNode.CreateDate = (uint)(DateTime.Now - startTime).TotalSeconds;
            fileTreeNode.FileID = strNewID;
            fileTreeNode.FileInfo = strInfo;
            fileTreeNode.FileKind = cKind;
            fileTreeNode.FileSize = (ulong)file.FileContent.Length;
            fileTreeNode.FromApp = strApp;
            fileTreeNode.SubNodes = null;
            fileTreeNode.FileOwner = GetValidator().VssID;
            fileTreeNode.NodeName = nodeName;

            return fileTreeNode;
        }




        /// <summary>
        /// 上传一个文件，返回节点描述符。
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public static FileTreeNode UploadFile(string sPath, string strID, string strInfo, ContentKind cKind, string strApp)
        {
            TFile file = new TFile();
            file.FileContent = File.ReadAllBytes(sPath);
            FileStream fs = File.OpenRead(sPath);
            file.FileId = strID;
            file.FileInfo = strInfo;
            file.FileKind = (TContentKind)cKind;
            file.FileSize = fs.Length;
            file.FromApp = strApp;
            file.FileOwner = GetValidator().VssID;
            ClientAdapt.Open();
            TVssService.Client client = ClientAdapt.GetClient();
            string strNewID = client.Put(GetValidator(), file);
            ClientAdapt.Close();

            FileTreeNode fileTreeNode = new FileTreeNode();
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            fileTreeNode.CreateDate = (uint)(DateTime.Now - startTime).TotalSeconds;
            fileTreeNode.FileID = strNewID;
            fileTreeNode.FileInfo = strInfo;
            fileTreeNode.FileKind = cKind;
            fileTreeNode.FileSize = (ulong)fs.Length;
            fileTreeNode.FromApp = strApp;
            fileTreeNode.SubNodes = null;
            fileTreeNode.FileOwner = GetValidator().VssID;
            fileTreeNode.NodeName = fs.Name.Substring(fs.Name.LastIndexOf("\\") + 1);

            return fileTreeNode;
        }

        /// <summary>
        /// 下载一个文件，返回描述符。
        /// </summary>
        /// <param name="sPath"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static TFile DownloadFile(string sPath, FileTreeNode file)
        {
            string strFID = file.FileID;

            ClientAdapt.Open();
            TVssService.Client client = ClientAdapt.GetClient();
            TFile tFile = client.Get(GetValidator(), strFID);
            ClientAdapt.Close();
            File.WriteAllBytes(sPath, tFile.FileContent);

            return tFile;
        }


        #endregion

        #region 朋友管理


        /// <summary>
        /// 获取朋友列表（单向）
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFocusList()
        {

            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            List<string> retList = client.GetFocus(GetValidator());

            ClientAdapt.Close();

            return retList;
        }

        /// <summary>
        /// 获得关注我的朋友的列表（单向指我）
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFollowList()
        {
            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            List<string> retList = client.GetFollow(GetValidator());

            ClientAdapt.Close();

            return retList;
        }

        /// <summary>
        /// 获取朋友列表（单向）
        /// </summary>
        /// <returns></returns>
        public static List<TFriendMessage> GetFriendMessage()
        {

            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            List<TFriendMessage> retList = client.GetFriendMessage(GetValidator(), 100);

            ClientAdapt.Close();

            return retList;
        }

        /// <summary>
        /// 删除指定ID的朋友消息。
        /// </summary>
        /// <param name="strMsgID"></param>
        public static void DelFriendMessage(string strMsgID)
        {
            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            client.DelFriendMessage(GetValidator(), strMsgID);

            ClientAdapt.Close();
        }

        /// <summary>
        /// 添加朋友列表（单向）会自动判断名字是否正确，如果不正确，则不加入！但不返回错误！
        /// </summary>
        /// <param name="list"></param>
        public static void AddFocus(List<string> list)
        {

            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            TCommandResult res = client.AddFocus(GetValidator(), list);

            ClientAdapt.Close();

        }

        /// <summary>
        /// 删除朋友列表（单向）会自动判断名字，不正确则忽略！
        /// </summary>
        /// <param name="list"></param>
        public static void DelFocus(List<string> list)
        {

            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            TCommandResult res = client.DelFocus(GetValidator(), list);

            ClientAdapt.Close();


        }

        #endregion

        #region 授权管理

        /// <summary>
        /// 根据FileID ,获得列表。
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public static List<string> GetFilePrivideList(string fileID)
        {

            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            List<string> retList = client.GetFileProvideList(GetValidator(), fileID);

            ClientAdapt.Close();

            return retList;
        }

        /// <summary>
        /// 授权一系列朋友访问某一文件
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="listFriends"></param>
        public static void ProvideFile(string fileID, List<string> listFriends, string provideName)
        {
            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            client.Provide(GetValidator(), fileID, listFriends, provideName);

            ClientAdapt.Close();

        }


        /// <summary>
        /// 取消一系列朋友对某一个文件的访问授权
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="listFriends"></param>
        public static void RecoverFile(string fileID, List<string> listFriends)
        {
            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            client.Recover(GetValidator(), fileID, listFriends);

            ClientAdapt.Close();

        }

        /// <summary>
        /// 公开某一个文件
        /// </summary>
        /// <param name="fileID"></param>
        public static void PublishFile(string fileID, string provideName)
        {
            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            client.Provide(GetValidator(), fileID, new List<string>(), provideName);

            ClientAdapt.Close();
        }

        /// <summary>
        /// 取消公开某一个文件
        /// </summary>
        /// <param name="fileID"></param>
        public static void RecallFile(string fileID)
        {
            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            client.Recover(GetValidator(), fileID, new List<string>());

            ClientAdapt.Close();
        }

        /// <summary>
        /// 获取我发布给别人的
        /// </summary>
        /// <param name="maxNum"></param>
        /// <returns></returns>
        public static List<TMessages> GetProvideItems(int maxNum)
        {

            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            List<TMessages> retList = client.GetProvideItems(GetValidator(), maxNum);

            ClientAdapt.Close();

            return retList;

        }


        /// <summary>
        /// 获取指定用户们的公开消息
        /// </summary>
        /// <param name="listID"></param>
        /// <param name="maxNum"></param>
        /// <returns></returns>
        public static List<TMessages> GetPublishMessage(List<string> listID, int maxNum)
        {

            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            List<TMessages> retList = client.GetPublishMessage(GetValidator(), listID, maxNum);

            ClientAdapt.Close();

            return retList;

        }

        /// <summary>
        /// 获取被授权消息
        /// </summary>
        /// <param name="listID"></param>
        /// <param name="maxNum"></param>
        /// <returns></returns>
        public static List<TMessages> GetProvideMessage(int maxNum)
        {

            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            List<TMessages> retList = client.GetProvideMessage(GetValidator(), maxNum);

            ClientAdapt.Close();

            return retList;

        }


        #endregion

        #region 消息管理

        /// <summary>
        /// 获取用户的几个内容量集
        /// </summary>
        /// <returns></returns>
        public static TNumber GetNumber()
        {
            ClientAdapt.Open();

            TVssService.Client client = ClientAdapt.GetClient();

            TNumber tNumber = client.GetNumber(GetValidator());

            ClientAdapt.Close();

            return tNumber;
        }

        #endregion

    }
}
