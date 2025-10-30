using AvaloniaApplication_Start.Common.Enums;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.ViewModels
{
    public class TemplateViewModel : ViewModelBase
    {
        private string _mainName;
        public string MainName
        {
            get => _mainName;
            set => this.RaiseAndSetIfChanged(ref _mainName, value);
        }

        private ShapeType _selectedShapeType;
        public ShapeType SelectedShapeType
        {
            get { return _selectedShapeType; }
            set => this.RaiseAndSetIfChanged(ref _selectedShapeType, value);
        }

        //read-only
        public ShapeType[] ShapeTypes { get => Enum.GetValues<ShapeType>(); }

        //普通属性 → 用 RaiseAndSetIfChanged ✅
        //计算属性（依赖属性） → 用 RaisePropertyChanged 手动通知
        //需要在变更前后处理逻辑 → 同时使用 RaisePropertyChanging 和 RaisePropertyChanged
        public TemplateViewModel()
        {
            _mainName = "100";
            _selectedShapeType = ShapeTypes.FirstOrDefault();
        }
    }
}
