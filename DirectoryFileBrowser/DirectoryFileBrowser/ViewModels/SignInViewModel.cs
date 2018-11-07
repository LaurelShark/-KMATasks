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
using System.Windows.Input;

namespace DirectoryFileBrowser.ViewModels
{
    class SignInViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _login;
        private string _password;
        #endregion

        #region Commands
        private ICommand _signInCommand;
        private ICommand _exitCommand;
        #endregion

        #region Properties
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Password { private get { return _password; } set { _password = value;  } }

        public ICommand SignInCommand {
            get { return _signInCommand ?? (_signInCommand = new BindingCommand<object>(SignInExecute, SignInCanExecute)); }
        }

        public ICommand ExitInCommand
        {
            get { return _exitCommand ?? (_exitCommand = new BindingCommand<object>(ExitExecute, (obj) => true)); }
        }

        public object NavigationManagers { get; private set; }
        #endregion

        private bool SignInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password);
        }

        private void SignInExecute(object obj) {
            MessageBox.Show("Sign in");
        }

        private void ExitExecute(object obj)
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
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
