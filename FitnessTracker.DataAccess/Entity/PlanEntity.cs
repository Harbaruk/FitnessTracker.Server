using System.Collections.Generic;

namespace FitnessTracker.DataAccess.Entity
{
    public class PlanEntity
    {
        public int Id { get; set; }
        public ICollection<BlockExersiceEntity> Blocks { get; set; }
        public UserEntity Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public ICollection<UserEntity> Followers { get; set; }
    }
}