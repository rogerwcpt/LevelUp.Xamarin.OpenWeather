﻿using System;
using LevelUp.Xamarin.OpenWeather.iOS.Models.Messages;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS.Platform
{
	public class CustomPresenter:  MvxIosViewPresenter
	{
        readonly IUIApplicationDelegate applicationDelegate;
        readonly UIWindow window;

        public CustomPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
            this.window = window;
            this.applicationDelegate = applicationDelegate;
        }

        public override void Show(IMvxIosView view, MvxViewModelRequest request)
        {
            base.Show(view, request);

			var messenger = Mvx.Resolve<IMvxMessenger>();
            var win = applicationDelegate.GetWindow();
            messenger.Publish(new CurrentViewMessage(this, win));
        }
	}
}
