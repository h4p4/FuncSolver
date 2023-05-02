using Solver.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Solver.Views
{
    /// <summary>
    /// Основное окно, в конструкторе которого DataContext-у должна быть присвоена
    /// ViewModel <see cref="SolverViewModel"/> , отвечающая за логику взаимодействия верстки этого окна с логикой.
    /// </summary>
    public partial class SolverWindow : Window
    {
        public SolverWindow()
        {
            InitializeComponent();
            this.DataContext = new SolverViewModel();
        }
    }
}
