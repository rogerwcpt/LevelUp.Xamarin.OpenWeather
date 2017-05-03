using System;
namespace LevelUp.Xamarin.OpenWeather.Models.Presentation
{
	public class WeatherItem
	{
		public WeatherItem(string title, string value, bool oddColor = false)
		{
			Title = title;
			Value = value;
			OddColor = oddColor;
		}

		public string Title { get; }
		public string Value { get; }
		public bool OddColor { get; }
	}
}
