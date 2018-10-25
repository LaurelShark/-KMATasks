using DirectoryFileBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryFileBrowser.Managers
{
    class DBManager
    {
        private static List<User> Users = new List<User>();

        public static bool userExists(string login)
        {
            return Users.Any(u => u.Login == login);
        }

        public static User GetUserByLogin(string login)
        {
            return Users.FirstOrDefault(u => u.Login == login);
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
