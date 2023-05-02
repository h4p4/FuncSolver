using CommunityToolkit.Mvvm.ComponentModel;
using Solver.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solver.ViewModels
{
    public partial class FunctionViewModel : ObservableObject
    {
        private float _a = 0;
        private float _b = 0;
        private float _c = 0;

        [ObservableProperty] private ObservableCollection<FunctionalVector2> _valuesXY;
        [ObservableProperty] private int _power = 1;
        [ObservableProperty] private string _title;

        public FunctionViewModel(string title, int power)
        {
            Title = title;
            _power = power;
            ValuesXY = new();
            ValuesXY.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                    ValuesXY.Last().ViewModelCaller = this;
            };
        }

        public float A
        {
            get => _a;
            set { SetProperty(ref _a, value); UpdateResult(); }
        }

        public float B
        {
            get => _b;
            set { SetProperty(ref _b, value); UpdateResult(); }
        }

        public float C
        {
            get => _c;
            set { SetProperty(ref _c, value); UpdateResult(); }
        }

        public float GetResult(float x, float y) =>
            (float)(A * Math.Pow(x, Power) + B * Math.Pow(y, Power - 1) + C);

        private void UpdateResult()
        {
            foreach (var item in ValuesXY)
                item.Result = GetResult(item.X, item.Y);
        }


    }
}
