using System.Windows;
using System.Windows.Controls;
using DirectoryFileBrowser.Tools;
using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.ViewModels;

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
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            mainWindowViewModel.StartApplication();
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