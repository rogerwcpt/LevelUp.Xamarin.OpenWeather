using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using LevelUp.Xamarin.OpenWeather.Droid.Platform.Services;
using LevelUp.Xamarin.OpenWeather.Shared;

namespace LevelUp.Xamarin.OpenWeather.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override void InitializeIoC()
		{
			base.InitializeIoC();

			Mvx.LazyConstructAndRegisterSingleton<IProgressService, ProgressService>();
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}
	}
}
