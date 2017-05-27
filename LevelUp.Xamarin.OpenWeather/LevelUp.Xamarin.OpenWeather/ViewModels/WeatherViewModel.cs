using System.Linq;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.UI;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;
using LevelUp.Xamarin.OpenWeather.Models.Presentation;
using LevelUp.Xamarin.OpenWeather.Models.Domain;
using LevelUp.Xamarin.OpenWeather.Helpers;
using MvvmCross.Platform.UI;
using System.Runtime.InteropServices.WindowsRuntime;
using MvvmCross.Core.Navigation;

namespace LevelUp.Xamarin.OpenWeather.ViewModels
{
	public class WeatherViewModel : MvxViewModel
	{
		private readonly ICacheService _cacheService;
        readonly IMvxNavigationService _navigationService;

        public WeatherViewModel(ICacheService cacheService, IMvxNavigationService navigationService)
		{
            this._navigationService = navigationService;
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

			PanelColor = GetColorFromTemperature(data.Main.Temp);

			GetWeatherItems(data);

		}

		public string CityTitle { get; private set; }
		public string IconUrl { get; private set; }
		public string Temperature { get; private set; }
		public string Synopsis { get; private set; }
		public string TimeStamp { get; private set; }

		public MvxColor PanelColor { get; set; }

		public List<WeatherItem> WeatherItems { get; private set; }


		private void GetWeatherItems(WeatherResponse data)
		{
			WeatherItems.Add(new WeatherItem("Wind", $"{data.Wind.Speed} km/h "));
			WeatherItems.Add(new WeatherItem("Cloudiness", $"{data.Clouds.All} %"));
			WeatherItems.Add(new WeatherItem("Pressure", $"{data.Main.Pressure} hpa"));
			WeatherItems.Add(new WeatherItem("Sunrise", DateTimeHelper.GetDateString(data.Sys.Sunrise, DateTimeHelper.DateTimeFormat.Time, true)));
			WeatherItems.Add(new WeatherItem("Sunset", DateTimeHelper.GetDateString(data.Sys.Sunset, DateTimeHelper.DateTimeFormat.Time, true)));
			WeatherItems.Add(new WeatherItem("Coords", $"{data.Coord.Lon}, {data.Coord.Lat}"));

			for (var i = 0; i < WeatherItems.Count; i++)
			{
				var isOdd = !(i % 2 == 0);
				WeatherItems[i].OddColor = isOdd;
			}
		}

		MvxColor GetColorFromTemperature(double temp)
		{
			if (temp > 40) return new MvxColor(255, 17, 0, 50);
			if (temp > 30) return new MvxColor(255, 106, 0, 50);
			if (temp > 20) return new MvxColor(255, 172, 0, 50);
			if (temp > 10) return new MvxColor(49, 255, 0, 50); ;
			if (temp > 0) return new MvxColor(0, 175, 255, 50);
			if (temp < 0) return new MvxColor(80, 22, 255, 50);

			return new MvxColor(0, 0, 0);
		}
	}
}