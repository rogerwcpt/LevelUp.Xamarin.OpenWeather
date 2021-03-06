﻿using System;
using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using LevelUp.Xamarin.OpenWeather.iOS.Platform.Services;
using MvvmCross.IoC;

namespace LevelUp.Xamarin.OpenWeather.iOS.App
{
    public class Setup: MvxIosSetup<CoreApp>
    {
        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IProgressService, ProgressService>();
        }
    }
}
