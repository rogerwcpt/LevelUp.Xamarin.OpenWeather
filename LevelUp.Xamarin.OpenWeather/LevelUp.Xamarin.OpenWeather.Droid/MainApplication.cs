using System;
using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace LevelUp.Xamarin.OpenWeather.Droid.App
{
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, CoreApp>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
    }
}
