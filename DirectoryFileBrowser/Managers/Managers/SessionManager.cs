﻿using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Tools;
using System;
using System.IO;

namespace DirectoryFileBrowser.Managers
{
    public class SessionManager
    {
        #region Fields
        private static User user;
        #endregion

        #region Properties
        public static User User {
            get { return user; }
            set { user = value; }
        }
        #endregion

        public static void DeserializeLastUser()
        {
            try
            {
                User = SerializationManager.Deserialize<User>(FileFolderHelper.LastUserFilePath);
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to Deserialize last user", ex);
            }
        }

        public static void SerializeCurrentUser() {
            try
            {
                SerializationManager.Serialize<User>(User, FileFolderHelper.LastUserFilePath);
                Logger.Log("User was serialized");
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to serialize last user", ex);
            }
        }

        public static bool IsLastSessionActive() {
            return FileFolderHelper.LastUserFile.Exists;
        }

        public static void DestroyLastSession()
        {
            try
            {
                if (IsLastSessionActive())
                {
                    FileFolderHelper.LastUserFile.Delete();
                }
            }
            catch (IOException ex)
            {
                Logger.Log("Failed to delete last user autologin file", ex);
            }
        }
    }
}
