using CoreGraphics;
using MediaListing.Core.ViewModels;
using MediaListing.Views.DataSources;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace MediaListing.Views
{
    public partial class MainPageViewController:MvxViewController<MainPageViewModel>
    {
        private UITableView tableView;
        public MainPageViewController() : base("MainPageViewController",null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            View.BackgroundColor = UIColor.White;
            Title = "Media listing";

            //Initialize UI elements
            UIInitialize();
            
            //Binding Data from viewmodel to view
            BindingData();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #region Initialize

        private void UIInitialize()
        {
            tableView = new UITableView(new CGRect(0,0,View.Bounds.Width,View.Bounds.Height))
            {
                SeparatorStyle = UITableViewCellSeparatorStyle.None,
                SeparatorColor = UIColor.Clear,
                ContentMode = UIViewContentMode.ScaleAspectFill,
                AlwaysBounceVertical = true,
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleDimensions,
                SectionFooterHeight = 28,
                SectionHeaderHeight = 28,
                EstimatedRowHeight = 40f,
                TableFooterView = new UIView(),
                RowHeight = UITableView.AutomaticDimension,
                AllowsSelection = false
            };

            View.AddSubview(tableView);
        }

      
        private void BindingData()
        {
            var source = new CategoryViewSource(tableView);
            var set = this.CreateBindingSet<MainPageViewController,MainPageViewModel>();
            set.Bind(source).For(s => s.ItemsSource).To(vm => vm.CategoryDataSource);
            tableView.Source = source;
            set.Apply();
            tableView.ReloadData();
        }

        #endregion
    }
}

