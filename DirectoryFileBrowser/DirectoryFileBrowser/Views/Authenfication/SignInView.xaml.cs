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

        private void LabelAndPasswordControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void LabelAndPasswordControl_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
