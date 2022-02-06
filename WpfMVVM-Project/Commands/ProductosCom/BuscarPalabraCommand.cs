using Newtonsoft.Json;
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
    class BuscarPalabraCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            /*string palabra = infoViewModel.pB;
            infoViewModel.ListaProductos = ProductosDBHandler.busquedaProductos(palabra);*/


            if (parameter is InfoView)
            {
                InfoView vista = (InfoView)parameter;
                RequestModel requestModel = new RequestModel()
                {
                    route = "/products",
                    method = "GET",
                    data = vista.txtBuscar.Text
                };

                ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                if (responseModel.resultOk)
                {
                    vista.E00EstadoInicial();
                    infoViewModel.ProductosModel = JsonConvert.DeserializeObject<ProductosModel>((string)responseModel.data);
                }
                else
                {
                    MessageBox.Show((string)responseModel.data);
                }
            }
        }

        public InfoViewModel infoViewModel;

        public BuscarPalabraCommand(InfoViewModel infoViewModel)
        {
            this.infoViewModel = infoViewModel;
        }
    }
}
