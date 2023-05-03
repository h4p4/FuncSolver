using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Solver.DataTypes;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Solver.ViewModels
{
    /// <summary>
    /// Класс, представляющий собой функцию, со значениями a, b, c.
    /// И списком значений x, y
    /// </summary>
    public partial class FunctionViewModel : ObservableObject
    {
        private string _aView;
        private string _bView;
        private string _cView;
        private float _a = 0;
        private float _b = 0;
        private float _c = 0;

        /// <summary>
        /// Список возможных значений аргумента <see cref="C"/>
        /// </summary>
        [ObservableProperty] private ObservableCollection<float> _cValues;

        /// <summary>
        /// Список всех заданных пользователем значений <see cref="FunctionalCoordinates.X"/>
        /// и <see cref="FunctionalCoordinates.Y"/>
        /// </summary>
        [ObservableProperty] private ObservableCollection<FunctionalCoordinates> _valuesXY;

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
            var regex = 
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
        /// значения f(x,y)(<see cref="FunctionalCoordinates.Result"/>).
        /// <para>Используется для ручной установки/получения значения A с типом <see cref="float"/> .</para>
        /// </summary>
        public float A
        {
            get => _a;
            set { SetProperty(ref _a, value); UpdateResult(); }
        }

        /// <summary>
        /// Возвращает или устанавливает значение A. После установки значения
        /// вызывается метод <see cref="TrySetFloatProperty(ref float, ref string, string)"/> для обновления
        /// значений f(x,y)(<see cref="FunctionalCoordinates.Result"/>).
        /// <para>Используется для привязки к представлению значения А с типом <see cref="string"/>.</para>
        /// </summary>
        public string AView
        {
            get
            {
                if (_aView != null) return _aView;
                return _a.ToString();
            }
            set 
            {
                if (TrySetFloatProperty(ref _a, ref _aView, value)) UpdateResult();
                OnPropertyChanged(nameof(A));
            }
        }

        /// <summary>
        /// Возвращает или устанавливает значение B. После установки значения
        /// вызывается метод <see cref="UpdateResult"/> для обновления
        /// значения f(x,y)(<see cref="FunctionalCoordinates.Result"/>).
        /// <para>Используется для ручной установки/получения значения B с типом <see cref="float"/> .</para>
        /// </summary>
        public float B
        {
            get => _b;
            set { SetProperty(ref _b, value); UpdateResult(); }
        }

        /// <summary>
        /// Возвращает или устанавливает значение B. После установки значения
        /// вызывается метод <see cref="TrySetFloatProperty(ref float, ref string, string)"/> для обновления
        /// значений f(x,y)(<see cref="FunctionalCoordinates.Result"/>).
        /// <para>Используется для привязки к представлению значения B с типом <see cref="string"/>.</para>
        /// </summary>
        public string BView
        {
            get
            {
                if (_bView != null) return _bView;
                return _b.ToString();
            }
            set
            {
                if (TrySetFloatProperty(ref _b, ref _bView, value)) UpdateResult();
                OnPropertyChanged(nameof(B));
            }
        }

        /// <summary>
        /// Возвращает или устанавливает значение C. После установки значения
        /// вызывается метод <see cref="UpdateResult"/> для обновления
        /// значения f(x,y)(<see cref="FunctionalCoordinates.Result"/>).
        /// </summary>
        public float C
        {
            get => _c;
            set { SetProperty(ref _c, value); UpdateResult(); }
        }

        /// <summary>
        /// Пробует установить значение свойства для вывода на <see cref="Views"/>.
        /// Перед установкой значения происходит проверка на то, является ли значение <see cref="float"/>
        /// <para>На самом деле я просто захардкодил проверку на float, извините.</para>
        /// </summary>
        /// <param name="floatField"></param>
        /// <param name="stringField">Ссылка на строкове поле</param>
        /// <param name="valueToSet">Значение, которое будет установлено в случае успеха.</param>
        /// <returns><see cref="true"/>: Значение было установлено. <see cref="false"/>: Значение не удалось установить</returns>
        public static bool TrySetFloatProperty(ref float floatField, ref string stringField, string valueToSet)
        {
            bool valueWasSet = false;
            if (stringField != null && int.TryParse(valueToSet.Last().ToString(), out int res))
            {
                float.TryParse(valueToSet.Replace(".", ","), out float floatRes);
                floatField = floatRes;
                valueWasSet = true;
            }
            stringField = null;
            if (valueToSet != String.Empty && valueToSet.Replace(".", ",").Last() == ',')
                if (float.TryParse(valueToSet.Replace(".", ",").Remove(valueToSet.Length - 1), out float newValueLastDot))
                {
                    stringField = newValueLastDot.ToString() + ",";
                    return false;
                }

            if (!valueWasSet && float.TryParse(valueToSet, out float newValue))
            {
                floatField = newValue;
            }
            return true;
        }

        /// <summary>
        /// Возвращает новое значение <see cref="FunctionalCoordinates.Result"/>
        /// исходя из текущих значений <see cref="FunctionalCoordinates.X"/>,
        /// <see cref="FunctionalCoordinates.Y"/>, а также аргументов
        /// <see cref="A"/>, <see cref="B"/>, <see cref="C"/>
        /// <paramref name="x"/> Значение X <see cref="FunctionalCoordinates.X"/>.
        /// <paramref name="y"/> Значение Y <see cref="FunctionalCoordinates.Y"/>.
        /// </summary>
        public float GetResult(float x, float y) =>
            (float)(A * Math.Pow(x, Power) + B * Math.Pow(y, Power - 1) + C);

        /// <summary>
        /// Обновляет значения <see cref="FunctionalCoordinates.Result"/> 
        /// для каждого <see cref="FunctionalCoordinates"/> в <see cref="ValuesXY"/>
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
