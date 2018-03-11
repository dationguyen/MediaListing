using CoreGraphics;
using MediaListing.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace MediaListing.Views
{
    public partial class ItemDetailPageController:MvxViewController<ItemDetailPageViewModel>
    {
        private const double VERTICAL_SPACING = 10;
        private const double HORIZONTAL_SPACING = 40;

        private const double TITLE_HEIGHT = 40;
        private const double TITLE_FONT_SIZE = 30f;

        private const double IMAGE_RESERVED_HEIGHT = 394;
        private const double IMAGE_RESERVED_WIDTH = 696;
        private const double IMAGE_RATIO = IMAGE_RESERVED_HEIGHT / IMAGE_RESERVED_WIDTH;


        private UILabel _titleLabel;
        private UILabel _yearLabel;
        private UILabel _descriptionLabel;
        private UIImageView _imageView;
        private MvxImageViewLoader _imageViewLoader;


        public ItemDetailPageController() : base("ItemDetailPageController",null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UIInitialize();

            //Binding data
            var set = this.CreateBindingSet<ItemDetailPageController,ItemDetailPageViewModel>();
                set.Bind(this).For(page => page.Title).To(vm => vm.ItemDetail.Title);
                set.Bind(_titleLabel).For(lb => lb.Text).To(vm => vm.ItemDetail.Title);
                set.Bind(_yearLabel).For(lb => lb.Text).To(vm => vm.ItemDetail.Year);
                set.Bind(_descriptionLabel).For(lb => lb.Text).To(vm => vm.ItemDetail.Description);
                set.Bind(_imageViewLoader).For(img => img.ImageUrl).To(item => item.ItemDetail.ImageSources.LandscapeUrl);
            set.Apply();
        }

        private void UIInitialize()
        {
            this.NavigationController.NavigationBar.Translucent = false;
            //this.NavigationController.SetNavigationBarHidden(true,false);

            //get view's boundary size
            var vpHeight = View.Bounds.Height;
            var vpWidth = View.Bounds.Width;

            //init elements
            _titleLabel = new UILabel(new CGRect(HORIZONTAL_SPACING,VERTICAL_SPACING ,vpWidth,TITLE_HEIGHT))
            {
                TextColor = UIColor.Black,
                Font = UIFont.FromName("Helvetica-Light",new nfloat(TITLE_FONT_SIZE))
            };

            _imageView = new UIImageView()
            {
                BackgroundColor = UIColor.Red,
                TranslatesAutoresizingMaskIntoConstraints = false
            };

            _yearLabel = new UILabel()
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                TextColor = UIColor.Black
            };
            _descriptionLabel = new UILabel()
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                TextColor = UIColor.Black,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 5
            };
           
            //set up image view loader
            _imageViewLoader = new MvxImageViewLoader(() => _imageView);
            _imageViewLoader.DefaultImagePath = "res:Default.png";
            _imageViewLoader.ErrorImagePath = "res:Error.png";

            //Add sud views
            View.AddSubviews(_titleLabel,_imageView,_yearLabel,_descriptionLabel);



            //applying contrains

            _imageView.TopAnchor.ConstraintEqualTo(_titleLabel.BottomAnchor,new nfloat(VERTICAL_SPACING)).Active = true;
            _imageView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor,new nfloat(HORIZONTAL_SPACING)).Active = true;
            View.TrailingAnchor.ConstraintEqualTo(_imageView.TrailingAnchor,new nfloat(HORIZONTAL_SPACING)).Active = true;
            _imageView.HeightAnchor.ConstraintEqualTo(_imageView.WidthAnchor,new nfloat(IMAGE_RATIO)).Active = true;

            _yearLabel.TopAnchor.ConstraintEqualTo(_imageView.BottomAnchor,new nfloat(VERTICAL_SPACING)).Active = true;
            View.TrailingAnchor.ConstraintEqualTo(_yearLabel.TrailingAnchor,new nfloat(HORIZONTAL_SPACING)).Active = true;
            _yearLabel.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor,new nfloat(HORIZONTAL_SPACING)).Active = true;

            _descriptionLabel.TopAnchor.ConstraintEqualTo(_yearLabel.BottomAnchor,new nfloat(VERTICAL_SPACING)).Active = true;
            View.TrailingAnchor.ConstraintEqualTo(_descriptionLabel.TrailingAnchor,new nfloat(HORIZONTAL_SPACING)).Active = true;
            _descriptionLabel.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor,new nfloat(HORIZONTAL_SPACING)).Active = true;

        }
    }
}