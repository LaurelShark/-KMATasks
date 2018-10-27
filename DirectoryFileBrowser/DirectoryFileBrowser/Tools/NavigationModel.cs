using DirectoryFileBrowser.Views;
using DirectoryFileBrowser.Views.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        private WindowTree windowTree;

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.SignIn:
                    //MessageBox.Show("Here");
                    _contentWindow.ContentControl.Content = signInView ?? (signInView = new SignInView());
                    
                    break;
                case ModesEnum.Tree:
                    _contentWindow.ContentControl.Content = windowTree ?? (windowTree = new WindowTree());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
