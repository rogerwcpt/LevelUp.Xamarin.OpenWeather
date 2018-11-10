using LevelUp.Xamarin.OpenWeather.Services;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;
using LevelUp.Xamarin.OpenWeather.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace LevelUp.Xamarin.OpenWeather
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            Mvx.IoCProvider.RegisterType<IWeatherService, WeatherService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ICacheService, CacheService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IPreferenceService, PreferenceService>();

            RegisterAppStart<MainViewModel>();
        }
    }
}
