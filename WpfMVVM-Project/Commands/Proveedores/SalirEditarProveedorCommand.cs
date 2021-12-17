using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.Proveedores
{
    class SalirEditarProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            homeViewModel.CurrentProveedores = (Models.ProveedoresModel)homeViewModel.SelectedProveedores.Clone();
        }


        public HomeViewModel homeViewModel;

        public SalirEditarProveedorCommand(HomeViewModel homeViewModel)
        {
            this.homeViewModel = homeViewModel;
        }


    }
}
