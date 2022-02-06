using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM_Project.Models;
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

        public async void Execute(object parameter)
        {
            InfoView vProductos = (InfoView)parameter;
            if (infoViewModel.ProductosModel._id.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar el codigo de barras en blanco";
            }
            else if (infoViewModel.ProductosModel.Bastidor.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar el bastidor en blanco";
            }
            else if (infoViewModel.ProductosModel.Categoria.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar la categoria en blanco";
            }
            else if (infoViewModel.ProductosModel.Color.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar el color en blanco";
            }
            else if (infoViewModel.ProductosModel.FechaEntrada.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar la fecha en blanco";
            }
            else if (infoViewModel.ProductosModel.Marca.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar la marca en blanco";
            }
            else if (infoViewModel.ProductosModel.Precio.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar el precio en blanco";
            }
            else if (infoViewModel.ProductosModel.Stock.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar el stock en blanco";
            }
            else if (infoViewModel.ProductosModel.Descripcion.Equals(""))
            {
                vProductos.txtWarning.Text = "No se puede dejar la descripcion en blanco";
            }
            else
            {
                //vProductos.txtWarning.Text = "";
                MessageBoxResult result = MessageBox.Show("¿Desea realizar los cambios?", "Modificar", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        //bool okEGuardar = ProductosDBHandler.GuardarProducto(infoViewModel.ProductosModel);
                        RequestModel requestModel = new RequestModel();
                        requestModel.route = "/products";
                        requestModel.method = "PUT";
                        requestModel.data = infoViewModel.ProductosModel;
                        ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);
                        if (responseModel.resultOk)
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
