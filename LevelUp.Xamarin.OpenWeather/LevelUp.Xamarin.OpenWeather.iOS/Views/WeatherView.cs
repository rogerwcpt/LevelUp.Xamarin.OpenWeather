using System;
using MvvmCross.iOS.Views;
using UIKit;
using LevelUp.Xamarin.OpenWeather.iOS.Views.Common;
using LevelUp.Xamarin.OpenWeather.ViewModels;
using MvvmCross.Binding.BindingContext;
using Foundation;
using System.Threading.Tasks;
using System.Net.Http;
using LevelUp.Xamarin.OpenWeather.iOS.Views.TableViewSources;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views
{
	public partial class WeatherView : BaseViewController
	{
		public WeatherView() : base("WeatherView", null)
		{
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			SetupBindings();
		}

		async void SetupBindings()
		{
			var set = this.CreateBindingSet<WeatherView, WeatherViewModel>();
			set.Bind(CityNameLabel).To(vm => vm.CityTitle);
			set.Bind(TemperatureLabel).To(vm => vm.Temperature);
			set.Bind(SynopsisLabel).To(vm => vm.Synopsis);
			set.Bind(DateLabel).To(vm => vm.TimeStamp);
			set.Apply();

			var viewModel = ViewModel as WeatherViewModel;
			if (viewModel != null)
			{
				IconImage.Image = await LoadImage(viewModel.IconUrl);
			}

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			NavigationController.NavigationBar.TopItem.Title = "Back";


			var source = new WeatherTableViewSource(WeatherTableView);
			this.CreateBinding(source)
			    .For(s => s.ItemsSource)
			    .To<WeatherViewModel>(vm => vm.WeatherItems)
			    .Apply();
			WeatherTableView.Source = source;
			WeatherTableView.ReloadData();
		}

		public async Task<UIImage> LoadImage(string imageUrl)
		{
			var httpClient = new HttpClient();
			var buffer = await httpClient.GetByteArrayAsync(imageUrl);
			return UIImage.LoadFromData(NSData.FromArray(buffer));
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

