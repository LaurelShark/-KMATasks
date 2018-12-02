using System.Collections.Generic;

namespace DirectoryFileBrowser
{
    public class DirectoryNode : AbstractNode
    {
        public DirectoryNode(string name, List<AbstractNode> children) : base(name, children) { }

        public override bool IsDirectory()
        {
            return true;
        }
    }
}
