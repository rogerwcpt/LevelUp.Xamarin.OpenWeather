using System;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;
namespace LevelUp.Xamarin.OpenWeather.Services
{
	public class PreferenceService: IPreferenceService
	{
		public PreferenceService()
		{
		}

		public string GetValue(string key)
		{
			throw new NotImplementedException();
		}

		public void SaveValue(string key, string value)
		{
			//CrossSettings.Current
		}
	}
}
