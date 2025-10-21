using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
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
        
        //TreeDataTemplate
        public Control? Build(object? param)
        {
            throw new NotImplementedException();
        }

        public bool Match(object? data)
        {
            throw new NotImplementedException();
        }
    }
}
