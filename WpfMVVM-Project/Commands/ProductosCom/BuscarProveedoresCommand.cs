using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductosCom
{
    class BuscarProveedoresCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            /*if (parameter != null)
            {
                string campa = (string)parameter;
                prueba = infoViewModel.ListaProveedores
                foreach (ProveedoresModel p in )
                {
                    if (campa.Equals(p.Nombre))
                    {

                        infoViewModel.ProveedrCif = p._id;
                        infoViewModel.ProveedrNombre = p.Nombre;
                        infoViewModel.ProveedrPoblacion = p.Poblacion;
                        infoViewModel.ProveedrTelefono = p.Telefono.ToString();
                    }
                }
            }*/
        }



        private InfoViewModel infoViewModel;
        public BuscarProveedoresCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }

      
    }
}
