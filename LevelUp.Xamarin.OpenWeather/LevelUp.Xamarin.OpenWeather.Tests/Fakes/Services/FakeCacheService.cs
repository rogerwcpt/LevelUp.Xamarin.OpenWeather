using System;
using LevelUp.Xamarin.OpenWeather.Models.Domain;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;
namespace LevelUp.Xamarin.OpenWeather.Tests.Fakes.Services
{
	public class FakeCacheService: FakeBase, ICacheService
	{
		public WeatherResponse WeatherData
		{
			get
			{
				return new WeatherResponse();
			}

			set
			{
				RecordOccurrence(value.ToString());
			}
		}
	}
}
