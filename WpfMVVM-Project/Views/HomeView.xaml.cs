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
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl, INotifyPropertyChanged
    {
        public HomeView()
        {
            InitializeComponent();
            E00EstadoInicial();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
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
                OnPropertyChanged(nameof(editarActivado));
            }
        }
        public void E00EstadoInicial()
        {
            stackProveedor.Visibility = Visibility.Visible;
            EditarActivadoId = true;
            EditarActivado = true;
            btnBorrarProveedor.Visibility = Visibility.Collapsed;
            btnModificarProveedor.Visibility = Visibility.Collapsed;
            btnCrearProveedor.Visibility = Visibility.Visible;
            btnSalirProveedor.Visibility = Visibility.Collapsed;
            btnGuardarProveedor.Visibility = Visibility.Collapsed;
            txtWarning.Text = "";
            txtCIF.Text = "";
            txtNombre.Text = "";
            txtPoblacion.Text = "";
            txtTelefono.Text = "";
            
        }

        public void E01EstadoMostrarModificador()
        {
            stackProveedor.Visibility = Visibility.Visible;
            EditarActivadoId = false;
            EditarActivado = false;
            btnCrearProveedor.Visibility = Visibility.Collapsed;
            btnModificarProveedor.Visibility = Visibility.Visible;
            btnBorrarProveedor.Visibility = Visibility.Collapsed;
            btnSalirProveedor.Visibility = Visibility.Collapsed;
            btnGuardarProveedor.Visibility = Visibility.Collapsed;
            proveedoresListView.IsEnabled = true;
        }

        public void E02ModificarProveedor()
        {
            btnCrearProveedor.Visibility = Visibility.Collapsed;
            btnModificarProveedor.Visibility = Visibility.Collapsed;
            btnBorrarProveedor.Visibility = Visibility.Visible;
            btnSalirProveedor.Visibility = Visibility.Visible;
            btnGuardarProveedor.Visibility = Visibility.Visible;
            proveedoresListView.IsEnabled = false;

            EditarActivadoId = false;
            EditarActivado = true;

        }

        private void proveedoresListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            E01EstadoMostrarModificador();
        }

        private void btnModificarProveedor_Click(object sender, RoutedEventArgs e)
        {
            E02ModificarProveedor();
        }

        private void btnSalirProveedor_Click(object sender, RoutedEventArgs e)
        {
            //E00EstadoInicial();
            E01EstadoMostrarModificador();
        }

        private void btnBorrarProveedor_Click(object sender, RoutedEventArgs e)
        {
            E00EstadoInicial();
        }
    }
}
