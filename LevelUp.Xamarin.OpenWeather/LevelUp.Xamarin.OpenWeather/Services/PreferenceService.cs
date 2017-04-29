using System;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;
using Plugin.Settings;
using LevelUp.Xamarin.OpenWeather.Enums;

namespace LevelUp.Xamarin.OpenWeather.Services
{
	public class PreferenceService: IPreferenceService
	{
		public const string Key_CityName = "CityName";

		public string GetValue(PreferenceType key)
		{
			return CrossSettings.Current.GetValueOrDefault<string>(key.ToString());
		}

		public void SaveValue(PreferenceType preferenceType, string value)
		{
			CrossSettings.Current.AddOrUpdateValue(preferenceType.ToString(), value);
		}
	}
}
