using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS
{
	[Register ("AppDelegate")]
	public class AppDelegate : MvxApplicationDelegate
	{
		public override UIWindow Window {
			get;
			set;
		}

public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
	Window = new UIWindow(UIScreen.MainScreen.Bounds);

	var setup = new Setup(this, Window);
	setup.Initialize();

	var startup = Mvx.Resolve<IMvxAppStart>();
	startup.Start();

	Window.MakeKeyAndVisible();

	return true;	}

		public override void OnResignActivation (UIApplication application)
		{
		}

		public override void DidEnterBackground (UIApplication application)
		{
		}

		public override void WillEnterForeground (UIApplication application)
		{
		}

		public override void OnActivated (UIApplication application)
		{
		}

		public override void WillTerminate (UIApplication application)
		{
		}
	}
}


