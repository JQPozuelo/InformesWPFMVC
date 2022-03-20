using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Services.DataSet;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.FacturaCom
{
    class UpdateClienteCommand : ICommand
    {
        private FormularioViewModel formularioViewModel;
        private ConsultasViewModel consultasViewModel;

        public UpdateClienteCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }

        public UpdateClienteCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            if(parameter.Equals("Formulario"))
            {
                formularioViewModel.ListaClientes = DataSetHandler.getAllClientes();
            }
            else if(parameter.Equals("Consultas"))
            {
                consultasViewModel.ListaClientes = DataSetHandler.getAllClientes();
            }

            
        }
    }
}
