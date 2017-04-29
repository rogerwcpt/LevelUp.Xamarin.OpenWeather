using System;
using LevelUp.Xamarin.OpenWeather.Enums;

namespace LevelUp.Xamarin.OpenWeather.Services.Contracts
{
	public interface IPreferenceService
	{
		void SaveValue(PreferenceType key, string value);
		string GetValue(PreferenceType key);
	}
}
