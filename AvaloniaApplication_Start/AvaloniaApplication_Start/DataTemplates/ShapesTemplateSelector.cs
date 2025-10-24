using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.Templates;
using AvaloniaApplication_Start.Model;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.DataTemplates
{
    public class ShapesTemplateSelector : IDataTemplate
    {
        public Control? Build(object? param)
        {
          return null;
        }


        public bool Match(object? data)
        {
            return false;
        }
           
    }
}
