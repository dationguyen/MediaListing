using Newtonsoft.Json;

namespace MediaListing.Core.Models
{
    public class MediaItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("images")]
        public ImageSources ImageSources { get; set; }
    }
}