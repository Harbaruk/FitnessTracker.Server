using FitnessTracker.DataAccess.Entity;
using System.Data.Entity.ModelConfiguration;

namespace FitnessTracker.DataAccess.Configuration
{
    public class FitnessProfileConfiguration : EntityTypeConfiguration<FitnessProfileEntity>
    {
        public FitnessProfileConfiguration()
        {
            ToTable("Profiles");

            HasKey(x => x.Id);
            Property(x => x.CaloriesBurned);
            Property(x => x.DaysOnDiet);
            Property(x => x.KilometersRun);
            Property(x => x.TypeOfDiet);
        }
    }
}
