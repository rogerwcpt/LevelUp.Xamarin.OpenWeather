using LevelUp.Xamarin.OpenWeather.Models.Domain;

namespace LevelUp.Xamarin.OpenWeather.Services
{
  public class CacheService : ICacheService
  {
		private static CacheService _cacheServiceInstance;

		public WeatherResponse WeatherData { get; set; }

		public static CacheService Instance => _cacheServiceInstance ?? (_cacheServiceInstance = new CacheService());
	}
}
