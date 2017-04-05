using System;

using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

using LevelUp.Xamarin.OpenWeather.Services;
using LevelUp.Xamarin.OpenWeather.Models.Domain;

namespace LevelUp.Xamarin.OpenWeather.Droid
{
	[Activity (Label = "Open Weather", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        private const string PrefsCityname = "za.co.weiss.aliens.openweather.cityname";
        //private SharedPreferences _preferences;
		private ProgressDialog _progressDialog;

		public MainActivity()
		{
			WeatherService = new Lazy<WeatherService>();
		}

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

			LoadPreferences();

			var goButton = FindViewById<Button> (Resource.Id.buttonGetWeather);
            goButton.Click += GoButtonClick;
        }

		private async void GoButtonClick(object sender, EventArgs e)
        {
			WeatherResponse response = null;
			_progressDialog = ProgressDialog.Show(this, "Loading", "Fetching your weather...");
			try
			{
				response = await WeatherService.Value.GetWeather(CityEditText.Text);
				CacheService.Instance.WeatherData = response;
				if (response != null)
				{
					SavePreferences();
				}
			}
			finally
			{
				_progressDialog.Hide();
			}

			if (response != null)
			{
				var intent = new Intent(this, typeof(WeatherDetailsActivity));
				StartActivity(intent);
			}
		}

		public Lazy<WeatherService> WeatherService { get; }

   		private void LoadPreferences()
		{
			var preference = GetPreferences(FileCreationMode.Private);
			var cityName = preference.GetString(PrefsCityname, "");
			if (!string.IsNullOrEmpty(cityName))
			{
				CityEditText.Text = cityName;
			}
		}

		private void SavePreferences()
		{
			var preference = GetPreferences(FileCreationMode.Private);
			var editor = preference.Edit();
			editor.PutString(PrefsCityname, CityEditText.Text);
			editor.Commit();
		}

		private EditText CityEditText => FindViewById<EditText>(Resource.Id.editTextCity);
	}
}


