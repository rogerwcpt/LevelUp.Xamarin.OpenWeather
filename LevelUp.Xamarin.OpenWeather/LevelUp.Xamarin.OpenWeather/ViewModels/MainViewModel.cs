using LevelUp.Xamarin.OpenWeather.Services.Contracts;
using MvvmCross.Core.ViewModels;

namespace LevelUp.Xamarin.OpenWeather.ViewModels
{
  public class MainViewModel: MvxViewModel
  {
    private readonly IWeatherService _weatherService;

    public MainViewModel(IWeatherService weatherService)
    {
      _weatherService = weatherService;
    }
  }
}