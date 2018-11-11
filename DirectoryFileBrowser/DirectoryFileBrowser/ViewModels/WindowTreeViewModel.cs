﻿using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
using DirectoryFileBrowser.Views.Tree;
using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
        private ICommand _logOut;
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
        public ICommand LogoutCommand
        {
            get
            {
                return _logOut ?? (_logOut = new BindingCommand<object>(LogOutExecute, (obj) => true));
            }
        }
        public ICommand StartSearchCommand
        {
            get
            {
                return _startSearchCommand ?? (_startSearchCommand = new BindingCommand<object>(StartSearchExecute, (obj) => true));
            }
        }

        public ICommand ShowPathsCommand
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

        private async void LogOutExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var res = await Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(1000);
                    FileFolderHelper.FileDelete((string)FileFolderHelper.LogFilepath);
                } catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                return true;                
            });
            LoaderManager.Instance.HideLoader();
            MessageBox.Show("successfully logged out");
            NavigationManager.Instance.Navigate(ModesEnum.SignIn);
        }

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
                NavigationManager.Instance.Navigate(ModesEnum.Archive);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
