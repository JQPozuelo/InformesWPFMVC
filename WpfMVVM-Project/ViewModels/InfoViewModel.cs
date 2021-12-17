using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands.ProductosCom;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.ViewModels
{
    class InfoViewModel : ViewModelBase
    {
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
        }
    }
}
