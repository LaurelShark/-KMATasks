﻿using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Tools;
using System;
using System.IO;

namespace DirectoryFileBrowser.Managers
{
    class SessionManager
    {
        #region Fields
        public static User user;
        public static Query query;
        #endregion

        #region Properties
        public static User CurrentUser { get; set; }
        #endregion


        static SessionManager()
        {
            DeserializeLastUser();
        }

        private static void DeserializeLastUser()
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
    }
}
