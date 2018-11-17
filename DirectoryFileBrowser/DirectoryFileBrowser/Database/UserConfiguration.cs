using DirectoryFileBrowser.Models;
using System.Data.Entity.ModelConfiguration;

namespace DirectoryFileBrowser.Database
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            //this.Property(s => s.Name)
            //    .IsConcurrencyToken(); 

            // Configure a one-to-one relationship between Student & StudentAddress
            //this.HasOptional(s => s.Queries) // Mark Student.Address property optional (nullable)
            //    .WithRequired(query => query.UserAuthor); // Mark StudentAddress.Student property as required (NotNull).
        }
    }
}
