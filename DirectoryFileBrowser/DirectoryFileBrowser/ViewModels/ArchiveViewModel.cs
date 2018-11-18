using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DirectoryFileBrowser.ViewModels
{
    public class ArchiveViewModel : INotifyPropertyChanged 
    {

        private ObservableCollection<ViewableQuery> _queriesHistory;

        public ObservableCollection<ViewableQuery> QueriesHistory {
            get { return _queriesHistory; }
            set { _queriesHistory = value; }
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
            Logger.Log("Initializing history query view");
            QueriesHistory = new ObservableCollection<ViewableQuery>();
            populateDataGrid();
        }

        private void FromArchiveToTreeViewExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.Tree);
        }

        private void populateDataGrid() {
            Logger.Log("Populating query history...");
            IEnumerable<Query> queries = DBManager.GetQueriesForUser(SessionManager.user);
            foreach (Query q in queries)
            {
                string path = q.Path;
                DateTime date = q.Date;
                QueriesHistory.Add(new ViewableQuery(path, date));
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
