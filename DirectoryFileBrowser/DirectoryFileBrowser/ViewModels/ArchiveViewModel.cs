using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DirectoryFileBrowser.ViewModels
{
    class ArchiveViewModel
    {

        #region Commands
        private ICommand _fromArchiveToTreeView;
        #endregion

        #region Commands
        public ICommand FromArchiveToTreeView
        {
            get
            {
                return _fromArchiveToTreeView ?? (_fromArchiveToTreeView = new BindingCommand<object>(FromArchiveToTreeViewExecute, (obj) => true));
            }
        }
        #endregion

        private void FromArchiveToTreeViewExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Tree);
        }
    }
}
