using FitnessTracker.DataAccess.Entity;
using System.Data.Entity.ModelConfiguration;

namespace FitnessTracker.DataAccess.Configuration
{
    public class ExerciseConfiguration : EntityTypeConfiguration<ExerciseEntity>
    {
        public ExerciseConfiguration()
        {
            ToTable("Exercises");

            HasKey(x => x.Id);
            Property(x => x.Amount);
            Property(x => x.Distance);
            Property(x => x.KindOfSport);
            Property(x => x.Time);
            Property(x => x.Type);
            Property(x => x.Weight);

            HasRequired(x => x.Block);
        }
    }
}
