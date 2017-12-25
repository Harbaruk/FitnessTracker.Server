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

            Property(x => x.Image);

            HasRequired(x => x.Profile);
            HasMany(x => x.Plans).WithRequired(x => x.Owner);
            HasMany(x => x.Followed);
        }
    }
}