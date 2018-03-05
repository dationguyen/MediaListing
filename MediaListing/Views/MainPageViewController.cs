using System;
using CoreGraphics;
using MediaListing.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace MediaListing.Views
{
    public partial class MainPageViewController : MvxViewController<MainPageViewModel>
    {
        public MainPageViewController() : base("MainPageViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            View.BackgroundColor = UIColor.White;
            Title = "Media listing";

            var table = new UITableView();


            //var btn = UIButton.FromType(UIButtonType.System);
            //btn.Frame = new CGRect(20, 200, 280, 44);
            //btn.SetTitle("Click Me", UIControlState.Normal);

            //var user = new UIViewController();
            //user.View.BackgroundColor = UIColor.Magenta;

            //btn.TouchUpInside += (sender, e) => {
            //    this.NavigationController.PushViewController(user, true);
            //};

            //View.AddSubview(btn);
           
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

