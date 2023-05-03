using CommunityToolkit.Mvvm.ComponentModel;
using Solver.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Solver.DataTypes
{
    /// <summary>
    /// Вспомогательный класс, представляющий собой значение <see cref="X"/> и <see cref="Y"/>,
    /// а также хрянящий в себе результат <see cref="Result"/> который может задать <see cref="FunctionViewModel"/>
    /// </summary>
    public class FunctionalCoordinates : ObservableObject
    {
        private string _xView;
        private string _yView;
        private float _x;
        private float _y;
        private float? _result;

        public FunctionalCoordinates()
        {
            X = 0; Y = 0;
        }

        /// <summary>
        /// Хранит в себе ссылку на экземпляр <see cref="FunctionViewModel"/>, внутри <see cref="ObservableCollection{T}"/>
        /// которого хранится список <see cref="FunctionalCoordinates"/>
        /// </summary>
        public FunctionViewModel ViewModelCaller { private get; set; }

        /// <summary>
        /// Значение переменной X, которая используется в решении функции классом <see cref="FunctionViewModel"/>
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
        /// Возвращает или устанавливает значение X. После установки значения
        /// вызывается метод <see cref="FunctionViewModel.TrySetFloatProperty(ref float, ref string, string)"/> для установки
        /// значений f(x,y)(<see cref="FunctionalCoordinates.Result"/>) с помощью функции <see cref="TrySetResult".
        /// <para>Используется для привязки к представлению значения X с типом <see cref="string"/>.</para>
        /// </summary>
        public string XView
        {
            get
            {
                if (_xView != null) return _xView;
                return _x.ToString();
            }
            set
            {
                if (FunctionViewModel.TrySetFloatProperty(ref _x, ref _xView, value)) TrySetResult();
                OnPropertyChanged(nameof(X));
            }
        }

        /// <summary>
        /// Значение переменной Y, которая используется в решении функции классом <see cref="FunctionViewModel"/>
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
        /// Возвращает или устанавливает значение Y. После установки значения
        /// вызывается метод <see cref="FunctionViewModel.TrySetFloatProperty(ref float, ref string, string)"/> для установки
        /// значений f(x,y)(<see cref="FunctionalCoordinates.Result"/>) с помощью функции <see cref="TrySetResult"/>.
        /// <para>Используется для привязки к представлению значения Y с типом <see cref="string"/>.</para>
        /// </summary>
        public string YView
        {
            get
            {
                if (_yView != null) return _yView;
                return _y.ToString();
            }
            set
            {
                if (FunctionViewModel.TrySetFloatProperty(ref _y, ref _yView, value)) TrySetResult();
                OnPropertyChanged(nameof(Y));
            }
        }

        /// <summary>
        /// Значение f(x,y).
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
