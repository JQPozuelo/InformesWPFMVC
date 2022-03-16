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

namespace WpfMVVM_Project.Commands.FacturaCom
{
    class ComboFormulario : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            RequestModel requestModel = new RequestModel();
            requestModel.route = "/products";
            requestModel.method = "GET";
            requestModel.data = "all";

            ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

            if (responseModel.resultOk)
            {
                formularioViewModel.ListaProductos = JsonConvert.DeserializeObject<ObservableCollection<ProductosModel>>((string)responseModel.data);
            }
        }

        private FormularioViewModel formularioViewModel { set; get; }
        public ComboFormulario(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
