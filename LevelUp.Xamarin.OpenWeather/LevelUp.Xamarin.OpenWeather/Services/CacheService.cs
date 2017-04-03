using System;
using LevelUp.Xamarin.OpenWeather.Models.Domain;

namespace LevelUp.Xamarin.OpenWeather.Services
{
	public class CacheService
	{
		private CacheService()
		{
		}

		private static CacheService _cacheServiceInstance;

		public WeatherResponse WeatherData { get; set; }

		public static CacheService Instance
		{
			get
			{
				if (_cacheServiceInstance == null)
				{
					_cacheServiceInstance = new CacheService();
				}

				return _cacheServiceInstance;
			}
		}
	}
}
