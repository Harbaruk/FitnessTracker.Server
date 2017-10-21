using FitnessTracker.DataAccess.Entity;
using System.Data.Entity.ModelConfiguration;

namespace FitnessTracker.DataAccess.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            ToTable("Users");

            HasKey(x => x.Id);

            Property(x => x.Firstname);
            Property(x => x.Lastname);
            Property(x => x.Password).IsRequired();
            Property(x => x.Salt);
            Property(x => x.Role);

            HasRequired(x => x.Profile);
        }
    }
}
