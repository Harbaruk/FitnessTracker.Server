using System;

namespace FitnessTracker.DataModel.Excersices
{
    public class MyExcersicesModel
    {
        public int Id { get; set; }
        public int KindOfSport { get; set; }
        public int Type { get; set; }
        public int? Time { get; set; }
        public int? Distance { get; set; }
        public int? Weight { get; set; }
        public int? Amount { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
