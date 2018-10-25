using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class MyMain
    {
        static void Main(string[] args)
        {
            AbstractNode node = FileUtils.getFileTreeByDirectoryPath(@"D:\Andrii\Audiooui");
            AbstractNode node2 = FileUtils.getFileTreeByDirectoryPath(@"D:\Andrii\Audio");
        }
    }
}
