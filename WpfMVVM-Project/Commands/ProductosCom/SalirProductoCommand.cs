using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductosCom
{
    class SalirProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            infoViewModel.CurrentProductos = (Models.ProductosModel)infoViewModel.SelectedProductos.Clone();
        }

        public InfoViewModel infoViewModel;

        public SalirProductoCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }
    }
}
