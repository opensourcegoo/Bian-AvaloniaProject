using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using AvaloniaApplication_Start.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.DataTemplates
{
    /// <summary>
    /// 使用
    /// </summary>
    public class SampleIDataTemplate : IDataTemplate
    {
        public Control? Build(object? param)
        {
            var person = (Person)param!;
            var panel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new TextBlock{ Text = person.Name,Margin = new Avalonia.Thickness(5) },
                    new TextBlock{ Text = $"{person.Age} 岁"}
                }
            };
            return panel;
        }

        public bool Match(object? data)
        {
            return data is Person;
        } 

    }
}
