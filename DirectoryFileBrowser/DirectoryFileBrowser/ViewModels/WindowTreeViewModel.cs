using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
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
        private TextBox _filePath; 
        
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

        public TextBox FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
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
            MessageBox.Show("asdf");
            try
            {
                MySqlConnection con = new MySqlConnection(DBManager.DefaultConnectionString);
                con.Open();
                string path = _filePath.Text;
                AbstractNode fileNode = FileUtils.getFileTreeByDirectoryPath(path);
                _mainFileViewNode.Items.Clear();
                TreeViewItem viewNode = buildTreeNode(fileNode);
                _mainFileViewNode.Items.Add(viewNode);
                DateTime dateTime = DateTime.Now;
                string date = dateTime.ToString("yyyy-MM-dd H:mm:ss");
                MySqlCommand ins = new MySqlCommand("INSERT INTO queries(userId, path, date) VALUES (" + id + ",'" + path.Replace("\\", "\\\\") + "', '" + date + "')", con);
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
            finally
            {
                NavigationManager.Instance.Navigate(ModesEnum.Archive);
            }
        }

        private void BrowseFileSystemExecute(object obj) {
            MessageBox.Show("ssssssasdf");
            var fileDialog = new System.Windows.Forms.FolderBrowserDialog();
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.SelectedPath;
                    _filePath.Text = file;
                    _filePath.ToolTip = file;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    _filePath.Text = null;
                    _filePath.ToolTip = null;
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
