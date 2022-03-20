using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Services.DataSet;
using WpfMVVM_Project.ViewModels;
using WpfMVVM_Project.Views;

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
            /*ConsultasView vista = (ConsultasView)parameter;
            if (vista.cbCliente.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Debes seleccionar un cliente", "Facturas", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {*/
                string dni = DataSetHandler.GetDataByDniC(consultasViewModel.ClienteM.DNI);
                if (dni.Equals(""))
                {
                    MessageBox.Show("Debes seleccionar un cliente", "Facturas", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else 
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
            //}
           

        }

        public ConsultasViewModel consultasViewModel { set; get; }

        //public ConsultasView consultasView { set; get; }
        public DniClienteConsultCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;
            //consultasView = new ConsultasView();
        }
    }
}
