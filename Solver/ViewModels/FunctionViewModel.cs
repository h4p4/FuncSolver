using CommunityToolkit.Mvvm.ComponentModel;
using Solver.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solver.ViewModels
{
    public partial class FunctionViewModel : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<FunctionalVector2> _valuesXY;
        [ObservableProperty] private float _a = 0;
        [ObservableProperty] private float _b = 0;
        [ObservableProperty] private float _c = 0;
        [ObservableProperty] private float _power = 1;
        [ObservableProperty] private string _title;


        public FunctionViewModel(string title, int power)
        {
            Title = title;
            _power = power;
            ValuesXY = new()
            {
                new(1.0f, 2.0f, GetResult(1.0f, 2.0f)),
                new(1.0f, 2.0f, GetResult(1.0f, 2.0f)),
                new(1.0f, 2.0f, GetResult(1.0f, 2.0f)),
            };
        }
        private float GetResult(float x, float y) =>
            (float)(A * Math.Pow(x, Power) + A * Math.Pow(y, Power - 1) + C);
    }
}
