using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Managers;
using MySql.Data;
using System.Windows;
using DirectoryFileBrowser.Tools;

namespace DirectoryFileBrowser.ViewsModels.Authentication
{
    class SignInViewModel : INotifyPropertyChanged
    {

        #region ConstructorAndInit
        internal SignInViewModel(){}
        #endregion

        #region Fields
        private string login;
        private string password;
        

        #region Commands
        private ICommand signInCommand;
        #endregion
        #endregion

        #region Properties
        public string Login
        {
            get
            {
                return login;
            }
            private set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            private set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        

        #region Commands
        public ICommand SignInCommand
        {
            get
            {
        // TODO what is RelayCommand & implement methods
                return signInCommand ?? (signInCommand = new RelayCommand<object>(SignInExecute, SignInCanExecute));
            }
        }
        #endregion
        #endregion

        public void SignInExecute(object obj)
        {
            User currentUser;
            try
            {
                currentUser = DBManager.GetUserByLogin(login);
            }
            catch(Exception)
            {
                MessageBox.Show("Exception with getting user with such login " + login);
                return;
            }
            if (currentUser == null)
            {
                MessageBox.Show("Such user doesn't exist in database!");
            }
            try
            {
                if (!currentUser.CheckPassword(password))
                {
                    MessageBox.Show("Wrong password");
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private bool SignInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(login) && !String.IsNullOrWhiteSpace(password);
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
       
    }
}