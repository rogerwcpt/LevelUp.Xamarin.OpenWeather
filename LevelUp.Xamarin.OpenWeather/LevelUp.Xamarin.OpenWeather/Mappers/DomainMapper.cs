using System;
using System.Collections.Generic;
using LevelUp.Xamarin.OpenWeather.Helpers;
using LevelUp.Xamarin.OpenWeather.Models.Domain;

namespace LevelUp.Xamarin.OpenWeather.Mappers
{
	public class DomainMapper
	{	
		public static IList<Tuple<string, string>> ToTupleList(WeatherResponse weatherData)
		{
			var lineItems = new List<Tuple<string, string>>();

			lineItems.Add(CreateItem("Wind", $"{weatherData.Wind.Speed} km/h "));
			lineItems.Add(CreateItem("Cloudiness", $"{weatherData.Clouds.All} %"));
			lineItems.Add(CreateItem("Pressure", $"{weatherData.Main.Pressure} hpa"));
			lineItems.Add(CreateItem("Sunrise", $"{DateTimeHelper.GetDateString(weatherData.Sys.Sunrise, DateTimeHelper.DateTimeFormat.Time)}"));
			lineItems.Add(CreateItem("Sunset", $"{DateTimeHelper.GetDateString(weatherData.Sys.Sunset, DateTimeHelper.DateTimeFormat.Time)}"));
			lineItems.Add(CreateItem("Coords", $"{weatherData.Coord.Lon}, {weatherData.Coord.Lat}"));

			return lineItems;
		}

		private static Tuple<string, string> CreateItem(string item1, string item2)
		{
			return new Tuple<string, string>(item1, item2);
		}
	}
}
