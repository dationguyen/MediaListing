using MediaListing.Core.Models;
using MvvmCross.Core.ViewModels;

namespace MediaListing.Core.ViewModels
{
    public class ItemDetailPageViewModel:MvxViewModel<MediaItem>
    {

        public MediaItem ItemDetail { get; set; }


        public override void Prepare(MediaItem item)
        {
            ItemDetail = item;
        }
    }
}
