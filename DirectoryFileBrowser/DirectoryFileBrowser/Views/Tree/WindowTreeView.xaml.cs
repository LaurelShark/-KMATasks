using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace DirectoryFileBrowser.Views.Tree
{
    /// <summary>
    /// Логика взаимодействия для WindowTree.xaml
    /// </summary>
    public partial class WindowTreeView
    {
        int id = SessionManager.user.Id;
        public WindowTreeView()
        {
            InitializeComponent();
            string userName = SessionManager.user.Name + " " + SessionManager.user.Surname;  
            textBlockFullName.Text = userName;
        }

        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            
            */
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

        private void showHistory_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Archive);
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new System.Windows.Forms.FolderBrowserDialog();
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.SelectedPath;
                    filePath.Text = file;
                    filePath.ToolTip = file;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    filePath.Text = null;
                    filePath.ToolTip = null;
                    break;
            }
        }
    }
}
