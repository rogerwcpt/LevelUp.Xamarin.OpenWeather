﻿using System;
using System.Net;
using Android.Graphics;

namespace LevelUp.Xamarin.OpenWeather.Android.Helpers
{
	public static class BitmapHelper
	{
		public static Bitmap GetImageBitmapFromUrl(string url)
		{
			Bitmap imageBitmap = null;

			using (var webClient = new WebClient())
			{
				var imageBytes = webClient.DownloadData(url);
				if (imageBytes != null && imageBytes.Length > 0)
				{
					imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
				}
			}

			return imageBitmap;
		}

	}
}
