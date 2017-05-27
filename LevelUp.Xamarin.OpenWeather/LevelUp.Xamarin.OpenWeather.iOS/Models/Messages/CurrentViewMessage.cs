using MvvmCross.Plugins.Messenger;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS.Models.Messages
{
	public class CurrentViewMessage : MvxMessage
	{
        public CurrentViewMessage(object sender, UIView view) : base(sender)
		{
            CurrentView = view;
		}

		public readonly UIView CurrentView;
	}
}
