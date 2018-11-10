using System;
using LevelUp.Xamarin.OpenWeather.Forms.iOS.App.Platform.Services;
using LevelUp.Xamarin.OpenWeather.Forms.UI;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.IoC;

namespace LevelUp.Xamarin.OpenWeather.Forms.iOS.App
{
    public class Setup: MvxFormsIosSetup<CoreApp, FormsApp>
    {
        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IProgressService, ProgressService>();
        }
    }
}
