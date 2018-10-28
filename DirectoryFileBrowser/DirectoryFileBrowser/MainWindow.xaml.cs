using System.Windows;
using System.Windows.Controls;
using DirectoryFileBrowser.Tools;
using DirectoryFileBrowser.Managers;

namespace DirectoryFileBrowser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            navigationModel.Navigate(ModesEnum.SignIn);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}