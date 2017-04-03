using System;
using System.Collections.Generic;
using LevelUp.Xamarin.OpenWeather.Models.Domain;

namespace LevelUp.Xamarin.OpenWeather.Mappers
{
	public class DomainMapper
	{
		public static IDictionary<string, string> ToDictionary(WeatherResponse response)
		{
			return new Dictionary<string, string>() 
			{
				{ "", "" } 
			};
		}
	}
}
