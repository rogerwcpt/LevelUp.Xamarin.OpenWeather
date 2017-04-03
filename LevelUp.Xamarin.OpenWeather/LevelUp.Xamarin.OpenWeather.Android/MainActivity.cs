using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using LevelUp.Xamarin.OpenWeather.Services;
using LevelUp.Xamarin.OpenWeather.Models.Domain;

namespace LevelUp.Xamarin.OpenWeather.Droid
{
	[Activity (Label = "Open Weather", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        public static string EXTRA_MESSAGE = "cityname";
        public static string PREFS_CITYNAME = "za.co.weiss.aliens.openweather.cityname";
        //private SharedPreferences _preferences;
		private ProgressDialog _progressDialog;

		public MainActivity()
		{
			WeatherService = new Lazy<WeatherService>();
		}

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			LoadPreferences();

            // Get our button from the layout resource,
            // and attach an event to it
			Button goButton = FindViewById<Button> (Resource.Id.buttonGetWeather);
            goButton.Click += GoButtonClick;
        }

		private async void GoButtonClick(object sender, EventArgs e)
        {
			WeatherResponse response = null;
			_progressDialog = ProgressDialog.Show(this, "Loading", "Wait while loading...");
			try
			{
				response = await WeatherService.Value.GetWeather(CityEditText.Text);
				CacheService.Instance.WeatherData = response;
			}
			finally
			{
				_progressDialog.Hide();
			}

			if (response != null)
			{
				SavePreferences();
				Intent intent = new Intent(this, typeof(WeatherDetailsActivity));
				StartActivity(intent);
			}
		}

		public Lazy<WeatherService> WeatherService { get; }

   		private void LoadPreferences()
		{
			var preference = GetPreferences(FileCreationMode.Private);
			var cityName = preference.GetString(PREFS_CITYNAME, "");
			if (!string.IsNullOrEmpty(cityName))
			{
				CityEditText.Text = cityName;
			}
		}

		private void SavePreferences()
		{
			var preference = GetPreferences(FileCreationMode.Private);
			var editor = preference.Edit();
			editor.PutString(PREFS_CITYNAME, CityEditText.Text);
			editor.Commit();
		}

		private EditText CityEditText => FindViewById<EditText>(Resource.Id.editTextCity);

	}
}


