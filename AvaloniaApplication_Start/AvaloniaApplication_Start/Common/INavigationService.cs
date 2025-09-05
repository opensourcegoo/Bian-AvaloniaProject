using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.Common
{
    public interface INavigationService : INotifyPropertyChanged
    {
        object CurrentViewModel { get; }

        event PropertyChangedEventHandler? PropertyChanged;

        void NavigateTo<TViewModel>() where TViewModel : class;
        void GoBack();
        void GoForward();
        bool CanGoBack { get; }
    }
}
