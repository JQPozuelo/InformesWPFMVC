using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMVVM_Project.Views
{
    /// <summary>
    /// Lógica de interacción para InfoView.xaml
    /// </summary>
    public partial class InfoView : UserControl, INotifyPropertyChanged
    {
        public InfoView()
        {
            InitializeComponent();
            E00EstadoInicial();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool editarActivadoId;

        public bool EditarActivadoId
        {
            get { return editarActivadoId; }
            set
            {
                editarActivadoId = value;
                OnPropertyChanged(nameof(editarActivadoId));
            }
        }

        private bool editarActivado;
        public bool EditarActivado
        {
            get { return editarActivado; }
            set
            {
                editarActivado = value;
                OnPropertyChanged(nameof(EditarActivado));
            }
        }

        private bool editarActivadoPr;
        public bool EditarActivadoPr
        {
            get { return editarActivadoPr; }
            set
            {
                editarActivadoPr = value;
                OnPropertyChanged(nameof(EditarActivadoPr));
            }
        }

        public void E00EstadoInicial()
        {
            stackPro1.Visibility = Visibility.Visible;
            stackPro2.Visibility = Visibility.Visible;
            //tablaProveedor.Visibility = Visibility.Collapsed;
            EditarActivado = true;
            EditarActivadoId = true;
            EditarActivadoPr = false;
            btnBorrarProducto.Visibility = Visibility.Collapsed;
            btnModificarProducto.Visibility = Visibility.Collapsed;
            btnCrearProducto.Visibility = Visibility.Visible;
            btnSalirProducto.Visibility = Visibility.Collapsed;
            btnGuardarProducto.Visibility = Visibility.Collapsed;
            txtWarning.Text = "";
        }

        public void E01MostrarModificador()
        {
            EditarActivadoId = false;
            EditarActivado = false;
            EditarActivadoPr = false;
            btnCrearProducto.Visibility = Visibility.Collapsed;
            btnBorrarProducto.Visibility = Visibility.Collapsed;
            btnGuardarProducto.Visibility = Visibility.Collapsed;
            btnModificarProducto.Visibility = Visibility.Visible;
            btnSalirProducto.Visibility = Visibility.Collapsed;
            //tablaProveedor.Visibility = Visibility.Collapsed;
        }

        public void E02ModificarProducto()
        {
            
            EditarActivadoId = false;
            EditarActivado = true;
            EditarActivadoPr = false;
            btnModificarProducto.Visibility = Visibility.Collapsed;
            btnGuardarProducto.Visibility = Visibility.Visible;
            btnCrearProducto.Visibility = Visibility.Collapsed;
            btnSalirProducto.Visibility = Visibility.Visible;
            btnBorrarProducto.Visibility = Visibility.Visible;
            //tablaProveedor.Visibility = Visibility.Collapsed;
        }

        public void E03MostrarProveedor()
        {
            //tablaProveedor.Visibility = Visibility.Visible;
            EditarActivadoPr = false;
        }

        private void productosListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            E01MostrarModificador();
        }

        private void btnBorrarProducto_Click(object sender, RoutedEventArgs e)
        {
            E00EstadoInicial();
        }

        private void btnModificarProducto_Click_1(object sender, RoutedEventArgs e)
        {
            E02ModificarProducto();
        }

        private void cargarProveedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            E03MostrarProveedor();
        }
    }
}
