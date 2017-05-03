using LevelUp.Xamarin.OpenWeather.Models.Domain;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;

namespace LevelUp.Xamarin.OpenWeather.Services
{
	public class CacheService : ICacheService
	{
		public WeatherResponse WeatherData { get; set; }
	}
}
