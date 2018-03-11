using Foundation;
using MediaListing.Views.Cells;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MediaListing.Views.DataSources
{
    public class MediaViewSource:MvxCollectionViewSource
    {
        private static readonly NSString MediaItemViewCellIdentifier = new NSString("MediaItemViewCell");

        private bool _isHorizontal;

        public MediaViewSource(UICollectionView collectionView,bool isHorizontal = false) : base(collectionView)
        {
            _isHorizontal = isHorizontal;
            collectionView.RegisterNibForCell(UINib.FromName("MediaItemViewCell",NSBundle.MainBundle),
                MediaItemViewCellIdentifier);
        }

        protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView,NSIndexPath indexPath,object item)
        {
            var cell = (MediaItemViewCell)collectionView.DequeueReusableCell(MediaItemViewCellIdentifier,indexPath);
            cell.IsLandscape = _isHorizontal;
            return cell;
        }
    }
}