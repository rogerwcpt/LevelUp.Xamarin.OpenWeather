using System;
using LevelUp.Xamarin.OpenWeather.Services;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;
using LevelUp.Xamarin.OpenWeather.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
namespace LevelUp.Xamarin.OpenWeather
{
	public class App: MvxApplication
	{
		public override void Initialize()
		{
			base.Initialize();

		  Mvx.LazyConstructAndRegisterSingleton<IWeatherService, WeatherService>();

		  RegisterAppStart<MainViewModel>();
		}
	}
}
