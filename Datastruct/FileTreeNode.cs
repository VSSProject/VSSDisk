using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VssDisk.Datastruct
{

    public enum ContentKind
    {
        Folder,
        BinaryFile,
        Weibo,
        ShortMessage,
        Picture,
        Music,
        Movie,
        Email
    };

    public class FileTreeNode : ICloneable
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID { get; set; }

        /// <summary>
        /// 子结点，如果为空，表示是一个文件！
        /// </summary>
        public IList<FileTreeNode> SubNodes { get; set; }

        /// <summary>
        /// 文件类别
        /// </summary>
        public ContentKind FileKind { get; set; }

        /// <summary>
        /// 如果这个节点是个文件节点，则表示文件名。如果是个目录节点，表示目录名！
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 来自哪个APP
        /// </summary>
        public string FromApp { get; set; }

        /// <summary>
        /// 文件的大小
        /// </summary>
        public ulong FileSize { get; set; }

        /// <summary>
        /// 文件简单摘要
        /// </summary>
        public string FileInfo { get; set; }

        /// <summary>
        /// 文件所属人
        /// </summary>
        public string FileOwner { get; set; }

        /// <summary>
        /// 文件创建时间（即上传时间）
        /// </summary> 
        public uint CreateDate { get; set; }


        public object Clone()
        {
            FileTreeNode fileTreeNode = new FileTreeNode()
            {
                CreateDate = this.CreateDate,
                FileID = this.FileID,
                FileInfo = this.FileInfo,
                FileKind = this.FileKind,
                FileSize = this.FileSize,
                FromApp = this.FromApp,
                NodeName = this.NodeName,
                SubNodes = this.SubNodes,
                FileOwner = this.FileOwner
            };
            //判断是否是一个文件夹
            if (fileTreeNode.SubNodes != null)
            {
                fileTreeNode.SubNodes = new List<FileTreeNode>();
                foreach (FileTreeNode subNode in this.SubNodes)
                {
                    fileTreeNode.SubNodes.Add((FileTreeNode)subNode.Clone());
                }
            }
            return fileTreeNode;
        }
    }
}
