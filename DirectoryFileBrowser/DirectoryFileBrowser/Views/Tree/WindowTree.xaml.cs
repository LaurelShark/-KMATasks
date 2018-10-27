using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DirectoryFileBrowser.Views.Tree
{
    /// <summary>
    /// Логика взаимодействия для WindowTree.xaml
    /// </summary>
    public partial class WindowTree : Window
    {
        public WindowTree()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = filePath.Text;
                AbstractNode fileNode = FileUtils.getFileTreeByDirectoryPath(path);
                mainFileViewNode.Items.Clear();
                TreeViewItem viewNode = buildTreeNode(fileNode);
                mainFileViewNode.Items.Add(viewNode);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private TreeViewItem buildTreeNode(AbstractNode fileNode)
        {
            TreeViewItem viewNode = new TreeViewItem();
            viewNode.Header = fileNode.Name;
            if (fileNode.isDirectory())
            {
                Action<AbstractNode> addFileNodeToViewNode = node => viewNode.Items.Add(buildTreeNode(node));
                fileNode.Children.ForEach(addFileNodeToViewNode);
            }
            return viewNode;
        }
    }
}
