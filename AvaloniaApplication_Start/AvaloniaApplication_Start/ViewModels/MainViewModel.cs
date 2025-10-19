using Avalonia.Controls;
using AvaloniaApplication_Start.Common;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Input;

namespace AvaloniaApplication_Start.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "欢迎来到 Avalonia!";
    private object _currentViewModel;

    public ObservableCollection<MenuItem> MenuItems { get; }
    public ICommand NavigateCommand { get; }
    public ReactiveCommand<string, Unit> TestLoadCommand { get; }

    public object CurrentViewModel
    {
        get => _currentViewModel;
        set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    private object _currentView;
    public object CurrentView
    {
        get { return _currentView; }
        set { _currentView = value; this.RaiseAndSetIfChanged(ref _currentView, value); }
    }


    private string _userName = string.Empty;
    public string UserName
    {
        get { return _userName; }
        set { this.RaiseAndSetIfChanged(ref _userName, value); }
    }

    //public object CurrentViewModel2  => _navigationService.CurrentViewModel;

    private readonly INavigationService _navigationService;
    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        TestLoadCommand = ExecuteTestLoad();


        //NavigateCommand = new RelayCommand<MenuItem>(Navigate);

        MenuItems = new ObservableCollection<MenuItem>
        {
            new MenuItem { Text = "Home", IconData = "M10 20v-6h4v6h5v-8h3L12 3 2 12h3v8z", Page = "Home"  },
            new MenuItem { Text = "About", IconData = "...", Page = "About" },
            new MenuItem { Text = "Settings", IconData = "...", Page = "Settings" }
        };

        ReactiveCommand<string, Unit> ExecuteTestLoad()
        {
            var TestLoadCommand2 = ReactiveCommand.Create<string>(menu =>
            {
                if (menu == "Home")
                    _navigationService.NavigateTo<HomeViewModel>();
                else if (menu == "About")
                    _navigationService.NavigateTo<AboutViewModel>();
                else if (menu == "Default")
                    _navigationService.NavigateTo<DefaultViewModel>();
                CurrentViewModel = _navigationService.CurrentViewModel;
            });

            return TestLoadCommand2;
        }
    }

    public class MenuItem
    {
        public string Text { get; set; }
        public string IconData { get; set; }
        public string Page { get; set; }
    }
}
