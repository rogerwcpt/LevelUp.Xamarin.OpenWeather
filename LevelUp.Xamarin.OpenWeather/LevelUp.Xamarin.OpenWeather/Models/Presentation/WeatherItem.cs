using System;
namespace LevelUp.Xamarin.OpenWeather.Models.Presentation
{
	public class WeatherItem
	{
		public WeatherItem(string title, string value)
		{
			Title = title;
			Value = value;
		}

		public string Title { get; }
		public string Value { get; }
	}
}
