using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Widget;
using LevelUp.Xamarin.OpenWeather.Android.Helpers;
using LevelUp.Xamarin.OpenWeather.Droid.Adapters;
using LevelUp.Xamarin.OpenWeather.Helpers;
using LevelUp.Xamarin.OpenWeather.Mappers;
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
		}

		protected override void OnResume()
		{
			base.OnResume();

			PopulateView();
		}

		private async Task PopulateView()
		{
			var weatherData = CacheService.Instance.WeatherData;

			if (weatherData == null)
			{
				return;
			}

			// Set City Text
			var textview = FindViewById<TextView>(Resource.Id.textCityTitle);
			textview.Text = $"Weather in {weatherData.Name}, {weatherData.Sys.Country}";

			// Set Temperature Text
			var textTemperature = FindViewById<TextView>(Resource.Id.textTemperature);
			textTemperature.Text = weatherData.Main.Temp.ToString("F1") + " C";

			// Set Synopsis Text
			var textSynopsis = FindViewById<TextView>(Resource.Id.textSynopsis);
			textSynopsis.Text = weatherData.Weather.First().Description;

			// Timestamp Text
			var textTimeStamp = FindViewById<TextView>(Resource.Id.textTimeStamp);
			textTimeStamp.Text = DateTimeHelper.GetDateString(weatherData.Dt, DateTimeHelper.DateTimeFormat.FullDate, true);

			// Populate ListView
			var listView = FindViewById<ListView>(Resource.Id.listDetails);
			var dataList = DomainMapper.ToTupleList(weatherData);
			listView.Adapter = new KeyValueAdapter(this, dataList);

			// Set Weather icon
			await SetWeatherIcon(weatherData);
		}

		private async Task SetWeatherIcon(WeatherResponse weatherData)
		{
			var iconId = weatherData.Weather.First().Icon;
			var iconURL = $"http://openweathermap.org/img/w/{iconId}.png";
			var imageView = FindViewById<ImageView>(Resource.Id.weatherIcon);

			// Non Async version
			//var imageBitmap = BitmapHelper.GetImageBitmapFromUrl(iconURL);
			//imageView.SetImageBitmap(imageBitmap);

			// Asyc Version
			var bitmapHelper = new BitmapHelper();
			var imageBitmap = await bitmapHelper.GetImageBitmapFromUrlAsync(iconURL);
			imageView.SetImageBitmap(imageBitmap);
		}
}
}