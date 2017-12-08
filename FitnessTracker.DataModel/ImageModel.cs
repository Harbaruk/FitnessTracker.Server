using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.DataModel
{
    public class ImageModel
    {
        [JsonProperty("image")]
        public string Image { get; set; }
        public string Path { get; set; }
    }
}
