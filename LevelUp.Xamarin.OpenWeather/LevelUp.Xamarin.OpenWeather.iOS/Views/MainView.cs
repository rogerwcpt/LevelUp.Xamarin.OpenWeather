using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using LevelUp.Xamarin.OpenWeather.ViewModels;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views
{
	public partial class MainView : MvxViewController
	{
		public MainView() : base("MainView", null)
		{
		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var set = this.CreateBindingSet<MainView, MainViewModel>();
			set.Bind(CityName).To(vm => vm.CityName);
			set.Bind(GoButton).To(vm => vm.GoButtonCommand);
			set.Apply();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

