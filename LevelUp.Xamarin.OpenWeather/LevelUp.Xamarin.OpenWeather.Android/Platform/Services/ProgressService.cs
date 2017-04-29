using System;
using Android.App;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace LevelUp.Xamarin.OpenWeather.Droid.Platform.Services
{
	public class ProgressService : IProgressService
	{
		private ProgressDialog _progressDialog;

		public void Show(string message = null)
		{
			var currentContext = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
			_progressDialog = ProgressDialog.Show(currentContext.Activity, "Please wait", message);
		}

		public void Hide()
		{
			_progressDialog.Hide();
		}
	}
}
