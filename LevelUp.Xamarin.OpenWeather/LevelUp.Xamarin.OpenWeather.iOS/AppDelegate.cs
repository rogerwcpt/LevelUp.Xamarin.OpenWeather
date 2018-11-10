using Foundation;
using LevelUp.Xamarin.OpenWeather;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS.App
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<Setup, CoreApp>
    {
    }
}

