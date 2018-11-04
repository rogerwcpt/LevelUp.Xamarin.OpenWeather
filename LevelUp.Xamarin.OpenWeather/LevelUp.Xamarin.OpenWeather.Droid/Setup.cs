using System;
using LevelUp.Xamarin.OpenWeather.Droid.Platform.Services;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Core;

namespace LevelUp.Xamarin.OpenWeather.Droid.App
{
    public class Setup :MvxAndroidSetup<CoreApp>
    {
        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IProgressService, ProgressService>();
        }
    }
}
