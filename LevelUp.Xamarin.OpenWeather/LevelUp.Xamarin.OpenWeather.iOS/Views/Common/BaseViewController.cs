using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using UIKit;
using MvvmCross.Plugin.Messenger;
using LevelUp.Xamarin.OpenWeather.iOS.Models.Messages;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views.Common
{
    public class BaseViewController<T>: MvxViewController<T> where T: MvxViewModel
	{
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupViews();
            SetupConstraints();
            SetupNavigationBar();
            SetupBindings();
        }

        protected virtual void SetupViews() 
        {
            View.BackgroundColor = UIColor.White;
        }

        protected virtual void SetupConstraints() 
        {
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(LayoutContraints);
        }

        protected virtual void SetupBindings() 
        {
        }

        public virtual void SetupNavigationBar()
		{
			if (NavigationController == null)
			{
				return;
			}


			NavigationController.NavigationBarHidden = NavigationBarHidden;
		}

		public bool NavigationBarHidden { get; set; }
        public virtual FluentLayout[] LayoutContraints { get;  }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var messenger = Mvx.IoCProvider.Resolve<IMvxMessenger>();
            messenger.Publish(new CurrentViewMessage(this, this));
        }
    }
}
