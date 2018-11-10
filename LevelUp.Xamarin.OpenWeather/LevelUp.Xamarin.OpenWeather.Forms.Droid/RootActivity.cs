using System;
using MvvmCross.Forms.Platforms.Android.Views;
using LevelUp.Xamarin.OpenWeather.Forms.UI;
using Android.App;
using Android.Content.PM;

namespace LevelUp.Xamarin.OpenWeather.Forms.Droid.App
{
    [Activity(
        Label = "LevelUp.Xamarin.OpenWeather.Forms.Droid.App",
        Icon = "@mipmap/icon",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode = LaunchMode.SingleTask)]
    public class RootActivity: MvxFormsApplicationActivity<Setup,CoreApp, FormsApp>
    {
    }
}
