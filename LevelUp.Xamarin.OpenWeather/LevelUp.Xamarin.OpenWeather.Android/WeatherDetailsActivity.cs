using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LevelUp.Xamarin.OpenWeather.Android.Helpers;
using LevelUp.Xamarin.OpenWeather.Services;

namespace LevelUp.Xamarin.OpenWeather.Droid
{
    [Activity(Label = "Open Weather")]
    public class WeatherDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.WeatherDetails);

			PopulateView();
        }

		void PopulateView()
		{
			var weatherData = CacheService.Instance.WeatherData;

			// Set City Text
			var  textview = FindViewById<TextView>(Resource.Id.textCityTitle);
			textview.Text = $"Weather in {weatherData.Name}, {weatherData.Sys.Country}";

			// Set Weather iconn
			var iconId = weatherData.Weather.First().Icon;
			var iconURL = $"http://openweathermap.org/img/w/{iconId}.png";
			var imageView = FindViewById<ImageView>(Resource.Id.weatherIcon);

			var imageBitmap = BitmapHelper.GetImageBitmapFromUrl(iconURL);
			imageView.SetImageBitmap(imageBitmap);

            // Set TemperatureText
            var textTemperature = FindViewById<TextView>(Resource.Id.textTemperature);
            textTemperature.Text = $"{weatherData.Main.TempMax} C";

            // Set Synopsis Text
            var textSynopsis = FindViewById<TextView>(Resource.Id.textSynopsis);
            textSynopsis.Tag = weatherData.Weather.First().Description;

            // Timestamp Text
            var textTimeStamp = FindViewById<TextView>(Resource.Id.textTimeStamp);
            textTimeStamp.Text = GetDateString(weatherData.Dt);






        }

        private string GetDateString(int dt)
        {
            return new DateTime(dt).ToShortDateString();

        }
    }
}