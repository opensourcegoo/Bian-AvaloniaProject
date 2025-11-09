using Avalonia;
using Avalonia.Controls;
using Avalonia.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaApplication_Start.Common.Behaveiors
{
    /// <summary>
    /// NumericUpDown 的 Spinned 事件在 Avalonia 中的事件签名不是标准的 RoutedEventHandler而是 EventHandler<SpinEventArgs>
    /// 在Avalonia中路由事件的参数会自动传输到对应的VM中的Command中，所以要创建自定义的Command然后把事件参数传递给命令
    /// </summary>
    public class SpinInvokeCommandAction : AvaloniaObject, IAction
    {
        public static readonly StyledProperty<ICommand> CommandProperty = AvaloniaProperty.Register<SpinInvokeCommandAction, ICommand>(nameof(Command));
        public ICommand? Command
        {
            get => GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object? Execute(object? sender, object? parameter)
        {
            if (Command == null)
                return null;
            if (parameter is SpinEventArgs args)
                Command.Execute(args);
            else
                Command.Execute(null);
            return null;
        }
    }
}
