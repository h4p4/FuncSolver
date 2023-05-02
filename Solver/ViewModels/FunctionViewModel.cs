using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.ViewModels
{
    public partial class FunctionViewModel : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<(double x, double y)> _valuesXY;
        [ObservableProperty] private double _a = 0;
        [ObservableProperty] private double _b = 0;
        [ObservableProperty] private double _c = 0;
        [ObservableProperty] private double _power = 1;
        [ObservableProperty] private string _title;

        public ObservableCollection<double> Results
        {
            get
            {
                foreach (var item in _valuesXY)
                {
                    Results.Add(_a* Math.Pow(item.x, _power) + _b * Math.Pow(item.y, _power - 1) + _c);
                }
                
            }
        }
        public FunctionViewModel(string title, int power)
        {
            Title = title;
            _power = power;
        }



    }
}
