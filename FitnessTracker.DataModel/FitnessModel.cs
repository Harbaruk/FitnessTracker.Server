using Newtonsoft.Json;

namespace FitnessTracker.DataModel
{
    public class FitnessModel
    {
        public int Id { get; set; }
        [JsonProperty("kilometers_run")]
        public decimal KilometersRun { get; set; }
        [JsonProperty("calories_burned")]
        public decimal CaloriesBurned { get; set; }
        [JsonProperty("type_of_diet")]
        public int TypeOfDiet { get; set; }
        [JsonProperty("days_on_diet")]
        public int DaysOnDiet { get; set; }
    }
}
