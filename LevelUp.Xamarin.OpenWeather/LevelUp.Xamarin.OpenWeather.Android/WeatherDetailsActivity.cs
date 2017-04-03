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
using LevelUp.Xamarin.OpenWeather.Droid.Adapters;
using LevelUp.Xamarin.OpenWeather.Models.Domain;
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

			if (weatherData == null)
			{
				return;
			}

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
			textTemperature.Text = weatherData.Main.Temp.ToString("F1") + " C";

            // Set Synopsis Text
            var textSynopsis = FindViewById<TextView>(Resource.Id.textSynopsis);
			textSynopsis.Text = weatherData.Weather.First().Description;

            // Timestamp Text
            var textTimeStamp = FindViewById<TextView>(Resource.Id.textTimeStamp);
			textTimeStamp.Text = GetDateString(weatherData.Dt, DateTmeFormat.Time);

			var listView = FindViewById<ListView>(Resource.Id.listDetails);
			listView.Adapter = new KeyValueAdapter(this, BuildListItems(weatherData));
        }

		private enum DateTmeFormat
		{
			Date,
			Time
		}

		private string GetDateString(int dt, DateTmeFormat format)
        {
			DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(dt);
			var dateTime = dateTimeOffset.ToLocalTime().DateTime;
			if (format == DateTmeFormat.Date)
			{
				return dateTime.ToShortDateString();
			}

			return dateTime.ToShortTimeString();

        }

		IList<Tuple<string, string>> BuildListItems(WeatherResponse weatherData)
		{
			var lineItems = new List<Tuple<string, string>>();

			lineItems.Add(CreateItem("Wind", $"{weatherData.Wind.Speed} km/h "));
			lineItems.Add(CreateItem("Cloudiness", $"{weatherData.Clouds.All} %"));
			lineItems.Add(CreateItem("Pressure", $"{weatherData.Main.Pressure} hpa"));
			lineItems.Add(CreateItem("Sunrise", $"{GetDateString(weatherData.Sys.Sunrise, DateTmeFormat.Date)}"));
			lineItems.Add(CreateItem("Sunset", $"{GetDateString(weatherData.Sys.Sunset, DateTmeFormat.Date)}"));
			lineItems.Add(CreateItem("Coords", $"{weatherData.Coord.Lon}, {weatherData.Coord.Lat}"));

			return lineItems;
		}

		private Tuple<string, string> CreateItem(string item1, string item2)
		{
			return new Tuple<string, string>(item1, item2);
		}
    }
}