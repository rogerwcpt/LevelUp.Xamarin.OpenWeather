using System;
namespace LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts
{
	public interface IProgressService
	{
		void Show(string message = null);
		void Hide();
	}
}
