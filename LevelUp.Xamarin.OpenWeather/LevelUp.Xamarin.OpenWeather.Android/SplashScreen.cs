
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;

namespace LevelUp.Xamarin.OpenWeather.Droid
{
	[Activity(
		Label = "Open Weather",
	    MainLauncher = true,
		Icon = "@drawable/Icon",
		Theme = "@style/Theme.Splash",
		NoHistory = true,
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashScreen : MvxSplashScreenActivity
	{
		public SplashScreen()
			: base(Resource.Layout.SplashScreen)
		{
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Create your application here
		}
	}
}
