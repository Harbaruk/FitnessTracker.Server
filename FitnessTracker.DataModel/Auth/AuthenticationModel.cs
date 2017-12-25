using System;

namespace FitnessTracker.DataModel
{
    public class AuthenticationModel
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Sex { get; set; }
        public int Height { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public string Password { get; set; }
    }
}