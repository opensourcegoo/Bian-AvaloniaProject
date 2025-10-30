using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.Common
{
    /// <summary>
    /// Avalonia 在使用 IDataTemplate 渲染 Content、ItemsControl.ItemTemplate、DataTemplate 等控件时，会自动做以下事情：
    ///当一个模板生成了一个控件（View），如果这个控件的 DataContext 为空（null），
    ///Avalonia 会自动把模板的“数据源对象” (param) 赋给它的 DataContext。
    ///也就是说——这行逻辑 Avalonia 内部帮你做了：
    ///if (view.DataContext == null)
    ///view.DataContext = param;
    ///这是 Avalonia 的设计约定，用来让 ViewLocator、DataTemplate 等机制工作得更自然。
    /// </summary>
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? param)
        {
            if (param is null) return new TextBlock() { Text = "not found : null" };
            var name = param.GetType().FullName!.Replace("ViewModel", "View");
            var assembly = typeof(ViewLocator).Assembly;
            var type = assembly.GetType(name);
            //var type = Type.GetType(name);
            if (type != null)
                return (Control)Activator.CreateInstance(type)!;
            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            return data is not null && data.GetType().Name.EndsWith("ViewModel");
        }
    }
}
