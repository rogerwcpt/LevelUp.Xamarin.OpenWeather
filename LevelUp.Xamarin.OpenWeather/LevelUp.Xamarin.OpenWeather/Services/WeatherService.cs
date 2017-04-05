﻿using System.Net.Http;
using System.Threading.Tasks;
using LevelUp.Xamarin.OpenWeather.Models.Domain;
using Newtonsoft.Json;

namespace LevelUp.Xamarin.OpenWeather.Services
{
	public class WeatherService
	{
		private const string BaseUrl = "http://api.openweathermap.org/data/2.5/weather?q=";
		private const string UrlQueryString = "&appid=7936b956edfc1d816ad0a23f31503930&units=metric";

		private readonly HttpClient _httpClient;

		public WeatherService()
		{
			_httpClient = new HttpClient();
		}

		public async Task<WeatherResponse> GetWeather(string cityName)
		{
			WeatherResponse result = null;

			var url = BaseUrl + cityName + UrlQueryString;
			var response = await _httpClient.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				var responseBody = await response.Content.ReadAsStringAsync();
				result = JsonConvert.DeserializeObject<WeatherResponse>(responseBody);
			}

			return result;
		}
	}
}
