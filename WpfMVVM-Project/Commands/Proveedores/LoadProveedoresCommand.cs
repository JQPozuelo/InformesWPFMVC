using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.Proveedores
{
    class LoadProveedoresCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProveedoresModel proveedores = (ProveedoresModel) parameter;

            homeViewModel.CurrentProveedores = (ProveedoresModel)proveedores.Clone();
            homeViewModel.SelectedProveedores = (ProveedoresModel)proveedores.Clone();
        }

        public HomeViewModel homeViewModel { set; get; }
        public LoadProveedoresCommand(HomeViewModel homeViewModel)
        {
            this.homeViewModel = homeViewModel;
        }
    }
}
