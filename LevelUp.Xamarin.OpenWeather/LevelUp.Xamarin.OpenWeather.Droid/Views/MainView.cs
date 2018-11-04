using Android.App;

using LevelUp.Xamarin.OpenWeather.Droid.Views.Common;
using LevelUp.Xamarin.OpenWeather.Droid.App;

namespace LevelUp.Xamarin.OpenWeather.Droid.Views
{
	[Activity(Label = "Open Weather")]
	public class MainView : BaseActivity
	{
		public MainView() : base(Resource.Layout.Main)
		{
		}
	}
}
