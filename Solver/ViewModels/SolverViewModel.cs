using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

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
            SelectedFunction = FunctionsList.First();
        }
    }
}
