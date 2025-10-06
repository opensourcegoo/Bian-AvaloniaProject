using AvaloniaApplication_Start.Common;
using MsBox.Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.ViewModels
{
    public class HomeViewModel
    {
        public string MainName => "这是HomeView";

        public ReactiveCommand<Unit, Unit> SubmitCommand { get; }
        public HomeViewModel(INavigationService navigationService)
        {
            SubmitCommand = ReactiveCommand.Create(Submit);
        }

        private async void Submit()
        {
            var message = MessageBoxManager.GetMessageBoxStandard("提示", "确定退出吗", MsBox.Avalonia.Enums.ButtonEnum.YesNo);
            var result = await message.ShowAsync();
            if (result == MsBox.Avalonia.Enums.ButtonResult.Yes)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
