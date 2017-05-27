using System;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
namespace LevelUp.Xamarin.OpenWeather.Tests.Fakes.Services
{
	public class FakeProgressService: FakeBase, IProgressService
	{
		public void Hide()
		{
			RecordOccurrence();
		}

		public void Show(string text = null)
		{
            RecordOccurrence();
		}
	}
}
