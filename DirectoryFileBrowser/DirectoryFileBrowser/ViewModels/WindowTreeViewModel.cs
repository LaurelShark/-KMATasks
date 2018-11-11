using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
using DirectoryFileBrowser.Views.Tree;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DirectoryFileBrowser.ViewModels
{
    internal class WindowTreeViewModel : INotifyPropertyChanged
    { 

        #region Fields
        int id = SessionManager.user.Id;
        private TreeView _mainFileViewNode;
        private string _dirPath; 
        
        #endregion

        #region Commands
        private ICommand _startSearchCommand;
        private ICommand _showPathsCommand;
        private ICommand _browseFileSystemCommand;
        #endregion

        #region Constructors

        #endregion

        #region Properites
        public TreeView MainFileViewNode
        {
            get { return _mainFileViewNode; }
            set { _mainFileViewNode = value; OnPropertyChanged(); }
        }

        public string DirPath
        {
            get { return _dirPath; }
            set
            {
                _dirPath = value; OnPropertyChanged();
            }
        }
         
        #endregion

        #region Commands
        public ICommand StartSearchCommand
        {
            get
            {
                return _startSearchCommand ?? (_startSearchCommand = new BindingCommand<object>(StartSearchExecute, (obj) => true));
            }
        }

        public ICommand ShowPathsComand
        {
            get
            {
                return _showPathsCommand ?? (_showPathsCommand = new BindingCommand<object>(ShowPathsExecute, (obj) => true));
            }
        }

        public ICommand BrowseFileSystemCommand
        {
            get
            {
                return _browseFileSystemCommand ?? (_browseFileSystemCommand = new BindingCommand<object>(BrowseFileSystemExecute, (obj) => true));
            }
        }
        #endregion

        private void StartSearchExecute(object obj)
        {
            try
            {
                string path = DirPath;
                AbstractNode fileNode = FileUtils.getFileTreeByDirectoryPath(path);
                DBManager.WriteQueryForUser(SessionManager.user, path.Replace("\\", "\\\\"));
                TreeViewItem viewNode = BuildTreeViewItem(fileNode);
                WindowTreeView.PopulateUITree(viewNode);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private TreeViewItem BuildTreeViewItem(AbstractNode fileNode)
        {
            TreeViewItem viewNode = new TreeViewItem();
            viewNode.Header = fileNode.Name;
            if (fileNode.isDirectory())
            {
                Action<AbstractNode> addFileNodeToViewNode = node => viewNode.Items.Add(BuildTreeViewItem(node));
                fileNode.Children.ForEach(addFileNodeToViewNode);
            }
            return viewNode;
        }

        private void ShowPathsExecute(object obj) {
            try
            {
                MySqlConnection con = new MySqlConnection(DBManager.DefaultConnectionString);
                con.Open();
                MySqlCommand userQueries = new MySqlCommand("SELECT id, path, date FROM queries WHERE userId = " + id, con);
                userQueries.CommandType = CommandType.Text;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = userQueries;
                userQueries.ExecuteNonQuery();
                DataTable dt = new DataTable("Queries");
                adapter.Fill(dt);
               // dataGrid.ItemsSource = dt.DefaultView;
                adapter.Update(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            NavigationManager.Instance.Navigate(ModesEnum.Archive);
        }

        private void BrowseFileSystemExecute(object obj) {
            var fileDialog = new System.Windows.Forms.FolderBrowserDialog();
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.SelectedPath;
                    DirPath = file;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    DirPath = "";
                    break;
            }
        }

        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
