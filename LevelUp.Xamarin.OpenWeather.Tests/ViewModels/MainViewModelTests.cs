using NUnit.Framework;
using System.Security.Policy;
using LevelUp.Xamarin.OpenWeather.ViewModels;
using Aliens.MegaU.Core.Tests.Fakes.Common;
using LevelUp.Xamarin.OpenWeather.Services.Contracts;
using LevelUp.Xamarin.OpenWeather.Tests.Fakes.Services;
using LevelUp.Xamarin.OpenWeather.Platform.Services.Contracts;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace LevelUp.Xamarin.OpenWeather.Tests.ViewModels
{
	[TestFixture]
	public class MainViewModelTests
	{
		private FakeCacheService _fakeCacheService;

		FakeWeatherService _fakeWeatherService;

		FakePreferenceService _fakePreferenceService;

		FakeProgressService _fakeProgressService;

		[SetUp]
		public void Init()
		{
			_fakeCacheService = new FakeCacheService();
			_fakeWeatherService = new FakeWeatherService();
			_fakePreferenceService = new FakePreferenceService();
			_fakeProgressService = new FakeProgressService();
		}

		[Test]
		public async Task Test_GoButtonCommand_GivenEmptyCityName_ShouldNotInvoke_Services()
		{
			// Arrange
			var viewModel = new MainViewModel(_fakeWeatherService, _fakeProgressService, _fakeCacheService, _fakePreferenceService);
			viewModel.CityName = null;

			// Act
			await viewModel.GoButtonCommand.ExecuteAsync();

			//Assert
			Assert.IsTrue(_fakeWeatherService.HasNeverOccurred("GetWeather"));
		}

		[Test]
		public async Task Test_GoButtonCommand_GivenCityName_ShouldInvoke_Services()
		{
			// Arrange
			var viewModel = new MainViewModel(_fakeWeatherService, _fakeProgressService, _fakeCacheService, _fakePreferenceService);
			viewModel.CityName = "Cape Town";

			// Act
			await viewModel.GoButtonCommand.ExecuteAsync();

			// Assert
			Assert.IsTrue(_fakeProgressService.HasOccurredOnce("Show"));
			Assert.IsTrue(_fakeProgressService.HasOccurredOnce("Hide"));
			Assert.IsTrue(_fakePreferenceService.HasOccurredOnce("SaveValue:CityName:Cape Town"));
			Assert.IsTrue(_fakeWeatherService.HasOccurredOnce("GetWeather:Cape Town"));
		}
	}
}
