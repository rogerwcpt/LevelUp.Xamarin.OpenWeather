using System;
using System.Net;
using System.Threading.Tasks;
using Android.Graphics;

namespace LevelUp.Xamarin.OpenWeather.Droid.Helpers
{
	public class BitmapHelper
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

		public Task<Bitmap> GetImageBitmapFromUrlAsync(string url)
		{
			var tcs = new TaskCompletionSource<Bitmap>();

			var webClient = new WebClient();
			webClient.DownloadDataAsync(new Uri(url));
			webClient.DownloadDataCompleted += (sender, data) => {
			    if (data == null || data.Result.Length <= 0) return;
			    var imageBitmap = BitmapFactory.DecodeByteArray(data.Result, 0, data.Result.Length);
			    tcs.SetResult(imageBitmap);
			};

			return tcs.Task;
		}
	}
}
