using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.ViewModels
{
    public class DefaultViewModel : ViewModelBase
    {
        private string _mainName;
        public string MainName
        {
            get { return _mainName; }
            set { _mainName = value; this.RaiseAndSetIfChanged(ref _mainName, value); }
        }




        public DefaultViewModel()
        {
            MainName = "123456";
        }
    }
}
