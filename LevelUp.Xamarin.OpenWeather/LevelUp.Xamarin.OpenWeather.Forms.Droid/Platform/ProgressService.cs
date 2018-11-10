using System;
using Android.App;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using MvvmCross;
using MvvmCross.Platforms.Android;

namespace LevelUp.Xamarin.OpenWeather.Forms.Droid.App.Platform
{
    public class ProgressService : IProgressService
    {
        private ProgressDialog _progressDialog;

        public void Show(string message = null)
        {
            var currentContext = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>();
            _progressDialog = ProgressDialog.Show(currentContext.Activity, "Please wait", message);
        }

        public void Hide()
        {
            _progressDialog.Hide();
        }
    }
}
