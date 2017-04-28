using MvvmCross.Core.ViewModels;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;

namespace LevelUp.Xamarin.OpenWeather.ViewModels
{
	public class WeatherViewModel: MvxViewModel
	{
		private readonly ICacheService _cacheService;

		public WeatherViewModel(ICacheService cacheService)
		{
			_cacheService = cacheService;
		}
	}
}
