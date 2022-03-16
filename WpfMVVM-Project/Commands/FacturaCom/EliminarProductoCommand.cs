using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.FacturaCom
{
    class EliminarProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                ListaProductoModel producto = (ListaProductoModel)parameter;
                formularioViewModel.Factura.PrecioTotalFactura = formularioViewModel.Factura.PrecioTotalFactura - producto.Total;
                formularioViewModel.ListaProductosC.Remove(producto);

            }
            else
            {
                MessageBox.Show("Selecciona un producto");
            }
        }

        private FormularioViewModel formularioViewModel { set; get; }
        public EliminarProductoCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
