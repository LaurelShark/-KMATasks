using DirectoryFileBrowser.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DirectoryFileBrowser.ViewModels
{
    class WindowTreeViewModel
    {

        #region Commands
        private ICommand _startSearchCommand;
        private ICommand _showPathsCommand;
        private ICommand _browseFileSystemCommand;
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
                MessageBox.Show("Here");
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ShowPathsExecute(object obj) { }

        private void BrowseFileSystemExecute(object obj) { }

    }
}
