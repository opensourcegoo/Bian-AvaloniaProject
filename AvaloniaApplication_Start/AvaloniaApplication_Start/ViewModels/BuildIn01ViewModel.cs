using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.ViewModels
{
    public class BuildIn01ViewModel : ViewModelBase
    {
        //public ReactiveCommand<object, Unit> TestLoadCommand { get; }
        public ReactiveCommand<Unit, Unit> RepeatCommand { get; set; }

        public ReactiveCommand<SpinEventArgs, Unit> SpinnedCommand { get; set; }

        private string _repeatContent;
        //set { _mainName = value; this.RaiseAndSetIfChanged(ref _mainName, value); }
        public string RepeatConent
        {
            get { return _repeatContent; }
            set { this.RaiseAndSetIfChanged(ref _repeatContent, value); }
        }

        private double _numericUpDownValue;
        public double NumericUpDownValue
        {
            get { return _numericUpDownValue; }
            set { this.RaiseAndSetIfChanged(ref _numericUpDownValue, value); }
        }

        #region SplitButton的颜色选择器实现

        public List<Color> ColorList { get; set; } = new List<Color>()
        {
            Colors.Beige, Colors.Yellow, Colors.Violet,Colors.BlanchedAlmond,Colors.Crimson,Colors.Chartreuse,Colors.DarkKhaki,
            Colors.Black, Colors.AliceBlue, Colors.Aqua,Colors.DeepSkyBlue,Colors.Sienna,Colors.SlateGray,Colors.MediumSlateBlue,
            Colors.FloralWhite, Colors.Fuchsia, Colors.CornflowerBlue,Colors.Honeydew,Colors.HotPink,Colors.MistyRose,Colors.Lime,
        };

        private Color _selectedColor;
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set { this.RaiseAndSetIfChanged(ref _selectedColor, value); }
        }
        #endregion

        int i = 0;
        public BuildIn01ViewModel()
        {
            RepeatConent = "Ava";
            NumericUpDownValue = 0.0;
            RepeatCommand = ReactiveCommand.Create(() =>
            {
                i++;
                RepeatConent = i.ToString();
            });

            SpinnedCommand = ReactiveCommand.Create<SpinEventArgs>(s =>
            {
                double delta = s.Direction == SpinDirection.Increase ? NumericUpDownValue : -NumericUpDownValue;
            });
            SelectedColor = ColorList.FirstOrDefault();
        }
    }
}
