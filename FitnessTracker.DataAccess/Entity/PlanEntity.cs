using System.Collections.Generic;

namespace FitnessTracker.DataAccess.Entity
{
    public class PlanEntity
    {
        public int Id { get; set; }
        public ICollection<BlockExersiceEntity> Blocks { get; set; }
        public UserProfileEntity Owner { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
    }
}
