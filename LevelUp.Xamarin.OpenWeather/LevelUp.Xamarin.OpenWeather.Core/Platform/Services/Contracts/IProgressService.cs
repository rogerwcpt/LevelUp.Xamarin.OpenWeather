using System;
namespace LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts
{
	public interface IProgressService
	{
		void Show(string text = null);
		void Hide();
	}
}
