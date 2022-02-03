using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands.ProductosCom
{
    class LoadProductosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {

            //ProductosDBHandler.cargarLista(infoViewModel.ListaProveedores);
            //infoViewModel.ListaProductos = await ProductosDBHandler.ObtenerListaProductos();

            RequestModel requestModel = new RequestModel();
            requestModel.route = "/products";
            requestModel.method = "GET";
            requestModel.data = "all";

            ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);
            if (responseModel.resultOk)
            {
                infoViewModel.ListaProductos = JsonConvert.DeserializeObject<ObservableCollection<ProductosModel>>((string)responseModel.data);
            }


        }

        private InfoViewModel infoViewModel;
        public LoadProductosCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }
    }
}
