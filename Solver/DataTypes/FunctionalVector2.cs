using CommunityToolkit.Mvvm.ComponentModel;
using Solver.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solver.DataTypes
{
    /// <summary>
    /// Вспомогательный класс, представляющий собой значение <see cref="X"/> и <see cref="Y"/>,
    /// а также хрянящий в себе результат <see cref="Result"/> который может задать <see cref="FunctionViewModel"/>
    /// </summary>
    public class FunctionalVector2 : ObservableObject
    {
        private float _x;
        private float _y;
        private float? _result;
        public FunctionalVector2()
        {
            X = 0; Y = 0;
        }
        /// <summary>
        /// Хранит в себе ссылку на экземпляр <see cref="FunctionViewModel"/>, внутри <see cref="ObservableCollection{T}"/>
        /// которого хранится список <see cref="FunctionalVector2"/>
        /// </summary>
        public FunctionViewModel ViewModelCaller { private get; set; }
        /// <summary>
        /// Значение переменной x, которая используется в решении функции классом <see cref="FunctionViewModel"/>
        /// </summary>
        public float X
        {
            get => _x;
            set 
            { 
                SetProperty(ref _x, value); TrySetResult();
            }
        }
        /// <summary>
        /// Значение переменной y, которая используется в решении функции классом <see cref="FunctionViewModel"/>
        /// </summary>
        public float Y
        {
            get => _y;
            set 
            { 
                SetProperty(ref _y, value); TrySetResult();
            }
        }
        /// <summary>
        /// Значение f(x).
        /// </summary>
        public float? Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        /// <summary>
        /// Пробует установить значение <see cref="Result"/>, посредством вызова <see cref="FunctionViewModel.GetResult(float, float)"/>
        /// с помощью <see cref="ViewModelCaller"/>
        /// </summary>
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
