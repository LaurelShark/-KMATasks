using DirectoryFileBrowser.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryFileBrowser.Tools
{
    internal enum ModesEnum
    {
        SignIn,
        Main,
        Tree,
        Archive
    }

    internal class NavigationModel
    {
        // write other fields
        private readonly IContentWindow _contentWindow;
        private SignInView signInView;

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
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
