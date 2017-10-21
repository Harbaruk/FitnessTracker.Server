namespace FitnessTracker.DataModel.Exercises
{
    public class UpdateExerciseModel
    {
        public int PlanId { get; set; }
        public int Id { get; set; }
        public int KindOfSport { get; set; }
        public int Type { get; set; }
        public int? Time { get; set; }
        public int? Distance { get; set; }
        public int? Weight { get; set; }
        public int? Amount { get; set; }
    }
}
