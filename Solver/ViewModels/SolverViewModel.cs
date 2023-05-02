using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Solver.ViewModels;

namespace Solver.ViewModels
{
    public partial class SolverViewModel : ObservableObject
    {
        [ObservableProperty] private readonly Dictionary<int, FunctionViewModel> _functions = new Dictionary<int, FunctionViewModel>()
        {
            { 1, new FunctionViewModel("Линейная", 1) },
            { 2, new FunctionViewModel("Квадратичная", 2) },
            { 3, new FunctionViewModel("Кубическая", 3) },
            { 4, new FunctionViewModel("4-й степени", 4) },
            { 5, new FunctionViewModel("5-й степени", 5) },
        };
    }
}
