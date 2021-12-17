using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductosCom
{
    class NewProductosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool okInsertar = ProductosDBHandler.NuevoProducto(infoViewModel.CurrentProductos);
            if(okInsertar)
            {
                MessageBox.Show("Se ha creado el producto");
            }
            else 
            {
                MessageBox.Show("ERROR");
            }
        }

        private InfoViewModel infoViewModel;
        public NewProductosCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }
    }
}
