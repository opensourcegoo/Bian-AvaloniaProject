using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.Common.Enums
{
    public class MyControl : Control
    {
        
        public static readonly StyledProperty<int> ValueProperty =
       AvaloniaProperty.Register<MyControl, int>(nameof(Value), defaultValue: 0);

        public int Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        // 2. 在静态构造函数中添加类监听器
        static MyControl()
        {
            // 为这个类型添加属性变化监听器
            ValueProperty.Changed.AddClassHandler<MyControl>(OnValueChanged);
        }

        private static void OnValueChanged(MyControl control, AvaloniaPropertyChangedEventArgs args)
        {
            control.OnValueChangedImpl("3", "3");
        }

        private void OnValueChangedImpl(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
