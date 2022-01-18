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
    class NewProveedoresCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HomeView vista = (HomeView)parameter;
                if (homeViewModel.CurrentProveedores._id.Equals("") || homeViewModel.CurrentProveedores._id is null)
                {
                    vista.txtWarning.Text = "No se puede dejar el CIF en blanco";
                }
                else if (homeViewModel.CurrentProveedores.Nombre.Equals(""))
                {
                    vista.txtWarning.Text = "No se puede dejar el nombre en blanco";
                }
                else if (homeViewModel.CurrentProveedores.Poblacion.Equals(""))
                {
                    vista.txtWarning.Text = "No se puede dejar la poblacion en blanco";
                }
                else if (homeViewModel.CurrentProveedores.Telefono.Equals(""))
                {
                    vista.txtWarning.Text = "No se puede dejar el telefono en blanco";
                }
                else
                {
                    vista.txtWarning.Text = "";
                    MessageBoxResult result = MessageBox.Show("¿Desea crear este proveedor?", "Crear", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            bool okInsertar = ProveedoresDBHandler.NuevoProveedor(homeViewModel.CurrentProveedores);
                            if (okInsertar)
                            {
                                MessageBox.Show("Se ha creado el proveedor", "Crear");
                            }
                            else
                            {
                                MessageBox.Show("No se pudo crear el proveedor", "Crear");
                            }
                            break;

                        case MessageBoxResult.No:
                            break;
                    }
                }
            }

        private HomeViewModel homeViewModel;
        public NewProveedoresCommand(HomeViewModel homeViewModel)
        {
            this.homeViewModel = homeViewModel;
        }
    }
}
