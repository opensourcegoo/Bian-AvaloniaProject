using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DryIoc;
using AvaloniaApplication_Start.ViewModels;
using AvaloniaApplication_Start.Views;
using System.ComponentModel;
using Avalonia.Input;
using AvaloniaApplication_Start.Common;

namespace AvaloniaApplication_Start;

public partial class App : Application
{

    public static DryIoc.IContainer Container { get; set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        //1,创建IOc容器
        Container = new DryIoc.Container();

        //2注册服务(单例)
        Container.Register<INavigationService, NavigationService>(Reuse.Singleton);
        //3,注册viewmodel
        Container.Register<MainViewModel>(Reuse.Transient);
        Container.Register<BasicControlViewModel>(Reuse.Transient);
        Container.Register<HomeViewModel>(Reuse.Transient);
        Container.Register<AboutViewModel>(Reuse.Transient);
        Container.Register<DefaultViewModel>(Reuse.Singleton);

        // 注册Views（可选，如果需要依赖注入到View中）
        Container.Register<MainWindow>(Reuse.Transient);
        Container.Register<BasicControlView>(Reuse.Transient);
        Container.Register<HomeView>(Reuse.Transient);
        Container.Register<AboutView>(Reuse.Transient);
        Container.Register<DefaultView>(Reuse.Transient);

        //启动入口
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var navigationService = Container.Resolve<INavigationService>();
            var mainWindow = Container.Resolve<MainWindow>();
            mainWindow.DataContext = Container.Resolve<MainViewModel>();
            desktop.MainWindow = mainWindow;

            // 设置默认导航
            //navigationService.NavigateTo<HomeViewModel>();
        }
        base.OnFrameworkInitializationCompleted();
    }
}
