using System;
using MvvmCross.Forms.Platforms.Android.Core;
using LevelUp.Xamarin.OpenWeather.Forms.UI;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using LevelUp.Xamarin.OpenWeather.Forms.Droid.App.Platform;
using MvvmCross;
using MvvmCross.IoC;

namespace LevelUp.Xamarin.OpenWeather.Forms.Droid.App
{
    public class Setup: MvxFormsAndroidSetup<CoreApp, FormsApp>
    {
        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IProgressService, ProgressService>();
        }
    }
}
