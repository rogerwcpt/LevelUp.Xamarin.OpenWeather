using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LevelUp.Xamarin.OpenWeather.Droid
{
	[Activity (Label = "LevelUp.Xamarin.OpenWeather.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        public static string EXTRA_MESSAGE = "cityname";
        public static string PREFS_CITYNAME = "za.co.weiss.aliens.openweather.cityname";
        //private SharedPreferences _preferences;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button goButton = FindViewById<Button> (Resource.Id.myButton);

            goButton.Click += GoButtonClick;

            // or

            //goButton.Click += delegate
            //{
            //    NavigateToWeatherDetails();
            //};

        }

        private void GoButtonClick(object sender, EventArgs e)
        {
            NavigateToWeatherDetails();
        }

        private void NavigateToWeatherDetails()
        {
            Intent intent = new Intent(this, typeof(WeatherDetailsActivity));
            intent.PutExtra(EXTRA_MESSAGE, "");
            StartActivity(intent);
        }
    }
}


