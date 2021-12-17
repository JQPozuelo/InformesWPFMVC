using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.Proveedores
{
    class DeleteProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            MessageBoxResult result = MessageBox.Show("¿Desea borrar este proveedor?", "Borrar", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    bool borrar = ProveedoresDBHandler.BorrarProveedor(homeViewModel.CurrentProveedores);
                    if (borrar)
                    {
                        MessageBox.Show("Se ha borrado el proveedor", "Borrar");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar el proveedor", "Borrar");
                    }
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        public HomeViewModel homeViewModel { get; set; }
        public DeleteProveedorCommand(HomeViewModel homeViewModel)
        {
            this.homeViewModel = homeViewModel;
        }
    }
}
