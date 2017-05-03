using System;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using LevelUp.Xamarin.OpenWeather.Models.Presentation;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views.Cells
{
	public partial class WeatherItemCell : MvxTableViewCell
	{
		protected WeatherItemCell(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<WeatherItemCell, WeatherItem>();
				set.Bind(KeyLabel1)
				   .For(x => x.Text)
				   .To(x => x.Title);
				set.Bind(ValueLabel1)
				   .For(x => x.Text)
				   .To(x => x.Value);
				set.Apply();
			});
		}
	}
}
