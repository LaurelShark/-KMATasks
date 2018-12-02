using DirectoryFileBrowser.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace DirectoryFileBrowser.Views
{
    public partial class SignInView
    {
        #region Construcutor
        public SignInView()
        {
            InitializeComponent();
            var signInViewModel = new SignInViewModel();
            DataContext = signInViewModel;
        }
        #endregion

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
                ((SignInViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;
        }
    }
}
