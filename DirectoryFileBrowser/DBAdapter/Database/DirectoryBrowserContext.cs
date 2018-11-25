using DirectoryFileBrowser.Models;
using System.Data.Entity;
using System.Linq;

namespace DirectoryFileBrowser.Database
{
    public class DirectoryBrowserContext : DbContext
    {
        public DirectoryBrowserContext() : base("DirectoryFileBrowserDB")
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DirectoryBrowserContext, DirectoryFileBrowser.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adds configurations for Student from separate class
            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Entity<User>()
                .ToTable("UsersTable");

            modelBuilder.Entity<User>()
                .MapToStoredProcedures();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Query> Queries { get; set; }
    }
}
