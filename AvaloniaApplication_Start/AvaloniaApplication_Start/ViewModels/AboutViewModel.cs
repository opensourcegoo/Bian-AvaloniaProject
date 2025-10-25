using AvaloniaApplication_Start.Common;
using AvaloniaApplication_Start.Common.Enum;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AvaloniaApplication_Start.Common.Enum.ShapeTypeEnums;

namespace AvaloniaApplication_Start.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public string MainName => "这是AboutView";

        private ShapeType _selectedShapeType;

        public ShapeType SelectedShapeType
        {
            get { return _selectedShapeType; }
            set { _selectedShapeType = value; this.RaiseAndSetIfChanged(ref _selectedShapeType, value); }
        }

        public ShapeType[] AvaiableShapeTypes { get { return Enum.GetValues<ShapeType>(); } }
        
        //public ShapeType[] AvaiableShapeTypes { get; } = Enum.GetValues<ShapeType>();

        public AboutViewModel(INavigationService navigationService)
        {

        }
    }
}
