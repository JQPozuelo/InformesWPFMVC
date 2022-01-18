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

namespace WpfMVVM_Project.Commands.ProductosCom
{
    class SaveProductosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            InfoView vProductos = (InfoView)parameter;
            if (infoViewModel.CurrentProductos._id.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar el codigo de barras en blanco";
            }
            else if (infoViewModel.CurrentProductos.Bastidor.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar el bastidor en blanco";
            }
            else if (infoViewModel.CurrentProductos.Categoria.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar la categoria en blanco";
            }
            else if (infoViewModel.CurrentProductos.Color.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar el color en blanco";
            }
            else if (infoViewModel.CurrentProductos.FechaEntrada.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar la fecha en blanco";
            }
            else if (infoViewModel.CurrentProductos.Marca.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar la marca en blanco";
            }
            else if (infoViewModel.CurrentProductos.Precio.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar el precio en blanco";
            }
            else if (infoViewModel.CurrentProductos.Stock.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar el stock en blanco";
            }
            else if (infoViewModel.CurrentProductos.Descripcion.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar la descripcion en blanco";
            }
            else
            {
                vProductos.txtWarning.Text = "";
                MessageBoxResult result = MessageBox.Show("¿Desea realizar los cambios?", "Modificar", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        bool okEGuardar = ProductosDBHandler.GuardarProducto(infoViewModel.CurrentProductos);
                        if (okEGuardar)
                        {
                            MessageBox.Show("Proveedor modificado con exito", "Modificar");

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

        public InfoViewModel infoViewModel;

        public SaveProductosCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }
    }
}
