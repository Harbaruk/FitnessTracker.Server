using System.Collections.Generic;

namespace FitnessTracker.DataAccess.Entity
{
    public class UserProfileEntity
    {
        public int UserId { get; set; }
        public decimal? Weight { get; set; }
        public int Height { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }

        public ICollection<PlanEntity> Plans { get; set; }
    }
}
