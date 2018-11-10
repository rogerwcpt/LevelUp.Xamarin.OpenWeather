using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MvvmCross.Forms.Views;
using LevelUp.Xamarin.OpenWeather.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;

namespace LevelUp.Xamarin.OpenWeather.Forms.UI.Views
{
    public partial class MainView : MvxContentPage<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
