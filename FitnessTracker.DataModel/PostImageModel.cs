using Newtonsoft.Json;
using System.IO;

namespace FitnessTracker.DataModel
{
    public class PostImageModel
    {
        [JsonProperty("image")]
        public string ImageUrl { get; set; }
        public string Path { get; set; }
        public string Base64 { get; set; }
        public string FileName { get; set; }
    }
}
