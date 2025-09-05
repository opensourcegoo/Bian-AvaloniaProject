using AvaloniaApplication_Start.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.ViewModels
{
    public class HomeViewModel
    {
        public string MainName => "这是HomeView";
        public HomeViewModel(INavigationService navigationService)
        {

        }
    }
}
