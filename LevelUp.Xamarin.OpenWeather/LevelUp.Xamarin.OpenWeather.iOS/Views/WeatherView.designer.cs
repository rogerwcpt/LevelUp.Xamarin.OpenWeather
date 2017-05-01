// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views
{
    [Register ("WeatherView")]
    partial class WeatherView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CityNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView IconImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SynopsisLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TemperatureLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CityNameLabel != null) {
                CityNameLabel.Dispose ();
                CityNameLabel = null;
            }

            if (DateLabel != null) {
                DateLabel.Dispose ();
                DateLabel = null;
            }

            if (IconImage != null) {
                IconImage.Dispose ();
                IconImage = null;
            }

            if (SynopsisLabel != null) {
                SynopsisLabel.Dispose ();
                SynopsisLabel = null;
            }

            if (TemperatureLabel != null) {
                TemperatureLabel.Dispose ();
                TemperatureLabel = null;
            }
        }
    }
}