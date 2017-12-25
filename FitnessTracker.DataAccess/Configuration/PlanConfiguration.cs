using FitnessTracker.DataAccess.Entity;
using System.Data.Entity.ModelConfiguration;

namespace FitnessTracker.DataAccess.Configuration
{
    public class PlanConfiguration : EntityTypeConfiguration<PlanEntity>
    {
        public PlanConfiguration()
        {
            ToTable("Plans");

            HasKey(x => x.Id);

            Property(x => x.Type);
            HasRequired(x => x.Owner);
            HasMany(x => x.Blocks);
            HasMany(x => x.Followers);
        }
    }
}