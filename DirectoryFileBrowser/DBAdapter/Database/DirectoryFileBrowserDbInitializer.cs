using DirectoryFileBrowser.Models;
using DirectoryFileBrowser.Tools;
using System.Collections.Generic;
using System.Data.Entity;

namespace DirectoryFileBrowser.Database
{

    public class DirectoryFileBrowserDbInitializer : CreateDatabaseIfNotExists<DirectoryBrowserContext>
    {
        protected override void Seed(DirectoryBrowserContext context)
        {
            IList<User> users = new List<User>();

            /*
            User taras = new User()
            {
                Name = "Taras",
                Surname = "Shevchenko",
                Email = "taras@gmail.com",
                Login = "tar",
                Password = Encrypting.ConvertToMd5("1234")
            };
            users.Add(taras);
            User maryna = new User()
            {
                Name = "Maryna",
                Surname = "Tsvetayeva",
                Email = "maryne@gmail.com",
                Login = "maryna",
                Password = Encrypting.ConvertToMd5("666")
            };
            users.Add(maryna);
            IList<Query> queries = new List<Query>();
            queries.Add(new Query() {
                User = taras,
                Path = "D:\\\\music"
            });
            queries.Add(new Query()
            {
                User = taras,
                Path = "D:\\\\audio"
            });
            queries.Add(new Query()
            {
                User = maryna,
                Path = "C:\\\\poetry"
            });

            

            context.Users.AddRange(users);
            context.Queries.AddRange(queries);
            */
            base.Seed(context);
        }
    }
}
