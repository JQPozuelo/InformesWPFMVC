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
    class BuscarPalabraCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string palabra = infoViewModel.pB;
            infoViewModel.ListaProductos = ProductosDBHandler.busquedaProductos(palabra);
        }

        public InfoViewModel infoViewModel;

        public BuscarPalabraCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }
    }
}
