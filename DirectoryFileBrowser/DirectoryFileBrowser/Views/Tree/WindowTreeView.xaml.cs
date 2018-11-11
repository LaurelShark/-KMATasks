using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
using DirectoryFileBrowser.ViewModels;
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

        private static TreeView treeViewInstance;

        public WindowTreeView()
        {
            InitializeComponent();
            string userName = SessionManager.user.Name + " " + SessionManager.user.Surname;  
            textBlockFullName.Text = userName;
            var windowTreeViewModel = new WindowTreeViewModel();
            DataContext = windowTreeViewModel;
            treeViewInstance = mainFileViewNode;
        }

        public static void PopulateUITree(TreeViewItem viewNode) {
            treeViewInstance.Items.Clear();
            treeViewInstance.Items.Add(viewNode);
        }
    }
}
