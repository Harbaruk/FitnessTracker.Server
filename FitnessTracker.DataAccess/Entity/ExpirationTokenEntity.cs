using System;

namespace FitnessTracker.DataAccess.Entity
{
    public class ExpirationTokenEntity
    {
        public int UserId { get; set; }
        public DateTimeOffset LastActivityDateTime { get; set; }
    }
}
