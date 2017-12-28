namespace FitnessTracker.DataModel
{
    public class RecommendedPlanModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Image { get; set; }
        public int OwnerId { get; set; }
        public int Followers { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}