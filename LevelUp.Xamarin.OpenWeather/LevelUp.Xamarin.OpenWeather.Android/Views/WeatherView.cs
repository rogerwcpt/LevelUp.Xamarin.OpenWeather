using Android.App;
using LevelUp.Xamarin.OpenWeather.Droid.Views.Common;

namespace LevelUp.Xamarin.OpenWeather.Droid.Views
{
	[Activity(
		Label = "Open Weather", 
		Icon = "@drawable/icon")]
	public class WeatherView : BaseActivity
	{
		public WeatherView() : base(Resource.Layout.WeatherDetails)
		{
		}
	}
}
