using System.Collections.Generic;

namespace DirectoryFileBrowser
{
    public abstract class AbstractNode
    {
        public string Name
        {
            get;
            private set;
        }

        private List<AbstractNode> _children;

        public List<AbstractNode> Children
        {
            get { return new List<AbstractNode>(_children); }
            private set { _children = value; }
        }

        public AbstractNode(string name, List<AbstractNode> children = null)
        {
            Name = name;
            Children = children ?? new List<AbstractNode>();
        }

        public abstract bool IsDirectory();
    }
}
