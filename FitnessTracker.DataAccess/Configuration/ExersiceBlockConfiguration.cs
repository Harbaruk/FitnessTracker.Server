using FitnessTracker.DataAccess.Entity;
using System.Data.Entity.ModelConfiguration;

namespace FitnessTracker.DataAccess.Configuration
{
    public class ExersiceBlockConfiguration : EntityTypeConfiguration<BlockExersiceEntity>
    {
        public ExersiceBlockConfiguration()
        {
            ToTable("ExersiceBlocks");

            HasKey(x => x.Id);

            Property(x => x.Name);
            HasRequired(x => x.Plan);
        }
    }
}
