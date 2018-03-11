using CoreGraphics;
using Foundation;
using MediaListing.Core.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System;
using UIKit;

namespace MediaListing.Views.Cells
{
    public partial class MediaItemViewCell:MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("MediaItemViewCell");
        public static readonly UINib Nib;



        public readonly CGRect LandscapeFrame = new CGRect(0,0,200,113);
        public readonly CGRect PortraitFrame = new CGRect(0,0,200,113);
        private const double ITEM_SPACING = 10f;

        //UI Elements
        private MvxImageViewLoader _imageViewLoader;
        private UIImageView _imageView;
        private UILabel _lTitle;
        private bool _isLandscape;

        public bool IsLandscape
        {
            get { return _isLandscape; }
            set
            {
                _isLandscape = value;
                if(IsLandscape)
                {
                    _imageView.Frame = new CGRect(0,0,200,113);
                }
                else
                {
                    _imageView.Frame = new CGRect(0,0,117,175);
                }
            }
        }

        static MediaItemViewCell()
        {
            Nib = UINib.FromName("MediaItemViewCell",NSBundle.MainBundle);
        }

        protected MediaItemViewCell(IntPtr handle) : base(handle)
        {

            UIInitiazation();

            //Binding data for cell
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MediaItemViewCell,MediaItem>();

                set.Bind(_lTitle).For(l => l.Text).To(item => item.Title);

                //setup image loader
                _imageViewLoader = new MvxImageViewLoader(() => _imageView);
                _imageViewLoader.DefaultImagePath = "res:Default.png";
                _imageViewLoader.ErrorImagePath = "res:Error.png";

                //check binding resource base on type
                if(IsLandscape)
                {
                    set.Bind(_imageViewLoader).For(img => img.ImageUrl).To(item => item.ImageSources.LandscapeUrl);
                }
                else
                {
                    set.Bind(_imageViewLoader).For(img => img.ImageUrl).To(item => item.ImageSources.PortraitUrl);
                }

                set.Apply();
            });
        }


        private void UIInitiazation()
        {
            //initialize
            _imageView = new UIImageView()
            {
                ContentMode = UIViewContentMode.ScaleAspectFill,
                ClipsToBounds = true
            };
            _lTitle = new UILabel()
            {
                TextColor = UIColor.Black,
                TranslatesAutoresizingMaskIntoConstraints = false,
                LineBreakMode = UILineBreakMode.TailTruncation
            };

            //add to subview
            this.ContentView.AddSubviews(_imageView,_lTitle);

            //applying contrains
            _lTitle.TopAnchor.ConstraintEqualTo(_imageView.BottomAnchor,new nfloat(ITEM_SPACING)).Active = true;
            _lTitle.WidthAnchor.ConstraintEqualTo(ContentView.WidthAnchor).Active = true;
        }

    }
}