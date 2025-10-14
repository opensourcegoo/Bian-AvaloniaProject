using Avalonia.Controls;
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
        private readonly INavigationService _navigationService;
        public string MainName => "这是BasicView";

        public ReactiveCommand<object, Unit> TestLoadCommand { get; }
        public BasicControlViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.NavigateTo<AboutViewModel>();
            TestLoadCommand = ReactiveCommand.Create<object>(_ =>
            {
                
            });
        }

        private void TestLoad(SelectionChangedEventArgs args)
        {
            throw new NotImplementedException();
        }

        //private void TestLoad(SelectionChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        public object CurrentViewModel2 => _navigationService.CurrentViewModel;
    }
}
