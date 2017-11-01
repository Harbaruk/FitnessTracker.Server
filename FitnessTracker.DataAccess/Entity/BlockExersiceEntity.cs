using System.Collections.Generic;

namespace FitnessTracker.DataAccess.Entity
{
    public class BlockExersiceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ExerciseEntity> Exersices { get; set; }
        public PlanEntity Plan { get; set; }
    }
}
