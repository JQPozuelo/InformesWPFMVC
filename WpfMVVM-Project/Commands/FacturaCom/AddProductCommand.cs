using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.FacturaCom
{
    class AddProductCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool existe = false;
            foreach (ListaProductoModel p in formularioViewModel.ListaProductosC)
            {
                if (p.ProductoModel._id.Equals(formularioViewModel.ProductoM.ProductoModel._id))
                {
                    p.Cantidad = formularioViewModel.ProductoM.Cantidad + p.Cantidad;
                    p.Total = p.ProductoModel.Precio * p.Cantidad;
                    existe = true;
                    break;
                }
            }
            if (!existe)
            {
                formularioViewModel.ProductoM.Total = formularioViewModel.ProductoM.ProductoModel.Precio * formularioViewModel.ProductoM.Cantidad;
                formularioViewModel.ListaProductosC.Add((ListaProductoModel)formularioViewModel.ProductoM.Clone());
            }

            formularioViewModel.Factura.PrecioTotalFactura = formularioViewModel.Factura.PrecioTotalFactura + formularioViewModel.ProductoM.Total;
        }

        private FormularioViewModel formularioViewModel { set; get; }
        public AddProductCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
