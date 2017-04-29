using MvvmCross.Core.ViewModels;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;
using System.Linq;
using LevelUp.Xamarin.OpenWeather.Enums;
using System;
using System.Runtime.InteropServices;
using LevelUp.Xamarin.OpenWeather.Models.Presentation;
using System.Collections.Generic;
using LevelUp.Xamarin.OpenWeather.Models.Domain;
using LevelUp.Xamarin.OpenWeather.Helpers;

namespace LevelUp.Xamarin.OpenWeather.ViewModels
{
	public class WeatherViewModel : MvxViewModel
	{
		private readonly ICacheService _cacheService;

		public WeatherViewModel(ICacheService cacheService)
		{
			_cacheService = cacheService;
			WeatherItems = new List<WeatherItem>();
		}

		public override void Start()
		{
			base.Start();

			var data = _cacheService.WeatherData;

			CityTitle = $"{data.Name}, {data.Sys.Country}";
			IconUrl = $"http://openweathermap.org/img/w/{data.Weather.First().Icon}.png";
			Temperature = data.Main.Temp.ToString("F1") + " C";
			Synopsis = data.Weather.First().Description;
			TimeStamp = DateTimeHelper.GetDateString(data.Dt, DateTimeHelper.DateTimeFormat.Date, true);

			GetWeatherItems(data);

		}

		public string CityTitle { get; private set; }
		public string IconUrl { get; private set; }
		public string Temperature { get; private set; }
		public string Synopsis { get; private set; }
		public string TimeStamp { get; private set; }

		public List<WeatherItem> WeatherItems { get; private set; }


		private void GetWeatherItems(WeatherResponse data)
		{
			WeatherItems.Add(new WeatherItem("Wind", $"{data.Wind.Speed} km/h "));
			WeatherItems.Add(new WeatherItem("Cloudiness", $"{data.Clouds.All} %"));
			WeatherItems.Add(new WeatherItem("Pressure", $"{data.Main.Pressure} hpa"));
			WeatherItems.Add(new WeatherItem("Sunrise", DateTimeHelper.GetDateString(data.Sys.Sunrise, DateTimeHelper.DateTimeFormat.Time, true)));
			WeatherItems.Add(new WeatherItem("Sunset", DateTimeHelper.GetDateString(data.Sys.Sunset, DateTimeHelper.DateTimeFormat.Time, true)));
			WeatherItems.Add(new WeatherItem("Coords", $"{data.Coord.Lon}, {data.Coord.Lat}"));
		}
	}
}