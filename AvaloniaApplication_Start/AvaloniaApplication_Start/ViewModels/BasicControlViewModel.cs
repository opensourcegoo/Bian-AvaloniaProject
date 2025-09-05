using AvaloniaApplication_Start.Common;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.ViewModels
{
    public class BasicControlViewModel : ViewModelBase
    {
        private readonly INavigationService  _navigationService;
        public string MainName => "这是BasicView";

        
        public BasicControlViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.NavigateTo<BasicControlViewModel>();
        }
        public object CurrentViewModel => _navigationService.CurrentViewModel;
    }
}
