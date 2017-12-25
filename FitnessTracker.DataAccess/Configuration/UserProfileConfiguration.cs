using FitnessTracker.DataAccess.Entity;
using System.Data.Entity.ModelConfiguration;

namespace FitnessTracker.DataAccess.Configuration
{
    public class UserProfileConfiguration : EntityTypeConfiguration<UserProfileEntity>
    {
        public UserProfileConfiguration()
        {
            ToTable("UserProfiles");

            HasKey(x => x.UserId);
            Property(x => x.Age);
            Property(x => x.Height);
            Property(x => x.Sex);
            Property(x => x.Weight);
        }
    }
}