using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DirectoryFileBrowser.ViewModels
{
    class MainWindowViewModel : ILoaderOwner
    {

        #region Fields
        private Visibility _visibility = Visibility.Hidden;
        private bool _isEnabled = true;
        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
        #endregion

        internal void StartApplication()
        {
            NavigationManager.Instance.Navigate(SessionManager.user != null ? throw new Exception() : ModesEnum.SignIn);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
