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
    class DniClienteConsultCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(consultasViewModel.ClienteM != null)
            {
                bool funciona = consultasViewModel.updateViewCommand.reportViewModel.GenerarInformePorCliente(consultasViewModel.ClienteM.DNI);
                if (funciona)
                {
                    consultasViewModel.updateViewCommand.Execute("Reports");
                }
                else
                {
                    MessageBox.Show("Este cliente no tiene facturas", "Facturas", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un cliente", "Facturas", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           

        }

        public ConsultasViewModel consultasViewModel { set; get; }

        public DniClienteConsultCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;
        }
    }
}
