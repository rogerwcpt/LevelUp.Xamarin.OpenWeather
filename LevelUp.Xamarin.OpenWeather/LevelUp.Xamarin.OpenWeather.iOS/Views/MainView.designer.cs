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
    [Register ("MainView")]
    partial class MainView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CityName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GoButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CityName != null) {
                CityName.Dispose ();
                CityName = null;
            }

            if (GoButton != null) {
                GoButton.Dispose ();
                GoButton = null;
            }
        }
    }
}