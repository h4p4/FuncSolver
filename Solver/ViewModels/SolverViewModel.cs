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
    public partial class SolverViewModel : ObservableObject
    {
        [ObservableProperty] private ObservableCollection<FunctionViewModel> _functionsList;
        [ObservableProperty] private FunctionViewModel _selectedFunction;
        public SolverViewModel()
        {
            _functionsList = new ObservableCollection<FunctionViewModel>()
            {
                { new FunctionViewModel("Линейная", 1) },
                { new FunctionViewModel("Квадратичная", 2) },
                { new FunctionViewModel("Кубическая", 3) },
                { new FunctionViewModel("4-й степени", 4) },
                { new FunctionViewModel("5-й степени", 5) },
            };
            _selectedFunction = _functionsList.First();
        }
    }
}
