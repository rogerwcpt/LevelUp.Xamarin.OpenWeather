using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace LevelUp.Xamarin.OpenWeather.Tests.Fakes.Services
{
    public class FakeNavigationService: FakeBase, IMvxNavigationService
    {
        public FakeNavigationService()
        {
        }

        public event BeforeNavigateEventHandler BeforeNavigate;
        public event AfterNavigateEventHandler AfterNavigate;
        public event BeforeCloseEventHandler BeforeClose;
        public event AfterCloseEventHandler AfterClose;

        public Task<bool> CanNavigate(string path)
        {
            RecordOccurrence();
            return Task.FromResult(true);
        }

        public Task<bool> Close(IMvxViewModel viewModel)
        {
			RecordOccurrence();
			return Task.FromResult(true);
		}

        public Task Navigate<TViewModel>(IMvxBundle presentationBundle = null) where TViewModel : IMvxViewModel
        {
                   RecordOccurrence();
            return Task.FromResult(true);
 }

        public Task Navigate<TViewModel, TParameter>(TParameter param, IMvxBundle presentationBundle = null)
            where TViewModel : IMvxViewModel<TParameter>
            where TParameter : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TViewModel, TResult>(IMvxBundle presentationBundle = null)
            where TViewModel : IMvxViewModelResult<TResult>
            where TResult : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TViewModel, TParameter, TResult>(TParameter param, IMvxBundle presentationBundle = null)
            where TViewModel : IMvxViewModel<TParameter, TResult>
            where TParameter : class
            where TResult : class
        {
            throw new NotImplementedException();
        }

        public Task Navigate(IMvxViewModel viewModel, IMvxBundle presentationBundle = null)
        {
            RecordOccurrence();
            return Task.FromResult(true);
		}

        public Task Navigate<TParameter>(IMvxViewModel<TParameter> viewModel, TParameter param, IMvxBundle presentationBundle = null) where TParameter : class
        {
			RecordOccurrence();
			return Task.FromResult(true);
		}

        public Task<TResult> Navigate<TResult>(IMvxViewModelResult<TResult> viewModel, IMvxBundle presentationBundle = null) where TResult : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TParameter, TResult>(IMvxViewModel<TParameter, TResult> viewModel, TParameter param, IMvxBundle presentationBundle = null)
            where TParameter : class
            where TResult : class
        {
            throw new NotImplementedException();
        }

        public Task Navigate(string path, IMvxBundle presentationBundle = null)
        {
			RecordOccurrence();
			return Task.FromResult(true);
		}

        public Task Navigate<TParameter>(string path, TParameter param, IMvxBundle presentationBundle = null) where TParameter : class
        {
			RecordOccurrence();
			return Task.FromResult(true);
		}

        public Task<TResult> Navigate<TResult>(string path, IMvxBundle presentationBundle = null) where TResult : class
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Navigate<TParameter, TResult>(string path, TParameter param, IMvxBundle presentationBundle = null)
            where TParameter : class
            where TResult : class
        {
            throw new NotImplementedException();
        }
    }
}
