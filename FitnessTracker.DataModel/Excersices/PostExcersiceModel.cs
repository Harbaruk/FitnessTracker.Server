namespace FitnessTracker.DataModel.Excersices
{
    public class PostExcersiceModel
    {
        public int PlanId { get; set; }
        public int KindOfSport { get; set; }
        public int Type { get; set; }
        public int? Time { get; set; }
        public int? Distance { get; set; }
        public int? Weight { get; set; }
        public int? Amount { get; set; }
    }
}
