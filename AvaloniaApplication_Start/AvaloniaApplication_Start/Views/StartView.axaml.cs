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
            //out double C)���Ͳ���
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

    //ʲô�� Avalonia Compiled BindingsAvalonia �� Compiled Bindings ���ڱ���ʱ���󶨱��ʽת��Ϊǿ���� C# ���룬������������ʱͨ�������������·��
    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        //UserControl
        if (double.TryParse(txtAMD.Text, out double C))
        {
            //out double C)���Ͳ���
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