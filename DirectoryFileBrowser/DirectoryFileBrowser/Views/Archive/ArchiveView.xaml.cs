﻿using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.ViewModels;

namespace DirectoryFileBrowser.Views.Archive
{
    public partial class ArchiveView 
    {
        int id = SessionManager.user.UserId;
        string fullName = SessionManager.user.Name + " " + SessionManager.user.Surname;
        public ArchiveView()
        {
            InitializeComponent();
            textBlockFullName.Text = fullName;
            var _archiveViewModel = new ArchiveViewModel();
            DataContext = _archiveViewModel;
        }
    }
}
