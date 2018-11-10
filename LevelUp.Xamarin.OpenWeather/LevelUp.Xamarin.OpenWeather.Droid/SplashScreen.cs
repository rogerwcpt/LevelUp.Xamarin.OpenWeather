
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using LevelUp.Xamarin.OpenWeather.Droid.App;

namespace LevelUp.Xamarin.OpenWeather.Droid
{
	[Activity(
		Label = "Open Weather",
	    MainLauncher = true,
        Theme = "@style/Theme.Splash",
        Icon = "@drawable/Icon",
		NoHistory = true,
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashScreen : MvxSplashScreenActivity
	{
        public SplashScreen() : base(Resource.Layout.SplashScreen)
		{
		}
	}
}
