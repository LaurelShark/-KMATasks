using DirectoryFileBrowser.Database;
using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DirectoryFileBrowser.Managers
{
    public class DBManager
    {
        private static List<User> Users = new List<User>();

        static DBManager()
        {
            Users = SerializationManager.Deserialize<List<User>>(FileFolderHelper.StorageFilePath) ?? new List<User>();
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = Users.FirstOrDefault(u => u.UserId == userCandidate.UserId);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static bool UserExists(string login)
        {
            return Users.Any(u => u.Login == login);
        }

        private static readonly string defaultConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dfb.mdf;Integrated Security=True";

        internal static string DefaultConnectionString { get { return defaultConnectionString; } }

        public static void AddUser(User user)
        {
            Users.Add(user);
            SaveChanges();
        }

        public static void CreateNewUser(User user)
        {
            using (var context = new DirectoryBrowserContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

            private static void SaveChanges()
        {
            SerializationManager.Serialize(Users, FileFolderHelper.StorageFilePath);
        }

        public static User GetUserByLogin(string login)
        {
            using (var context = new DirectoryBrowserContext()) {
                var queryResult = from u in context.Users
                                  where u.Login == login
                                  select u;
                return queryResult.FirstOrDefault();
            }
        }

        public static void UpdateLoggedInDateToCurrent(User user) {
            using (var context = new DirectoryBrowserContext())
            {
                var queryResult = from u in context.Users
                                  where u.UserId == user.UserId
                                  select u;
                var foundUser = queryResult.First();
                foundUser.LastLoginDate = DateTime.Now;
                context.SaveChanges();
            }
        } 

        public static void WriteQueryForUser(User user, string dirPath) {
            using (var context = new DirectoryBrowserContext())
            {
                var query = new Query
                {
                    UserId = user.UserId,
                    Path = dirPath
                };
                context.Queries.Add(query);
                context.SaveChanges();
            }  
        }

        public static IEnumerable<Query> GetQueriesForUser(User user) {
            using (var context = new DirectoryBrowserContext())
            {
                var queryResult = from q in context.Queries
                                  where q.User.UserId == user.UserId
                                  select q;
                return queryResult.AsEnumerable().ToList();
            }

        }

    }
}
