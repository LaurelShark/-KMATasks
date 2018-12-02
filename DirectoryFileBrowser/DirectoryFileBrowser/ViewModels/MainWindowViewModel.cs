﻿using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
            if (SessionManager.IsLastSessionFinished())
            {
                Logger.Log("Manual login");
                NavigationManager.Instance.Navigate(ModesEnum.SignIn);
            }
            else
            {
                Logger.Log("Auto login: previous session was not finished");
                SessionManager.DeserializeLastUser();
                NavigationManager.Instance.Navigate(ModesEnum.Tree);
            }
        }

        public void LogoutCommand()
        {
            MessageBox.Show("logout");
            Logger.Log("Logged out. Session should be destroyed");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
