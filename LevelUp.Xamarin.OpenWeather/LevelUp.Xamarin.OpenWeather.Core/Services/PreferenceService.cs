using LevelUp.Xamarin.OpenWeather.Services.Contracts;

using LevelUp.Xamarin.OpenWeather.Enums;
using Xamarin.Essentials;

namespace LevelUp.Xamarin.OpenWeather.Services
{
	public class PreferenceService: IPreferenceService
	{
		public string GetValue(PreferenceType key)
		{
            return Preferences.Get(key.ToString(), string.Empty);
		}

		public void SaveValue(PreferenceType preferenceType, string value)
		{
			Preferences.Set(preferenceType.ToString(), value);
		}
	}
}
