using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands.FacturaCom;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.ViewModels
{
    class FormularioViewModel : ViewModelBase
    {

        public ICommand UpdateClienteCommand { get; set; }
        public ICommand ComboFormulario { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand GenerarFacturaCommand { get; set; }
        public ICommand EliminarProductoCommand { get; set; }

        private ObservableCollection<ProductosModel> listaProductos { get; set; }
        public ObservableCollection<ProductosModel> ListaProductos
        {
            get { return listaProductos; }
            set
            {
                listaProductos = value;
                OnPropertyChanged(nameof(ListaProductos));
            }
        }

        private ObservableCollection<ListaProductoModel> listaProductosC { get; set; }
        public ObservableCollection<ListaProductoModel> ListaProductosC
        {
            get { return listaProductosC; }
            set
            {
                listaProductosC = value;
                OnPropertyChanged(nameof(ListaProductosC));
            }
        }

        private ListaProductoModel productoM { get; set; }
        public ListaProductoModel ProductoM
        {
            get { return productoM; }
            set
            {
                productoM = value;
                OnPropertyChanged(nameof(ProductoM));
            }
        }

        private ProductosModel currentProducto { get; set; }
        public ProductosModel CurrentProducto
        {
            get { return currentProducto; }
            set
            {
                currentProducto = value;
                OnPropertyChanged(nameof(CurrentProducto));
            }
        }

        private ClienteModel clienteM { get; set; }
        public ClienteModel ClienteM
        {
            get { return clienteM; }
            set
            {
                clienteM = value;
                OnPropertyChanged(nameof(ClienteM));
            }
        }


        private FacturaModel factura { get; set; }
        public FacturaModel Factura
        {
            get { return factura; }
            set
            {
                factura = value;
                OnPropertyChanged(nameof(Factura));
            }
        }

        private ObservableCollection<ClienteModel> listaClientes { get; set; }
        public ObservableCollection<ClienteModel> ListaClientes
        {
            get { return listaClientes; }
            set
            {
                listaClientes = value;
                OnPropertyChanged(nameof(ListaClientes));
            }
        }
        private double totalFactura { get; set; }
        public double TotalFactura
        {
            get { return totalFactura; }
            set
            {
                totalFactura = value;
                OnPropertyChanged(nameof(TotalFactura));
            }
        }

        public FormularioViewModel()
        {
            UpdateClienteCommand = new UpdateClienteCommand(this);
            AddProductCommand = new AddProductCommand(this);
            ComboFormulario = new ComboFormulario(this);
            EliminarProductoCommand = new EliminarProductoCommand(this);
            GenerarFacturaCommand = new GenerarFacturaCommand(this);

            Factura = new FacturaModel();
            ListaClientes = new ObservableCollection<ClienteModel>();
            ClienteM = new ClienteModel();
            ProductoM = new ListaProductoModel();
            ListaProductosC = new ObservableCollection<ListaProductoModel>();
            Factura.FechaFactura = DateTime.Today;
            ProductoM.Cantidad = 1;
        }
    }
}
