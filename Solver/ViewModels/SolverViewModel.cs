using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Solver.ViewModels;

namespace Solver.ViewModels
{
    /// <summary>
    /// Основная ViewModel, в которой инициализируется список функций и выбранная функция.
    /// </summary>
    public partial class SolverViewModel : ObservableObject
    {
        /// <summary>
        /// Список функций.
        /// </summary>
        [ObservableProperty] private ObservableCollection<FunctionViewModel> _functionsList;
        /// <summary>
        /// Выбранная функция из списка функций <see cref="FunctionsList"/>
        /// </summary>
        [ObservableProperty] private FunctionViewModel _selectedFunction;
        public SolverViewModel()
        {
            FunctionsList = new ObservableCollection<FunctionViewModel>()
            {
                { new FunctionViewModel("Линейная", 1) },
                { new FunctionViewModel("Квадратичная", 2) },
                { new FunctionViewModel("Кубическая", 3) },
                { new FunctionViewModel("4-й степени", 4) },
                { new FunctionViewModel("5-й степени", 5) }
            };
            SelectedFunction = _functionsList.First();
        }
    }
}
