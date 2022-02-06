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

namespace WpfMVVM_Project.Commands.ProductosCom
{
    class DeleteProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("¿Desea borrar este producto?", "Borrar", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    //bool borrar = ProductosDBHandler.borrarProducto(infoViewModel.ProductosModel);
                    RequestModel requestModel = new RequestModel();
                    requestModel.route = "/products";
                    requestModel.method = "DELETE";
                    requestModel.data = infoViewModel.ProductosModel._id;
                    ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);
                    if (responseModel.resultOk)
                    {

                        MessageBox.Show("Se ha borrado el producto", "Borrar");

                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar el producto", "Borrar");
                    }
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        public InfoViewModel infoViewModel;

        public DeleteProductoCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }
    }
}
