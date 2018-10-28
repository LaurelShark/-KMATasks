using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            try
            {
                MySqlConnection con = new MySqlConnection(DBManager.DefaultConnectionString);
                con.Open();
                string path = filePath.Text;
                AbstractNode fileNode = FileUtils.getFileTreeByDirectoryPath(path);
                mainFileViewNode.Items.Clear();
                TreeViewItem viewNode = buildTreeNode(fileNode);
                mainFileViewNode.Items.Add(viewNode);  
                DateTime dateTime = DateTime.Now;
                string date = dateTime.ToString("yyyy-MM-dd H:mm:ss");
                MySqlCommand ins = new MySqlCommand("INSERT INTO query(userId, path, date) VALUES (" + id + ",'" + path.Replace("\\", "\\\\") + "', '" + date + "')", con);
                ins.CommandType = CommandType.Text;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.InsertCommand = ins;
                ins.ExecuteNonQuery();
                con.Close();
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

        private void showHistory_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Archive);
        }
    }
}
