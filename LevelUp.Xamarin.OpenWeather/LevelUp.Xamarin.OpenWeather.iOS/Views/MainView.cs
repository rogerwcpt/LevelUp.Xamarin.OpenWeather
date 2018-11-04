using Cirrious.FluentLayouts.Touch;
using LevelUp.Xamarin.OpenWeather.iOS.App.Views.Common;
using LevelUp.Xamarin.OpenWeather.iOS.Views.Common;
using LevelUp.Xamarin.OpenWeather.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using UIKit;

namespace LevelUp.Xamarin.OpenWeather.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)] // Important to tell iOS which will be your entry point screen
    public class MainView : BaseViewController<MainViewModel>
	{
        private readonly UIStackView _stackView;
        private readonly UIView _spacer;
        private readonly UILabel _cityLabel;
        private readonly UITextField _cityNameText;
        private readonly UIButton _goButton;

        public MainView()
        {
            _stackView = new UIStackView();
            _spacer = new UIView();
            _cityLabel = new NormalLabel();
            _cityNameText = new UITextField();
            _goButton = new UIButton();
        }

        public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "Open Weather";
        }

        protected override void SetupViews()
        {
            base.SetupViews();

            _cityLabel.Text = "Enter city name";
            _cityNameText.BorderStyle = UITextBorderStyle.RoundedRect;

            _goButton.SetTitle("Go", UIControlState.Normal);
            _goButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            _goButton.SetTitleColor(UIColor.Gray, UIControlState.Disabled);

            _stackView.AddArrangedSubview(_spacer);
            _stackView.AddArrangedSubview(_cityLabel);
            _stackView.AddArrangedSubview(_cityNameText);
            _stackView.AddArrangedSubview(_goButton);

            _stackView.Axis = UILayoutConstraintAxis.Vertical;
            _stackView.Alignment = UIStackViewAlignment.Fill;

            View.AddSubview(_stackView);
        }

        public override FluentLayout[] LayoutContraints => new[]
        {
            _stackView.ToTopMargin(View),
            _stackView.ToLeftMargin(View),
            _stackView.ToRightMargin(View),

            _spacer.Height().EqualTo(20),
        };

        protected override void SetupBindings()
        {
            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(_cityNameText).To(vm => vm.CityName);
            set.Bind(_goButton).To(vm => vm.GoButtonCommand);
            set.Apply();
        }
    }
}

