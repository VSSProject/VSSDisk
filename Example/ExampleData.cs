using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VssDisk.Datastruct;

namespace VssDisk.Example
{
    class ExampleData
    {

        /// <summary>
        /// 生成单机测试用例
        /// </summary>
        /// <returns></returns>
        public static FileTreeNode getInitUserFileTree()
        {
            FileTreeNode rootNode = new FileTreeNode
            {
                FileID = "0",
                FileKind = ContentKind.Folder,
                FileInfo = "This is the Root.",
                FileSize = 0,
                FromApp = "Vss",
                NodeName = "RootFolder",
                SubNodes = new List<FileTreeNode>(),
                CreateDate = 0,
                FileOwner = ""
            };

            FileTreeNode myFileNode = new FileTreeNode
            {
                FileID = "0",
                FileKind = ContentKind.Folder,
                FileInfo = "This is for saving your own files.",
                FileSize = 0,
                FromApp = "Vss",
                NodeName = "OwnFolder",
                SubNodes = new List<FileTreeNode>(),
                CreateDate = 0,
                FileOwner = ""
            };


            FileTreeNode myShareNode = new FileTreeNode
            {
                FileID = "0",
                FileKind = ContentKind.Folder,
                FileInfo = "This is for saving what you share to others.",
                FileSize = 0,
                FromApp = "Vss",
                NodeName = "ShareFolder",
                SubNodes = new List<FileTreeNode>(),
                CreateDate = 0,
                FileOwner = ""
            };


            FileTreeNode myFocusNode = new FileTreeNode
            {
                FileID = "0",
                FileKind = ContentKind.Folder,
                FileInfo = "This is for saving Focus 's publish.",
                FileSize = 0,
                FromApp = "Vss",
                NodeName = "FocusFolder",
                SubNodes = new List<FileTreeNode>(),
                CreateDate = 0,
                FileOwner = ""
            };

            FileTreeNode myReceiveNode = new FileTreeNode
            {
                FileID = "0",
                FileKind = ContentKind.Folder,
                FileInfo = "This is for saving other 's sent.",
                FileSize = 0,
                FromApp = "Vss",
                NodeName = "ReceiveFolder",
                SubNodes = new List<FileTreeNode>(),
                CreateDate = 0,
                FileOwner = ""
            };


            rootNode.SubNodes.Add(myFileNode);
            rootNode.SubNodes.Add(myShareNode);
            rootNode.SubNodes.Add(myFocusNode);
            rootNode.SubNodes.Add(myReceiveNode);


            return rootNode;
        }
    }
}
