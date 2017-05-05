using System;
using System.Threading.Tasks;
using LevelUp.Xamarin.OpenWeather.Models.Domain;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;
namespace LevelUp.Xamarin.OpenWeather.Tests.Fakes.Services
{
	public class FakeWeatherService: FakeBase, IWeatherService
	{
		public Task<WeatherResponse> GetWeather(string cityName)
		{
			RecordOccurrence(args: new[] { cityName });
			return Task.FromResult(new WeatherResponse());
		}
	}
}
