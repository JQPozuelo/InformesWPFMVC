using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductosCom
{
    class CargarComboProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string proveedores = parameter.ToString();
            infoViewModel.CurrentProductos.Proveedor.Add(proveedores);
        }

        public InfoViewModel infoViewModel;

        public CargarComboProveedorCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }
    }
}
