using DirectoryFileBrowser.Managers;
using DirectoryFileBrowser.ViewModels;

namespace DirectoryFileBrowser.Views.Archive
{
    public partial class ArchiveView 
    {
        public ArchiveView()
        {
            InitializeComponent();
            string fullName = SessionManager.User.Name + " " + SessionManager.User.Surname;
            textBlockFullName.Text = fullName;
            var _archiveViewModel = new ArchiveViewModel();
            DataContext = _archiveViewModel;
        }
    }
}
