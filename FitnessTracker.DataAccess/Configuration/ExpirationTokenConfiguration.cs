using FitnessTracker.DataAccess.Entity;
using System.Data.Entity.ModelConfiguration;

namespace FitnessTracker.DataAccess.Configuration
{
    public class ExpirationTokenConfiguration : EntityTypeConfiguration<ExpirationTokenEntity>
    {
        public ExpirationTokenConfiguration()
        {
            ToTable("ExpirationTokens");

            HasKey(x => x.UserId);

            Property(x => x.LastActivityDateTime)
                .IsRequired();
        }
    }
}
