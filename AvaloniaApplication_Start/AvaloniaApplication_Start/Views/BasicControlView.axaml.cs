using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication_Start.Views;

public partial class BasicControlView : UserControl
{
    public BasicControlView()
    {
        InitializeComponent();
        //this.Loaded
    }

    private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {

    }
}