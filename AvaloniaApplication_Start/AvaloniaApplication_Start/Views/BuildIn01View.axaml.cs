using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace AvaloniaApplication_Start.Views;

public partial class BuildIn01View : UserControl
{
    /// <summary>
    /// 1，Border BoxShadow的属性特点
    /// </summary>
    public BuildIn01View()
    {
        InitializeComponent();
    }

    int i = 1;
    private void rbtn_clck(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //this.t2.Text = i++.ToString();
    }

    int t1 = 0;
    private void ButtonSpinner_Spin(object? sender, SpinEventArgs e)
    {
        if (e.Direction == SpinDirection.Increase)
            this.btnspinner.Content = t1++.ToString();
        else
            this.btnspinner.Content = t1--.ToString();
    }

    private void Button_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
    }

    private void Button_PointerPressed_1(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
    }
}