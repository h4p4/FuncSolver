using CommunityToolkit.Mvvm.ComponentModel;
using Solver.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solver.DataTypes
{
    public class FunctionalVector2 : ObservableObject
    {
        private float _x;
        private float _y;
        private float? _result;

        public FunctionalVector2()
        {
            X = 0; Y = 0;
        }

        public FunctionViewModel ViewModelCaller { private get; set; }

        public float X
        {
            get => _x;
            set 
            { 
                SetProperty(ref _x, value); TrySetResult();
            }
        }        

        public float Y
        {
            get => _y;
            set 
            { 
                SetProperty(ref _y, value); TrySetResult();
            }
        }

        public float? Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        private void TrySetResult()
        {
            try
            {
                Result = ViewModelCaller?.GetResult(_x, _y);
            }
            catch (Exception) { throw; }
        }
    }
}
