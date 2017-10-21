using System;

namespace FitnessTracker.DataModel
{
    public class ExpirationTokenModel
    {
        public int UserId { get; set; }
        public DateTimeOffset LastActivityDateTime { get; set; }
    }
}
