using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;

using LevelUp.Xamarin.OpenWeather.ViewModels;
using LevelUp.Xamarin.OpenWeather.iOS.Views.Common;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views
{
	public partial class MainView : BaseViewController
	{
		public MainView() : base("MainView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "Open Weather";

			var set = this.CreateBindingSet<MainView, MainViewModel>();
			set.Bind(CityName).To(vm => vm.CityName);
			set.Bind(GoButton).To(vm => vm.GoButtonCommand);
			set.Apply();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			Title = "Open Weather";
		}
	

		//public override void InitializeView()
		//{
		//	IsNavigationBarVisible = false;

		//	base.InitializeView();
		//}
	}
}

