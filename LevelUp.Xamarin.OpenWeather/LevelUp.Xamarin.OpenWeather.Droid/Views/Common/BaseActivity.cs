using Android.OS;
using MvvmCross.Platforms.Android.Views;

namespace LevelUp.Xamarin.OpenWeather.Droid.Views.Common
{
	public class BaseActivity: MvxActivity
	{
		private readonly int _layoutId;

		public BaseActivity(int layoutId)
		{
			_layoutId = layoutId;
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(_layoutId);
		}
	}
}
