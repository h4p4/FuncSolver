using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.ViewModels
{
    public partial class FunctionViewModel : ObservableObject
    {
        [ObservableProperty] private double _x;
        [ObservableProperty] private double _y;
        [ObservableProperty] private double _a;
        [ObservableProperty] private double _b;
        [ObservableProperty] private double _c;
        [ObservableProperty] private double _power;

        public double Result => _a * Math.Pow(_x, _power) + _b * Math.Pow(_y, _power - 1) + _c;
        public string Title { get; set; }
        public Function(string title, int power)
        {
            Title = title;
            _power = power;
        }



    }
}
