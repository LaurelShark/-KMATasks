using DirectoryFileBrowser.Database;
using DirectoryFileBrowser.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryFileBrowser.DBAdapter
{
    public static class EntityWrapper
    {
        public static bool UserExists(string login)
        {
            using (var context = new DirectoryBrowserContext())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var context = new DirectoryBrowserContext())
            {
                return context.Users.Include(u => u.Query).FirstOrDefault(u => u.Login == login);
            }
        }

        public static void AddUser(User user)
        {
            using (var context = new DirectoryBrowserContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void AddQuery(Query query)
        {
            using (var context = new DirectoryBrowserContext())
            {
                query.DeleteDatabaseValues();
                context.Queries.Add(query);
                context.SaveChanges();
            }
        }

        public static void SaveQuery(Query query)
        {
            using (var context = new DirectoryBrowserContext())
            {
                context.Entry(query).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /*
        public static void DeleteQuery(Query selectedQuery)
        {
            using (var context = new DirectoryBrowserContext())
            {
                selectedQuery.DeleteDatabaseValues();
                context.Queries.Attach(selectedQuery);
                context.Queries.Remove(selectedQuery);
                context.SaveChanges();
            }
        }
        */
    }
}
