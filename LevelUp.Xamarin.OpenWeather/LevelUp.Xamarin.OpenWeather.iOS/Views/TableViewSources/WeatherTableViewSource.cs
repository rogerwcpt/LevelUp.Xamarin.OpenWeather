using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views.TableViewSources
{
	public class WeatherTableViewSource : MvxSimpleTableViewSource
	{
		public WeatherTableViewSource(UITableView tableView) : base(tableView, "WeatherItemCell", "WeatherItemCell")
		{
		}
	}
}
