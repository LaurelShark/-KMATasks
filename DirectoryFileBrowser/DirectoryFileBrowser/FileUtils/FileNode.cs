namespace DirectoryFileBrowser
{
    public class FileNode : AbstractNode
    {
        public FileNode(string name) : base(name) { }

        public override bool IsDirectory()
        {
            return false;
        }
    }
}
