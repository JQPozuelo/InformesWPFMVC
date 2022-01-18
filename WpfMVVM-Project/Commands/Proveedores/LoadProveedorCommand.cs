using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands
{
    class LoadProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProveedoresDBHandler.CargarListaAutomatica();
            homeViewModel.ListaProveedores = ProveedoresDBHandler.cargarListaProveedores();
        }

        public HomeViewModel homeViewModel { get; set; }
        public LoadProveedorCommand(HomeViewModel homeViewModel)
        {
            this.homeViewModel = homeViewModel;
        }
    }
}
