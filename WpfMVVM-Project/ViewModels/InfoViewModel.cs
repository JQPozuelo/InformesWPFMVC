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

        private ObservableCollection<string> listaProveedores { get; set; }
        public ObservableCollection<string> ListaProveedores
        {
            get { return listaProveedores; }
            set { listaProveedores = value; OnPropertyChanged(nameof(ListaProveedores)); }
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

        private string proveedrCif;
        public string ProveedrCif
        {
            get { return proveedrCif; }
            set 
            {
                proveedrCif = value;
                OnPropertyChanged(nameof(ProveedrCif)); 
            }
        }

        private string proveedrNombre;
        public string ProveedrNombre
        {
            get { return proveedrNombre; }
            set 
            { 
                proveedrNombre = value; 
                OnPropertyChanged(nameof(ProveedrNombre)); 
            }
        }

        private string proveedrPoblacion;
        public string ProveedrPoblacion
        {
            get { return proveedrPoblacion; }
            set 
            { 
                proveedrPoblacion = value; 
                OnPropertyChanged(nameof(ProveedrPoblacion)); 
            }
        }

        private int proveedrTelefono;
        public int ProveedrTelefono
        {
            get { return proveedrTelefono; }
            set 
            { 
                proveedrTelefono = value; 
                OnPropertyChanged(nameof(ProveedrTelefono)); 
            }
        }

        private ProductosModel currentProductos { get; set; }

        public ProductosModel CurrentProductos
        {
            get { return currentProductos; }
            set 
            {
                currentProductos = value;
                OnPropertyChanged(nameof(CurrentProductos));
            }
        }

        private ProductosModel selectedProductos;

        public ProductosModel SelectedProductos
        {
            get { return selectedProductos; }
            set
            {
                selectedProductos = value;
                OnPropertyChanged(nameof(SelectedProductos));
            }
        }

        public string pB { set; get; }
        public ICommand NewProductosCommand { set; get; }

        public ICommand LoadProductosCommand { set; get; }

        public ICommand BuscarProveedoresCommand { set; get; }

        public ICommand LoadProductoCommand { set; get; }

        public ICommand CargarComboProveedorCommand { set; get; }

        public ICommand SelectProveedorCommand { set; get; }

        public ICommand DeleteProductoCommand { set; get; }

        public ICommand BuscarPalabraCommand { set; get; }

        public ICommand SaveProductosCommand { set; get; }

        public ICommand SalirProductoCommand { set; get; }
        public InfoViewModel()
        {
            CurrentProductos = new ProductosModel();
            NewProductosCommand = new NewProductosCommand(this);
            LoadProductosCommand = new LoadProductosCommand(this);
            LoadProductoCommand = new LoadProductoCommand(this);
            BuscarProveedoresCommand = new BuscarProveedoresCommand(this);
            CargarComboProveedorCommand = new CargarComboProveedorCommand(this);
            SelectProveedorCommand = new SelectProveedorCommand(this);
            DeleteProductoCommand = new DeleteProductoCommand(this);
            BuscarPalabraCommand = new BuscarPalabraCommand(this);
            SaveProductosCommand = new SaveProductosCommand(this);
            SalirProductoCommand = new SalirProductoCommand(this);

            ListaProductos = new ObservableCollection<ProductosModel>();

            ListaProveedores = new ObservableCollection<string>() { "Campa 1", "Campa 2", "Campa 3", "Campa 4"};

            

            ProveedrCif = "";
            ProveedrNombre = "";
            ProveedrPoblacion = "";
            ProveedrTelefono = 0;
        }
    }
}
