using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services.DataSet;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.FacturaCom
{
    class FechaClienteDCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ClienteModel cliente = consultasViewModel.ClienteM;
            if(consultasViewModel.mostrarCombo == true)
            {
                if (cliente is null)
                {
                    MessageBox.Show("Debes seleccionar un cliente", "Facturas", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string dni1 = DataSetHandler.GetDataByDniC(consultasViewModel.ClienteM.DNI);
                    if (dni1.Equals(""))
                    {
                        MessageBox.Show("Debes seleccionar un cliente", "Facturas", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        bool funciona = consultasViewModel.updateViewCommand.reportViewModel.GenerarInformeClienteFechas(consultasViewModel.ClienteM.DNI, consultasViewModel.FechaSI, consultasViewModel.FechaSF);
                        if (funciona)
                        {
                            consultasViewModel.updateViewCommand.Execute("Reports");
                        }
                        else
                        {
                            MessageBox.Show("Este cliente no tiene facturas", "Facturas", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                }
            }else
            {
                bool funciona = consultasViewModel.updateViewCommand.reportViewModel.GenerarInformePorFechas(consultasViewModel.FechaSI, consultasViewModel.FechaSF);
                if (funciona)
                {
                    consultasViewModel.updateViewCommand.Execute("Reports");
                }
                else
                {
                    MessageBox.Show("No se encontro esta factura", "Facturas", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        public ConsultasViewModel consultasViewModel { get; set; }
        public FechaClienteDCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;
        }
    }
}
