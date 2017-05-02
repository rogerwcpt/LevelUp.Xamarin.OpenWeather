using System;
using MvvmCross.iOS.Views;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views.Common
{
	public class BaseViewController: MvxViewController
	{
		public BaseViewController(string nibName, Foundation.NSBundle bundle) : base(nibName, bundle)
		{
			IsNavigationBarVisible = true;
			EdgesForExtendedLayout = UIKit.UIRectEdge.None;
		}

		public override void ViewWillAppear(bool animated)
		{
            InitializeView();

			base.ViewWillAppear(animated);
		}

		public virtual void InitializeView()
		{
			if (NavigationController == null)
			{
				return;
			}


			NavigationController.NavigationBarHidden = !IsNavigationBarVisible;
		}

		public bool IsNavigationBarVisible { get; set; }
	}
}
