using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public object NavigationManagers { get; private set; }
        #endregion



        private bool SignInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password);
        }

        private void ExitCommand(object obj)
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
