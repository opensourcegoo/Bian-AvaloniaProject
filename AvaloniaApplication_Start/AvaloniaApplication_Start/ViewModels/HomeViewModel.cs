using AvaloniaApplication_Start.Common;
using AvaloniaApplication_Start.Model;
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

        public FooViewModel Foo { get; set; } = new FooViewModel { FooName = "测试名称" };

        public BarViewModel Bar { get; set; } = new BarViewModel { BarName = "栏目名称" };


        public List<FooViewModel> FooCollection { get; set; }
        public ReactiveCommand<Unit, Unit> SubmitCommand { get; }

        public Person SinglePerson { get; set; }
        public HomeViewModel(INavigationService navigationService)
        {
            SinglePerson = new Person { Name = "Mac", Age = 22 };
            SubmitCommand = ReactiveCommand.Create(Submit);
            FooCollection = new List<FooViewModel>
            {
                new FooViewModel{ FooName = "123"},
                new FooViewModel{ FooName = "456"},
                new FooViewModel{ FooName = "789"},
                new FooViewModel{ FooName = "000"}
            };
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

    /// <summary>
    /// 为Itemscontrol或者是contentcontrol使用还有ContentPresenter
    /// 1、Itemscontrol
    /// 2、Contentcontrol
    /// 3、ContentPresenter
    /// </summary>
    public class FooViewModel
    {
        public string FooName { get; set; }
    }

    public class BarViewModel
    {
        public string BarName { get; set; }
    }
}
