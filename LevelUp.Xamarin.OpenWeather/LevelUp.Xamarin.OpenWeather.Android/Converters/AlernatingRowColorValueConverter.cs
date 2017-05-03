using System;
using System.Globalization;
using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Color;

namespace LevelUp.Xamarin.OpenWeather.Droid.Converters
{
	public class AlernatingRowColorValueConverter : MvxColorValueConverter<bool>
	{
		protected override MvxColor Convert(bool value, object parameter, CultureInfo culture)
		{
			return value 
				? new MvxColor(0) 
                : new MvxColor(80, 80, 80, 50);
		}
	}
}
