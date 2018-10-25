using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryFileBrowser
{
    class FileUtils
    {
        public static AbstractNode getFileTreeByDirectoryPath(string path) {
            DirectoryInfo info = new DirectoryInfo(path);
            if (info.Exists)
                return new DirectoryNode(path, buildFileTree(info));
            else
                return null;
        }

        private static List<AbstractNode> buildFileTree(DirectoryInfo directory) {
            IEnumerable<DirectoryNode> dirs = directory.GetDirectories()
                .Select(dir => new DirectoryNode(dir.Name, buildFileTree(dir)));
            IEnumerable<FileNode> files = directory.GetFiles()
                .Select(file => new FileNode(file.Name));
            return dirs.Concat<AbstractNode>(files)
                .ToList();
        }
    }
}
