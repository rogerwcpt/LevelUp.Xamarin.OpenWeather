using System.Threading.Tasks;
using LevelUp.Xamarin.OpenWeather.Models.Domain;

namespace LevelUp.Xamarin.OpenWeather.Services.Contracts
{
  public interface IWeatherService
  {
    Task<WeatherResponse> GetWeather(string cityName);
  }
}