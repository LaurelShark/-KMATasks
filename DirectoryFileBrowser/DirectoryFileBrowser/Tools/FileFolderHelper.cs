using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryFileBrowser.Tools
{
    internal static class FileFolderHelper
    {
        private static readonly string AppDataPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        internal static readonly string ClientFolderPath =
            Path.Combine(AppDataPath, "DirectoryFileBrowser");

        internal static readonly string LogFolderPath =
            Path.Combine(ClientFolderPath, "Log");

        internal static readonly string LogFilepath = Path.Combine(LogFolderPath,
            "App_" + DateTime.Now.ToString("YYYY_MM_DD") + ".txt");

        internal static readonly string StorageFilePath =
            Path.Combine(ClientFolderPath, "Storage.dfb");

        internal static readonly string LastUserFilePath =
            Path.Combine(ClientFolderPath, "LastUser.dfb");

        internal static void CheckAndCreateFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                if (!file.Exists)
                {
                    file.Create().Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}