// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views.Cells
{
    [Register ("WeatherItemCell")]
    partial class WeatherItemCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel KeyLabel1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ValueLabel1 { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (KeyLabel1 != null) {
                KeyLabel1.Dispose ();
                KeyLabel1 = null;
            }

            if (ValueLabel1 != null) {
                ValueLabel1.Dispose ();
                ValueLabel1 = null;
            }
        }
    }
}