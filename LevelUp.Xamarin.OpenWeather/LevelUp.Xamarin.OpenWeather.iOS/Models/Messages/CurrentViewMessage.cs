using MvvmCross.Plugins.Messenger;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS.Models.Messages
{
	public class CurrentViewMessage : MvxMessage
	{
		public CurrentViewMessage(object sender, UIViewController currentViewController) : base(sender)
		{
			CurrentView = currentViewController.View;
		}

		public readonly UIView CurrentView;
	}
}
