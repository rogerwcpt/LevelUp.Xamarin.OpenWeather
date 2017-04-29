using Android.App;

using LevelUp.Xamarin.OpenWeather.Droid.Views.Common;

namespace LevelUp.Xamarin.OpenWeather.Droid.Views
{
	[Activity(
		Label = "Open Weather",
	    Icon = "@drawable/Icon")]
	public class MainView : BaseActivity
	{
		public MainView() : base(Resource.Layout.Main)
		{
		}
	}
}
