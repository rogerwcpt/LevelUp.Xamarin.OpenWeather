using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MvvmCross.Forms.Views;
using LevelUp.Xamarin.OpenWeather.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;

namespace LevelUp.Xamarin.OpenWeather.Forms.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : MvxContentPage<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
