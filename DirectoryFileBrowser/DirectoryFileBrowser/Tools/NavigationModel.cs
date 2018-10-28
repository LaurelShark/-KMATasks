using DirectoryFileBrowser.Views;
using DirectoryFileBrowser.Views.Archive;
using DirectoryFileBrowser.Views.Tree;
using System;

namespace DirectoryFileBrowser.Tools
{
    internal enum ModesEnum
    {
        SignIn,
        Tree,
        Archive
    }

    internal class NavigationModel
    {
        // write other fields
        private readonly IContentWindow _contentWindow;
        private SignInView signInView;
        private WindowTreeView windowTreeView;
        private ArchiveView archiveView;

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.SignIn:
                    _contentWindow.ContentControl.Content = signInView ?? (signInView = new SignInView());
                    
                    break;
                case ModesEnum.Tree:
                    _contentWindow.ContentControl.Content = windowTreeView ?? (windowTreeView = new WindowTreeView());
                    break;

                case ModesEnum.Archive:
                    _contentWindow.ContentControl.Content = archiveView ?? (archiveView = new ArchiveView());
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
