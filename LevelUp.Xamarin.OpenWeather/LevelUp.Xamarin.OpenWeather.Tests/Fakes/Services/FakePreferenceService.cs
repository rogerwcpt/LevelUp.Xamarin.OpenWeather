using System;
using LevelUp.Xamarin.OpenWeather.Enums;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;
namespace LevelUp.Xamarin.OpenWeather.Tests.Fakes.Services
{
	public class FakePreferenceService : FakeBase, IPreferenceService
	{
		public string GetValue(PreferenceType key)
		{
			RecordOccurrence(key.ToString());
			return string.Empty;
		}

		public void SaveValue(PreferenceType key, string value)
		{
			RecordOccurrence(args: new[] { key.ToString() + ":" + value });
		}
	}
}
