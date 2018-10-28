using DirectoryFileBrowser.Models;
using System.Collections.Generic;
using System.Linq;

namespace DirectoryFileBrowser.Managers
{
    class DBManager
    {

        private static string defaultConnectionString = "Server=127.0.0.1;Database=hw01;User ID=root;Password=;SslMode=none;Convert Zero Datetime=True";

        public static string DefaultConnectionString { get { return defaultConnectionString; } }

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
