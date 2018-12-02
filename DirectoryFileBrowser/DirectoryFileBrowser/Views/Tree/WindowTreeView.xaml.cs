using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.ViewModels;
using System.Windows.Controls;

namespace DirectoryFileBrowser.Views.Tree
{
    public partial class WindowTreeView
    {

        private static TreeView treeViewInstance;

        public WindowTreeView()
        {
            InitializeComponent();
            string userName = SessionManager.User.Name + " " + SessionManager.User.Surname;  
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
