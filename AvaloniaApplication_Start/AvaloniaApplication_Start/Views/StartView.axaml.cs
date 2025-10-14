using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace AvaloniaApplication_Start;

public partial class StartView : UserControl
{
    public StartView()
    {
        InitializeComponent();
    }
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Debug.WriteLine($"Click AMD={txtAMD.Text}");
        //Tf = Tc * (9 / 5) + 32
        if (double.TryParse(txtAMD.Text, out double C))
        {
            //out double C)类型参数
            var F = C * (9d / 5d) + 32;
            txtNvidia.Text = F.ToString("0.0");
        }
        else
        {
            txtAMD.Text = "0";
            txtNvidia.Text = "0";
        }
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

    }

    //什么是 Avalonia Compiled BindingsAvalonia 的 Compiled Bindings 是在编译时将绑定表达式转换为强类型 C# 代码，而不是在运行时通过反射解析属性路径
    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        //UserControl
        if (double.TryParse(txtAMD.Text, out double C))
        {
            //out double C)类型参数
            var F = C * (9d / 5d) + 32;
            txtNvidia.Text = F.ToString("0.0");
        }
        else
        {
            txtAMD.Text = "0";
            txtNvidia.Text = "0";
        }
    }
}