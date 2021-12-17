using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;
using WpfMVVM_Project.Views;

namespace WpfMVVM_Project.Commands.Proveedores
{
    class SaveProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HomeView vista = (HomeView)parameter;

            if(homeViewModel.CurrentProveedores.Nombre.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar el nombre en blanco";
            }else if(homeViewModel.CurrentProveedores.Poblacion.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar la poblacion en blanco";
            }
            else if(homeViewModel.CurrentProveedores.Telefono.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar el telefono en blanco";
            }
            else
            {
                vista.txtWarning.Text = "";
                MessageBoxResult result = MessageBox.Show("¿Desea realizar los cambios?", "Modificar", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        bool okEGuardar = ProveedoresDBHandler.GuardarProveedor(homeViewModel.CurrentProveedores);
                        if (okEGuardar)
                        {
                            MessageBox.Show("Proveedor modificado con exito", "Modificar");
                            vista.E01EstadoMostrarModificador();
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar", "Modificar");
                        }
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }



            
        }


        public HomeViewModel homeViewModel { get; set; }
        public SaveProveedorCommand(HomeViewModel homeViewModel)
        {
            this.homeViewModel = homeViewModel;
        }
    }
}
