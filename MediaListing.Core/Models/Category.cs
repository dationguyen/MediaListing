using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MediaListing.Core.Models
{
    public class Category
    {
        [JsonProperty("category")]
        public string Name { get; set; }

        [JsonProperty("items")]
        public List<MediaItem> Items { get; set; }
        public MvxCommand<MediaItem> ItemSelectCommand { get; set; }
    }
}