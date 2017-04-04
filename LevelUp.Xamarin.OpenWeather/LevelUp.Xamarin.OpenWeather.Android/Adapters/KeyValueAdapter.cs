using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

// Taken from:  https://developer.xamarin.com/guides/android/user_interface/working_with_listviews_and_adapters/part_3_-_customizing_a_listview's_appearance/

namespace LevelUp.Xamarin.OpenWeather.Droid.Adapters
{
	public class KeyValueAdapter: BaseAdapter<Tuple<string, string>>
	{
		readonly Activity _context;
		readonly IList<Tuple<string, string>> _items;

		public KeyValueAdapter(Activity context, IList<Tuple<string, string>> values) : base()
		{
			_items = values;
			_context = context;
		}

		public override Tuple<string, string> this[int position]
		{
			get
			{
				return _items[position];
			}
		}

		public override int Count
		{
			get
			{
				return _items.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return _items[position].GetHashCode();
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = _items[position];
			View view = convertView;
			if (view == null)
			{
				view = _context.LayoutInflater.Inflate(Resource.Layout.listview_item_row, null);
			}
			view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Item1;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.Item2;

			if (position % 2 == 1)
			{
				view.SetBackgroundColor(new Color(228, 228, 228));
			}

			return view;
		}
	}
}
