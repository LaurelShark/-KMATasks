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
        }
    }
}
