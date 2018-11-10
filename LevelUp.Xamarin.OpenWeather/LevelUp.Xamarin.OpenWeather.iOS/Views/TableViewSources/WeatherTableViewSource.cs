using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;
using LevelUp.Xamarin.OpenWeather.iOS.Views.Cells;
using Foundation;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views.TableViewSources
{
	public class WeatherTableViewSource : MvxSimpleTableViewSource
	{
        public WeatherTableViewSource(UITableView tableView) : base(tableView, typeof(WeatherItemCell))
		{
            DeselectAutomatically = true;
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
        }

        public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
        {
            if (indexPath.Row % 2 == 0)
            {
                cell.BackgroundColor = UIColor.FromRGBA(80, 80, 80, 20);
            }
        }
    }
}
