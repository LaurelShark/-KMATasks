using DirectoryFileBrowser.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryFileBrowser.Database
{

    public class DirectoryFileBrowserDbInitializer : DropCreateDatabaseAlways<DirectoryBrowserContext>
    {
        protected override void Seed(DirectoryBrowserContext context)
        {
            IList<User> users = new List<User>();

            users.Add(new User()
            {
                Name = "Taras",
                Surname = "Shevchenko",
                Email = "taras@gmail.com",
                Login = "tar",
                Password = "1234"
            });
            users.Add(new User()
            {
                Name = "Maryna",
                Surname = "Tsvetayeva",
                Email = "maryne@gmail.com",
                Login = "maryna",
                Password = "666"
            });
            

            context.Users.AddRange(users);

            base.Seed(context);
        }
    }
}
