using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    public class DirectoryNode : AbstractNode
    {
        public DirectoryNode(string name, List<AbstractNode> children) : base(name, children) { }

        public override bool isDirectory()
        {
            return true;
        }
    }
}
