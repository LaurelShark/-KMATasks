using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DirectoryFileBrowser.ViewModels
{
    public class ArchiveViewModel : INotifyPropertyChanged 
    {

        private ObservableCollection<Query> _myList;

        public ObservableCollection<Query> MyList {
            get { return _myList; }
            set { _myList = value; OnPropertyChanged(); }
        }

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

        internal ArchiveViewModel() {
            init();
        }

        private void FromArchiveToTreeViewExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Tree);
        }

        private void init() {
            //DataTable table = DBManager.GetQueriesForUser(SessionManager.user);
            ObservableCollection<Query> queries = new ObservableCollection<Query>();
            queries.Add(new Query("qweqwe", DateTime.Now));
            queries.Add(new Query("uuuuu", DateTime.Today));
            MyList = queries;
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
