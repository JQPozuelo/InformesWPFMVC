using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands.ProductosCom;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services;

namespace WpfMVVM_Project.ViewModels
{
    class InfoViewModel : ViewModelBase
    {

        private ObservableCollection<ProveedoresModel> listaproveedorest1 { get; set; }
        public ObservableCollection<ProveedoresModel> Listaproveedorest1
        {
            get { return listaproveedorest1; }
            set { listaproveedorest1 = value; OnPropertyChanged(nameof(Listaproveedorest1)); }
        }

        private ObservableCollection<string> listaProveedores { get; set; }
        public ObservableCollection<string> ListaProveedores
        {
            get { return listaProveedores; }
            set { listaProveedores = value; OnPropertyChanged(nameof(ListaProveedores)); }
        }

        private ObservableCollection<ProveedoresModel> listaProveedoresTFinal;
        public ObservableCollection<ProveedoresModel> ListaProveedoresTFinal
        {
            get { return listaProveedoresTFinal; }
            set { listaProveedoresTFinal = value; OnPropertyChanged(nameof(ListaProveedoresTFinal)); }
        }
        private ObservableCollection<ProductosModel> listaProductos { get; set; }

        public ObservableCollection<ProductosModel> ListaProductos 
        { 
            get
            {
                return listaProductos;
            }
            set
            {
                listaProductos = value;
                OnPropertyChanged(nameof(listaProductos));
            }
        }
        public ProductosModel CurrentProductos { get; set; }

        public ICommand NewProductosCommand { set; get; }

        public ICommand LoadProductosCommand { set; get; }
        public InfoViewModel()
        {
            CurrentProductos = new ProductosModel();
            NewProductosCommand = new NewProductosCommand(this);
            LoadProductosCommand = new LoadProductosCommand(this);
            ListaProductos = new ObservableCollection<ProductosModel>();

            ListaProveedores = new ObservableCollection<string>();
            
            listaproveedorest1 = ProveedoresDBHandler.ObtenerListaProveedores();

            ListaProveedoresTFinal = new ObservableCollection<ProveedoresModel>();
        }
    }
}
