using System;
namespace LevelUp.Xamarin.OpenWeather.Helpers
{
	public class DateTimeHelper
	{
		public static string GetDateString(int unixTimeStamp, DateTimeFormat format )
		{
			var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
			switch (format)
			{
				case DateTimeFormat.Date:  
					return dateTime.ToString("M");
				case DateTimeFormat.Time:
					return dateTime.ToString("t");
				case DateTimeFormat.FullDate:
					return dateTime.ToString("f");
				default:
					return dateTime.ToString("f");
					
			}
		}

		public enum DateTimeFormat
		{
			Default,
			FullDate,
			Date,
			Time
		}

	}
}
