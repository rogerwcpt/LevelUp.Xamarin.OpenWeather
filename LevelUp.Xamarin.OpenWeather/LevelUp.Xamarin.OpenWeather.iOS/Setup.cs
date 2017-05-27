using System;
using System.Diagnostics;
using LevelUp.Xamarin.OpenWeather.iOS.Platform;
using LevelUp.Xamarin.OpenWeather.iOS.Platform.Services;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using LevelUp.Xamarin.OpenWeather.Shared;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS
{
	public class Setup : MvxIosSetup
	{
		readonly MvxApplicationDelegate _applicationDelegate;
		readonly UIWindow _window;

		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
			: base(applicationDelegate, window)
		{
			_window = window;
			_applicationDelegate = applicationDelegate;
		}

		public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
			: base(applicationDelegate, presenter)
		{
			_applicationDelegate = applicationDelegate;
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override IMvxIosViewPresenter CreatePresenter()
		{
			return new CustomPresenter(_applicationDelegate, _window);
		}

		protected override void InitializeIoC()
		{
			base.InitializeIoC();

			Mvx.LazyConstructAndRegisterSingleton<IProgressService, ProgressService>();
		}

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            var ps = Mvx.Resolve<IProgressService>();
            Debug.WriteLine(ps);
        }

		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}
	}
}
