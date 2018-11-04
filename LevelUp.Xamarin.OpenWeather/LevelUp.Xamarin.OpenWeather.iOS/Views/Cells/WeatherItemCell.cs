using System;
using Cirrious.FluentLayouts.Touch;
using LevelUp.Xamarin.OpenWeather.iOS.App.Views.Cells;
using LevelUp.Xamarin.OpenWeather.iOS.App.Views.Common;
using LevelUp.Xamarin.OpenWeather.Models.Presentation;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views.Cells
{
    public class WeatherItemCell : BaseTableViewCell
	{
        private UIStackView _stackView;
        private UILabel _keyLabel;
        private UILabel _valueLabel;

        private const float PADDING = 10;

        protected WeatherItemCell(IntPtr handle) : base(handle)
        {
        }

        protected override void CreateView()
        {
            base.CreateView();

            _stackView = new UIStackView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Spacing = 5,
            };

            _keyLabel = new UILabel();
            _valueLabel = new UILabel();

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<WeatherItemCell, WeatherItem>();
                set.Bind(_keyLabel)
                   .For(x => x.Text)
                   .To(x => x.Title);
                set.Bind(_valueLabel)
                   .For(x => x.Text)
                   .To(x => x.Value);
                set.Apply();
            });

            ContentView.AddSubview(_stackView);

            _stackView.Axis = UILayoutConstraintAxis.Horizontal;
            _stackView.AddArrangedSubview(_keyLabel);
            _stackView.AddArrangedSubview(_valueLabel);
            _stackView.Alignment = UIStackViewAlignment.Fill;
            _stackView.Distribution = UIStackViewDistribution.FillEqually;

            ContentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
        }

        protected override void CreateConstraints()
        {
            base.CreateConstraints();

            ContentView.AddConstraints(

                _stackView.AtLeftOf(ContentView, PADDING),
                _stackView.AtTopOf(ContentView, PADDING),
                _stackView.AtRightOf(ContentView, PADDING),
                _stackView.AtBottomOf(ContentView, PADDING)
            );
        }
    }
}
