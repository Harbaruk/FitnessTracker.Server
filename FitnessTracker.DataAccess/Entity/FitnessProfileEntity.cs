namespace FitnessTracker.DataAccess.Entity
{
    public class FitnessProfileEntity
    {
        public int Id { get; set; }
        public decimal KilometersRun { get; set; }
        public decimal CaloriesBurned { get; set; }
        public int TypeOfDiet { get; set; }
        public int DaysOnDiet { get; set; }
    }
}
