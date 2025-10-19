using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.Common
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? param)
        {
            if(param is null) return new TextBlock() { Text = "not found : null"};
            var name2 = param.GetType().FullName;
            var name = param.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);
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
