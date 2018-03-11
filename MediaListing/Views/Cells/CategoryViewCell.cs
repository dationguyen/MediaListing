using CoreGraphics;
using Foundation;
using MediaListing.Core.Models;
using MediaListing.Views.DataSources;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System;
using UIKit;

namespace MediaListing.Views.Cells
{
    public partial class CategoryViewCell:MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("CategoryViewCell");
        public static readonly UINib Nib;

        private const double HORIZONTAL_MARGIN = 20f;
        private const double VERTICAL_MARGIN = 20f;
        private const double TITLE_SIZE = 30f;
        private const double LANDSCAPE_ITEM_HEIGHT = 153;
        private const double LANDSCAPE_ITEM_WIDTH = 200;
        private const double PORTRAIT_ITEM_HEIGHT = 215;
        private const double PORTRAIT_ITEM_WIDTH = 117;


        private UILabel _lTitle;
        private UICollectionView _collectionView;
        private bool _isLandscape;

        static CategoryViewCell()
        {
            Nib = UINib.FromName("CategoryViewCell",NSBundle.MainBundle);
        }

        private UICollectionViewFlowLayout CollectionViewFlowLayout => (UICollectionViewFlowLayout)_collectionView?.CollectionViewLayout;

        public bool IsLandscape
        {
            get { return _isLandscape; }
            set
            {
                _isLandscape = value;


                if(IsLandscape)
                {
                    CollectionViewFlowLayout.ItemSize = new CGSize(LANDSCAPE_ITEM_WIDTH,LANDSCAPE_ITEM_HEIGHT);
                    _collectionView.Frame = new CGRect(HORIZONTAL_MARGIN,VERTICAL_MARGIN + TITLE_SIZE,Bounds.Width - HORIZONTAL_MARGIN * 2,LANDSCAPE_ITEM_HEIGHT);
                }
                else
                {
                    CollectionViewFlowLayout.ItemSize = new CGSize(PORTRAIT_ITEM_WIDTH,PORTRAIT_ITEM_HEIGHT);
                    _collectionView.Frame = new CGRect(HORIZONTAL_MARGIN,VERTICAL_MARGIN + TITLE_SIZE,Bounds.Width - HORIZONTAL_MARGIN * 2,PORTRAIT_ITEM_HEIGHT);

                }

            }
        }

        private void UIInitialize()
        {
            _lTitle = new UILabel(new CGRect(HORIZONTAL_MARGIN,VERTICAL_MARGIN / 2,this.Bounds.Width - HORIZONTAL_MARGIN * 2,TITLE_SIZE))
            {
                Font = UIFont.FromName("Helvetica-Light",new nfloat(TITLE_SIZE))
            };

            var layout = new UICollectionViewFlowLayout()
            {
                MinimumLineSpacing = 12,
                ScrollDirection = UICollectionViewScrollDirection.Horizontal
            };

            _collectionView = new UICollectionView(CGRect.Empty,layout)
            {
                BackgroundColor = UIColor.Clear,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth
            };

            this.ContentView.AddSubviews(_lTitle,_collectionView);

            ContentView.BottomAnchor.ConstraintEqualTo(_collectionView.BottomAnchor,new nfloat(VERTICAL_MARGIN)).Active = true;
            ContentView.TopAnchor.ConstraintEqualTo(_lTitle.TopAnchor,-new nfloat(VERTICAL_MARGIN / 2)).Active = true;

            _collectionView.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor,new nfloat(HORIZONTAL_MARGIN)).Active = true;
            _collectionView.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor,new nfloat(HORIZONTAL_MARGIN)).Active = true;



        }

        protected CategoryViewCell(IntPtr handle) : base(handle)
        {

            UIInitialize();
            // Note: this .ctor should not contain any initialization logic.
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<CategoryViewCell,Category>();
                set.Bind(_lTitle).For(l => l.Text).To(cat => cat.Name);

                var source = new MediaViewSource(_collectionView,IsLandscape);
                set.Bind(source).For(s => s.ItemsSource).To(cat => cat.Items);
                _collectionView.Source = source;
                set.Bind(source).For(s => s.SelectionChangedCommand).To(cat => cat.ItemSelectCommand);
                set.Apply();
            });
        }


    }
}
