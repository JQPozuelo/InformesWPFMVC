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
    class NewProductosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            InfoView vista = (InfoView)parameter;
            if (infoViewModel.ProductosModel._id.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar el codigo de barras en blanco";
            }
            else if (infoViewModel.ProductosModel.Bastidor.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar el bastidor en blanco";
            }
            else if (infoViewModel.ProductosModel.Categoria.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar la categoria en blanco";
            }
            else if (infoViewModel.ProductosModel.Color.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar el color en blanco";
            }
            else if (infoViewModel.ProductosModel.FechaEntrada.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar la fecha en blanco";
            }
            else if (infoViewModel.ProductosModel.Marca.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar la marca en blanco";
            }
            else if (infoViewModel.ProductosModel.Precio.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar el precio en blanco";
            }
            else if (infoViewModel.ProductosModel.Stock.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar el stock en blanco";
            }
            else if (infoViewModel.ProductosModel.Descripcion.Equals(""))
            {
                vista.txtWarning.Text = "No se puede dejar la descripcion en blanco";
            }
            else
            {
                vista.txtWarning.Text = "";
                MessageBoxResult result = MessageBox.Show("¿Desea crear este producto?", "Crear", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:

                        bool okInsertar = ProductosDBHandler.NuevoProducto(infoViewModel.ProductosModel);
                        if (okInsertar)
                        {
                            MessageBox.Show("Se ha creado el producto");
                        }
                        else
                        {
                            MessageBox.Show("Error no se pudo crear el producto");
                        }

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }


        private InfoViewModel infoViewModel;
        public NewProductosCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }
    }
}
