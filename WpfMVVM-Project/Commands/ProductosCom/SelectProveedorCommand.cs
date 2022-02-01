using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductosCom
{
    class SelectProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is string)
            {
                string campa = parameter.ToString();
                listaP = ProveedoresDBHandler.cargarListaProveedores();
                foreach (ProveedoresModel pd in listaP)
                {
                    if(pd.Nombre.Equals(campa))
                    {
                       /* infoViewModel.ProveedrCif = pd._id;
                        infoViewModel.ProveedrNombre = pd.Nombre;
                        infoViewModel.ProveedrPoblacion = pd.Poblacion;
                        infoViewModel.ProveedrTelefono = pd.Telefono;*/
                    }
                    
                }
                  
            }
        }

        public InfoViewModel infoViewModel;
        private ObservableCollection<ProveedoresModel> listaP;

        public SelectProveedorCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }
    }
}
