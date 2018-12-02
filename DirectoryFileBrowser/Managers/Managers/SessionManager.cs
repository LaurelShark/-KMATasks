using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Tools;
using System;
using System.IO;

namespace DirectoryFileBrowser.Managers
{
    public class SessionManager
    {
        #region Fields
        public static User user; // TODO merge is with Current User
        #endregion

        #region Properties
        public static User CurrentUser { get; set; }
        #endregion

        public static void DeserializeLastUser()
        {
            User userCandidate;
            try
            {
                userCandidate = SerializationManager.Deserialize<User>(Path.Combine(FileFolderHelper.LastUserFilePath));
            }
            catch (Exception ex)
            {
                userCandidate = null;
                Logger.Log("Failed to Deserialize last user", ex);
            }
            if (userCandidate == null)
            {
                Logger.Log("User was not deserialized");
                return;
            }
            userCandidate = DBManager.CheckCachedUser(userCandidate);
            if (userCandidate == null)
                Logger.Log("Failed to relogin last user");
            else
                CurrentUser = userCandidate;
        }

        private static FileInfo GetSessionFileInfo() {
            FileInfo file = new FileInfo(Path.Combine(FileFolderHelper.LastUserFilePath));
            return file;
        }

        public static bool IsLastSessionFinished() {
            return ! GetSessionFileInfo().Exists;
        }

        public static void DestroyLastSession() {
            if (IsLastSessionFinished())
            {
                GetSessionFileInfo().Delete();
            }
        }
    }
}
