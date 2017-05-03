using System;
using LevelUp.Xamarin.OpenWeather.iOS.Models.Messages;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS.Platform
{
	public class CustomPresenter:  MvxIosViewPresenter
	{

		public CustomPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
		{
		}

		public override void Show(IMvxIosView view)
		{
			base.Show(view);

			var messenger = Mvx.Resolve<IMvxMessenger>();
			messenger.Publish(new CurrentViewMessage(this, CurrentTopViewController));
		}
	}
}
