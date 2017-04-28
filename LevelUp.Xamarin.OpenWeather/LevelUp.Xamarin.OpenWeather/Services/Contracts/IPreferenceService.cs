using System;
namespace LevelUp.Xamarin.OpenWeather.Services.Contracts
{
	public interface IPreferenceService
	{
		void SaveValue(string key, string value);
		string GetValue(string key);
	}
}
