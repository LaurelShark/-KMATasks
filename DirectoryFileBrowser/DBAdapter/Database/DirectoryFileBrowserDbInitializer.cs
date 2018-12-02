using DirectoryFileBrowser.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace DirectoryFileBrowser.Database
{

    public class DirectoryFileBrowserDbInitializer : CreateDatabaseIfNotExists<DirectoryBrowserContext>
    {
        protected override void Seed(DirectoryBrowserContext context)
        {
            IList<User> users = new List<User>();
            base.Seed(context);
        }
    }
}
