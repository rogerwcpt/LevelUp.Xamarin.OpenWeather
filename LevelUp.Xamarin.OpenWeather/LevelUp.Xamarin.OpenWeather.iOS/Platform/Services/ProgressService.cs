using LevelUp.Xamarin.OpenWeather.iOS.Models.Messages;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using MBProgressHUD;
using MvvmCross.Plugin.Messenger;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS.Platform.Services
{
	public class ProgressService : IProgressService
	{
		private MTMBProgressHUD _hud;
		private IMvxMessenger _messenger;
		private UIView _currentView;

		public ProgressService(IMvxMessenger messenger)
		{
			_messenger = messenger;
			_messenger.Subscribe<CurrentViewMessage>(HandleCurrentViewMessage, MvxReference.Strong);
		}

		public void Show(string text = null)
		{
			if (_hud == null)
			{
				_hud = new MTMBProgressHUD(_currentView)
				{
					RemoveFromSuperViewOnHide = true,
				    DimBackground = true
				};
			}

			if (string.IsNullOrEmpty(text) == false)
			{
				_hud.LabelText = text;
			}

			_currentView.AddSubview(_hud);
			_hud.Show(true);
		}

		public void Hide()
		{
			_hud.Hide(true);
			_hud.RemoveFromSuperview();	
		}

		void HandleCurrentViewMessage(CurrentViewMessage message)
		{
			_currentView = message.CurrentView;
		}
	}
}
