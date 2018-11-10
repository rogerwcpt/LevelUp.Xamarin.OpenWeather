using Cirrious.FluentLayouts.Touch;
using FFImageLoading.Cross;
using LevelUp.Xamarin.OpenWeather.iOS.App.Views.Common;
using LevelUp.Xamarin.OpenWeather.iOS.Views.Common;
using LevelUp.Xamarin.OpenWeather.iOS.Views.TableViewSources;
using LevelUp.Xamarin.OpenWeather.ViewModels;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views
{
    public class WeatherView : BaseViewController<WeatherViewModel>
	{
        private readonly UILabel _cityNameLabel;
        private readonly UILabel _dateLabel;
        private readonly UILabel _synopsisLabel;
        private readonly UILabel _temperatureLabel;
        private readonly UIView _temperaturePanel;
        private readonly UITableView _weatherTableView;
        private MvxCachedImageView _iconImage;

        public WeatherView()
        {
            _cityNameLabel = new MediumLabel();
            _temperatureLabel = new LargeLabel();
            _temperaturePanel = new UIView();
            _dateLabel = new NormalLabel();
            _synopsisLabel = new NormalLabel();
            _weatherTableView = new UITableView();
            _iconImage = new MvxCachedImageView();

            this.DelayBind(() =>
            {
                var delaySet = this.CreateBindingSet<WeatherView, WeatherViewModel>();
                delaySet.Bind(_iconImage).For(v => v.ImagePath).To(vm => vm.IconUrl);
                delaySet.Apply();
            });
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Weather Details";
        }

        protected override void SetupViews()
        {
            base.SetupViews();

            _temperaturePanel.AddSubview(_iconImage);
            _temperaturePanel.AddSubview(_temperatureLabel);
            _temperaturePanel.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.Add(_cityNameLabel);
            View.Add(_temperaturePanel);
            View.Add(_dateLabel);
            View.Add(_synopsisLabel);
            View.Add(_weatherTableView);
        }

        public override FluentLayout[] LayoutContraints => new[]
        {

            _cityNameLabel.ToTopMargin(View),
            _cityNameLabel.ToLeftMargin(View),
            _cityNameLabel.ToRightMargin(View),
            _cityNameLabel.Height().EqualTo(60),

            _temperaturePanel.Below(_cityNameLabel, 10f),
            _temperaturePanel.ToLeftMargin(View),
            _temperaturePanel.ToRightMargin(View),
            _temperaturePanel.Height().EqualTo(40),
           
            _iconImage.AtLeftOf(_temperaturePanel),
            _iconImage.AtTopOf(_temperaturePanel, 0),
            _iconImage.WithSameCenterY(_temperaturePanel),
            _iconImage.Width().EqualTo(40),
            _iconImage.Height().EqualTo(40),

            _temperatureLabel.AtLeftOf(_temperaturePanel, 60f),
            _temperatureLabel.AtTopOf(_temperaturePanel, 0),
            _temperatureLabel.WithSameCenterY(_temperaturePanel),
            _temperatureLabel.ToRightMargin(_temperaturePanel),

            _dateLabel.Below(_temperaturePanel, 10f),
            _dateLabel.ToLeftMargin(View),
            _dateLabel.ToRightMargin(View),

            _synopsisLabel.Below(_dateLabel, 10f),
            _synopsisLabel.ToLeftMargin(View),
            _synopsisLabel.ToRightMargin(View),

            _weatherTableView.Below(_synopsisLabel, 20f),
            _weatherTableView.ToLeftMargin(View),
            _weatherTableView.ToRightMargin(View),
            _weatherTableView.ToBottomMargin(View),
        };

        protected override void SetupBindings()
        {
			var set = this.CreateBindingSet<WeatherView, WeatherViewModel>();
			set.Bind(_cityNameLabel).To(vm => vm.CityTitle);
            set.Bind(_temperatureLabel).To(vm => vm.Temperature);
            set.Bind(_temperaturePanel)
               .For(v => v.BackgroundColor)
               .To(vm => vm.PanelColor)
               .WithConversion("NativeColor");
			set.Bind(_synopsisLabel).To(vm => vm.Synopsis);
			set.Bind(_dateLabel).To(vm => vm.TimeStamp);
            set.Apply();

            var source = new WeatherTableViewSource(_weatherTableView);
            this.CreateBinding(source)
                .For(s => s.ItemsSource)
                .To<WeatherViewModel>(vm => vm.WeatherItems)
                .Apply();
            _weatherTableView.Source = source;
            _weatherTableView.ReloadData();
        }
	}
}

