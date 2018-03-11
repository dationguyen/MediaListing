using Newtonsoft.Json;

namespace MediaListing.Core.Models
{
    public class ImageSources
    {
        [JsonProperty("portrait")]
        public string PortraitUrl { get; set; }

        [JsonProperty("landscape")]
        public string LandscapeUrl { get; set; }
    }

}
