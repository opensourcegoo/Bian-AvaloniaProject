using DryIoc;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.Common
{
    public class NavigationService(DryIoc.IContainer container) :ReactiveObject, INavigationService
    {
        public readonly DryIoc.IContainer _container = container;

        public readonly Stack<object> _history = new Stack<object>();
        public object _currentViewModel;
        public object CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    this.RaisePropertyChanged(nameof(CurrentViewModel));
                    this.RaisePropertyChanged(nameof(CanGoBack));
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentViewModel)));
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CanGoBack)));
                }
            }
        }

        public bool CanGoBack => _history.Count > 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void GoBack()
        {
            if (_history.Count > 0)
            {
                CurrentViewModel = _history.Pop();
            }
        }

        public void NavigateTo<TViewModel>() where TViewModel : class
        {
            if (_currentViewModel != null)
            {
                _history.Push(CurrentViewModel);
            }
            CurrentViewModel = _container.Resolve<TViewModel>();
        }

        public void GoForward()
        {
            throw new NotImplementedException();
        }


    }
}
