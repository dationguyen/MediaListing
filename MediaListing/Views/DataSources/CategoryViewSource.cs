using Foundation;
using MediaListing.Core.Models;
using MediaListing.Views.Cells;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MediaListing.Views.DataSources
{
    public class CategoryViewSource:MvxTableViewSource
    {
        public CategoryViewSource(UITableView tableView)
            : base(tableView)
        {
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;

            tableView.RegisterNibForCellReuse(UINib.FromName("CategoryViewCell",NSBundle.MainBundle),
                CategoryViewCell.Key);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView,NSIndexPath indexPath,
            object item)
        {
            CategoryViewCell cell = (CategoryViewCell)tableView.DequeueReusableCell(CategoryViewCell.Key,indexPath);
            if(item is Category cat)
            {
                cell.IsLandscape = cat.Name == "Features";
            }
            return cell;
        }


    }
}