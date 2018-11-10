using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;
using LevelUp.Xamarin.OpenWeather.Forms.UI;

namespace LevelUp.Xamarin.OpenWeather.Forms.iOS.App
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, CoreApp, FormsApp>
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}

