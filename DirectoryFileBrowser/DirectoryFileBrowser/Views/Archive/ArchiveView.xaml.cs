using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.Tools;
using DirectoryFileBrowser.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace DirectoryFileBrowser.Views.Archive
{
    /// <summary>
    /// Логика взаимодействия для ArchiveView.xaml
    /// </summary>
    public partial class ArchiveView 
    {
        int id = SessionManager.user.Id;
        string fullName = SessionManager.user.Name + " " + SessionManager.user.Surname;
        public ArchiveView()
        {
            InitializeComponent();
            textBlockFullName.Text = fullName;
            var _archiveViewModel = new ArchiveViewModel();
            DataContext = _archiveViewModel;
        }
        /*
            
        */

        private void button_Click(object sender, RoutedEventArgs e)
        {
           // NavigationManager.Instance.Navigate(ModesEnum.Tree);
        }
    }
}
