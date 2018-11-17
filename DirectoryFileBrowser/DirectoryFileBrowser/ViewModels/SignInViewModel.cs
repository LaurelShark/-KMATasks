using DirectoryFileBrowser.Database;
using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
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

        public string Password { private get { return _password; } set { _password = value; OnPropertyChanged(); } }
        #endregion

        #region Commands
        public ICommand SignInCommand {
            get { return _signInCommand ?? (_signInCommand = new BindingCommand<object>(SignInExecute, SignInCanExecute)); }
        }

        public ICommand ExitCommand
        {
            get { return _exitCommand ?? (_exitCommand = new BindingCommand<object>(ExitExecute, (obj) => true)); }
        }

        public object NavigationManagers { get; private set; }
        #endregion


        private bool SignInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password);
        }

        private async void SignInExecute(object obj) {
            LoaderManager.Instance.ShowLoader();
            var res = await Task.Run(() =>
            {
                User currUser;
                try
                {
                    Thread.Sleep(1000);
                    currUser = DBManager.GetUserByLogin(_login);
                    DBManager.AddUser(currUser);
                    Logger.Log("Logged in. Session new started");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    Logger.Log("Login failed", e);
                    return false;
                }
                if (currUser == null)
                {
                    Logger.Log("User doesnt exist");
                    MessageBox.Show("User doesnt exist");
                    return false;
                }
                try
                {
                    if (!currUser.PasswordMatch(_password))
                    {
                        Logger.Log("Passwords do not match");
                        MessageBox.Show("Wrong password");
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Logger.Log("Password validation error!", e);
                    MessageBox.Show("Password validation error!", e.Message);
                    return false;
                }
                DBManager.UpdateLoggedInDateToCurrent(currUser);
                SessionManager.user = currUser;
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (res) {
                Password = "";
                Login = "";
                NavigationManager.Instance.Navigate(ModesEnum.Tree);
            }
        }

        private void ExitExecute(object obj)
        {
            using (var ctx = new DirectoryBrowserContext())
            {
                try { 
                var student = new User() { Name = "Bill" };

                
                ctx.Users.Add(student);
                ctx.SaveChanges();
                }catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            Logger.Log("Exit execute");
            MessageBox.Show("ShutDown");
            //Environment.Exit(1);
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
