﻿using Android.App;
using LevelUp.Xamarin.OpenWeather.Droid.App;
using LevelUp.Xamarin.OpenWeather.Droid.Views.Common;

namespace LevelUp.Xamarin.OpenWeather.Droid.Views
{
	[Activity(Label = "Open Weather")]
	public class WeatherView : BaseActivity
	{
		public WeatherView() : base(Resource.Layout.WeatherDetails)
		{
		}
	}
}
