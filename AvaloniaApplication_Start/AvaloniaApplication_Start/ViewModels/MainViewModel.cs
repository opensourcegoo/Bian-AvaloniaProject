using AvaloniaApplication_Start.Common;

namespace AvaloniaApplication_Start.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private object _currentViewModel;
    //public MainViewModel()
    //{

    //}


    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public string Greeting => "Welcome to Avalonia!";
}
