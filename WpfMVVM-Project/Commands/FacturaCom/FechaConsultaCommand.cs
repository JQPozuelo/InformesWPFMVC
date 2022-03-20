using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.FacturaCom
{
    class FechaConsultaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool funciona = consultasViewModel.updateViewCommand.reportViewModel.GenerarInformePorFecha(consultasViewModel.FechaSL);
            if (funciona)
            {
                consultasViewModel.updateViewCommand.Execute("Reports");
            }
            else
            {
                MessageBox.Show("No se encontro la factura", "Facturas", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public ConsultasViewModel consultasViewModel { get; set; }
        public FechaConsultaCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;
        }
    }
}
