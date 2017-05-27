using NUnit.Framework;
using LevelUp.Xamarin.OpenWeather.Helpers;

namespace LevelUp.Xamarin.OpenWeather.Tests.Helpers
{
	[TestFixture]
	public class DateTimeHelperTests
	{
		[Test]
		public void Test_GetDateString_GivenDateFormat_ShouldReturn_ValidDateString()
		{
			var unixtimeStamp = 1493702541;
			var testResult = DateTimeHelper.GetDateString(unixtimeStamp, DateTimeHelper.DateTimeFormat.Date);
			Assert.AreEqual("02 May", testResult);
		}

		[Test]
		public void Test_GetDateString_GivenTimeFormat_ShouldReturn_ValidDateString()
		{
			var unixtimeStamp = 1493702541;
			var testResult = DateTimeHelper.GetDateString(unixtimeStamp, DateTimeHelper.DateTimeFormat.Time);
			Assert.AreEqual("5:22 AM", testResult);
		}
	}
}
