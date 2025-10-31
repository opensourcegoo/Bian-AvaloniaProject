using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication_Start.Views;

public partial class TemplateView : UserControl
{
    public TemplateView()
    {
        InitializeComponent();
        Control control = this; 
        
    }
    StyledProperty<string> _template;
}