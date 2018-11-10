using System;
using MvvmCross.Plugin.Color.Platforms.Ios;
using UIKit;
namespace LevelUp.Xamarin.OpenWeather.iOS.App.Views.Common
{
    public class Label : UILabel
    {
        public Label()
        {
            TextColor = CoreColors.TextColor.ToNativeColor(); // From MvvmCross Colors Plugin
            BackgroundColor = UIColor.Clear;
        }
    }

    public class LargeLabel: Label
    {
        public LargeLabel()
        {
            Font = UIFont.SystemFontOfSize(24f, UIFontWeight.Semibold);
        }
    }

    public class MediumLabel : Label
    {
        public MediumLabel()
        {
            Font = UIFont.SystemFontOfSize(20f, UIFontWeight.Regular);
        }
    }

    public class NormalLabel : Label
    {
        public NormalLabel()
        {
            Font = UIFont.SystemFontOfSize(14f, UIFontWeight.Regular);
        }
    }
}
