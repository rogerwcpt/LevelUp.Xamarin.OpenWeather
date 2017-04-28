using LevelUp.Xamarin.OpenWeather.Services.Contracts;
using MvvmCross.Core.ViewModels;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using System;
using LevelUp.Xamarin.OpenWeather.Services;
using System.Threading.Tasks;

namespace LevelUp.Xamarin.OpenWeather.ViewModels
{
	public class MainViewModel : MvxViewModel
	{
		private readonly IWeatherService _weatherService;
		private readonly IProgressService _progressService;
		private readonly ICacheService _cacheService;
		
		private string _cityName;

		public MainViewModel(
			IWeatherService weatherService,
			IProgressService progressService,
			ICacheService cacheService)
		{
			_cacheService = cacheService;
			_progressService = progressService;
			_weatherService = weatherService;

			GoButtonCommand = new MvxAsyncCommand(DoButtonCommand, CanDoGotButton);
		}

		public string CityName
		{
			get { return _cityName; }
			set 
			{ 
				SetProperty(ref _cityName, value);
				GoButtonCommand.RaiseCanExecuteChanged();
			}
		}

		public MvxAsyncCommand GoButtonCommand { get; }

		private async Task DoButtonCommand()
		{
			_progressService.Show();
			try
			{
				var result = await _weatherService.GetWeather(CityName);
				if (result != null)
				{
					_cacheService.WeatherData = result;
					ShowViewModel<WeatherViewModel>();
				}
			}
			finally
			{
				_progressService.Hide();
			}
		}

		private bool CanDoGotButton()
		{
			return !string.IsNullOrEmpty(CityName);
		}
	}
}