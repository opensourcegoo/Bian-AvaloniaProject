using AvaloniaApplication_Start.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication_Start.Model
{
    public class Person: ViewModelBase
    {
		private string _name;
		public string Name
		{
			get => _name;
			set => this.RaiseAndSetIfChanged(ref _name, value);
		}

		private int _age;
		public int Age
		{
			get => _age;
			set => this.RaiseAndSetIfChanged(ref _age, value);
		}
	}
}
