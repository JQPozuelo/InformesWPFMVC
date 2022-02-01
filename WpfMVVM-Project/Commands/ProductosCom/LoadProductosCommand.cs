using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductosCom
{
    class LoadProductosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           
                //ProductosDBHandler.cargarLista(infoViewModel.ListaProveedores);
                infoViewModel.ListaProductos = ProductosDBHandler.ObtenerListaProductos();
          
            
        }

        private InfoViewModel infoViewModel;
        public LoadProductosCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }
    }
}
