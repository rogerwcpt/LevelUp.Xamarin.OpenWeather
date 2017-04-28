using LevelUp.Xamarin.OpenWeather.Models.Domain;

namespace LevelUp.Xamarin.OpenWeather.Services
{
  public interface ICacheService
  {
    WeatherResponse WeatherData { get; set; }
  }
}