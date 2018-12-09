﻿using DirectoryFileBrowser.AppServiceInterface;
using DirectoryFileBrowser.DBAdapter;
using DirectoryFileBrowser.Models;

namespace DirectoryFileBrowser.DirFileBrowserService
{
    internal class DirFileBrowserService : IDFBServiceContract
    {
        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public void AddQuery(Query query)
        {
            EntityWrapper.AddQuery(query);
        }

        public void SaveQuery(Query query)
        {
            EntityWrapper.SaveQuery(query);
        }
    }
}
