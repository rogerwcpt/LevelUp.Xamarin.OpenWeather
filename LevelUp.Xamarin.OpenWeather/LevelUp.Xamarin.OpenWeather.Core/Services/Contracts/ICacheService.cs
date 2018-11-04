using LevelUp.Xamarin.OpenWeather.Models.Domain;

namespace LevelUp.Xamarin.OpenWeather.Services.Contracts
{
  public interface ICacheService
  {
    WeatherResponse WeatherData { get; set; }
  }
}