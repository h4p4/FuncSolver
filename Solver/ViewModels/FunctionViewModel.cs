using CommunityToolkit.Mvvm.ComponentModel;
using Solver.DataTypes;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Solver.ViewModels
{
    /// <summary>
    /// Класс, представляющий собой функцию, со значениями a, b, c.
    /// И списком значений x, y
    /// </summary>
    public partial class FunctionViewModel : ObservableObject
    {
        private float _a = 0;
        private float _b = 0;
        private float _c = 0;

        /// <summary>
        /// Список возможных значений аргумента <see cref="C"/>
        /// </summary>
        [ObservableProperty] private ObservableCollection<float> _cValues;

        /// <summary>
        /// Список всех заданных пользователем значений <see cref="FunctionalVector2.X"/>
        /// и <see cref="FunctionalVector2.Y"/>
        /// </summary>
        [ObservableProperty] private ObservableCollection<FunctionalVector2> _valuesXY;

        /// <summary>
        /// Степень уравнения <see cref="FunctionViewModel"/>.
        /// </summary>
        [ObservableProperty] private int _power = 1;

        /// <summary>
        /// Название функции. Например: Уравнение первой степени <see cref="Power"/>.
        /// </summary>
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
            InitCValues();
        }

        /// <summary>
        /// Возвращает или устанавливает значение A. После установки значения
        /// вызывается метод <see cref="UpdateResult"/> для обновления
        /// значения f(x)(<see cref="FunctionalVector2.Result"/>).
        /// </summary>
        public float A
        {
            get => _a;
            set { SetProperty(ref _a, value); UpdateResult(); }
        }

        /// <summary>
        /// Возвращает или устанавливает значение B. После установки значения
        /// вызывается метод <see cref="UpdateResult"/> для обновления
        /// значения f(x)(<see cref="FunctionalVector2.Result"/>).
        /// </summary>
        public float B
        {
            get => _b;
            set { SetProperty(ref _b, value); UpdateResult(); }
        }

        /// <summary>
        /// Возвращает или устанавливает значение C. После установки значения
        /// вызывается метод <see cref="UpdateResult"/> для обновления
        /// значения f(x)(<see cref="FunctionalVector2.Result"/>).
        /// </summary>
        public float C
        {
            get => _c;
            set { SetProperty(ref _c, value); UpdateResult(); }
        }

        /// <summary>
        /// Возвращает новое значение <see cref="FunctionalVector2.Result"/>
        /// исходя из текущих значений <see cref="FunctionalVector2.X"/>,
        /// <see cref="FunctionalVector2.Y"/>, а также аргументов
        /// <see cref="A"/>, <see cref="B"/>, <see cref="C"/>
        /// <paramref name="x"/> Значение X <see cref="FunctionalVector2.X"/>.
        /// <paramref name="y"/> Значение Y <see cref="FunctionalVector2.Y"/>.
        /// </summary>
        public float GetResult(float x, float y) =>
            (float)(A * Math.Pow(x, Power) + B * Math.Pow(y, Power - 1) + C);

        /// <summary>
        /// Обновляет значения <see cref="FunctionalVector2.Result"/> 
        /// для каждого <see cref="FunctionalVector2"/> в <see cref="ValuesXY"/>
        /// </summary>
        private void UpdateResult()
        {
            foreach (var item in ValuesXY)
                item.Result = GetResult(item.X, item.Y);
        }

        /// <summary>
        /// Инициализирует все возможные значения <see cref="C"/> 
        /// в коллекцию <see cref="CValues"/>. Значения зависят от степени <see cref="Power"/>.
        /// </summary>
        private void InitCValues()
        {
            int zeroCount = Power - 1;
            var sb = new StringBuilder();
            for (int i = 0; i < zeroCount; i++)
                sb.Append("0");
            CValues = new();
            for (int i = 1; i <= 5; ++i)
                CValues.Add(Convert.ToInt32(i.ToString() + sb.ToString()));
            C = CValues.First();
        }

    }
}
