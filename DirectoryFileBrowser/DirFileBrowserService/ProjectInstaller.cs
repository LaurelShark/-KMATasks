using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace DirectoryFileBrowser.DirFileBrowserService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            var serviceProcessInstaller = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem,
                Password = null,
                Username = null
            };

            var serviceInstaller = new ServiceInstaller
            {
                ServiceName = DirFileBrowserWindowsService.CurrentServiceName,
                DisplayName = DirFileBrowserWindowsService.CurrentServiceDisplayName,
                Description = DirFileBrowserWindowsService.CurrentServiceDescription,
                StartType = ServiceStartMode.Automatic
            };

            Installers.AddRange(new Installer[] { serviceProcessInstaller, serviceInstaller });
        }
    }
}
