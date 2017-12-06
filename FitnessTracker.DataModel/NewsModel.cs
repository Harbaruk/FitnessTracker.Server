using Newtonsoft.Json;
using System;

namespace FitnessTracker.DataModel
{
    public class NewsModel
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonProperty("urlToImage")]
        public string Image { get; set; }
        public string Url { get; set; }
        [JsonProperty("publishedAt")]
        public DateTime At { get; set; }
    }
}
