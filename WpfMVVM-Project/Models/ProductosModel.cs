using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Project.Models
{
    public class ProductosModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        private string id;
        public string _id
        {
            get { return id; }
            set 
            { 
                id = value;
                OnPropertyChanged(nameof(_id));
            }
        }

        private ObservableCollection<string> proveedor;

        public ObservableCollection<string> Proveedor
        {
            get { return proveedor; }
            set 
            {
                proveedor = value;
                OnPropertyChanged(nameof(Proveedor));
            }
        }

        private string marca;

        public string Marca
        {
            get { return marca; }
            set 
            {
                marca = value;
                OnPropertyChanged(nameof(Marca));
            }
        }

        private string categoria;

        public string Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                OnPropertyChanged(nameof(Categoria));
            }
        }


        private string color;

        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        private string bastidor;

        public string Bastidor
        {
            get { return bastidor; }
            set
            {
                bastidor = value;
                OnPropertyChanged(nameof(Bastidor));
            }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                descripcion = value;
                OnPropertyChanged(nameof(Descripcion));
            }
        }

        private double precio;

        public double Precio
        {
            get { return precio; }
            set
            {
                precio = value;
                OnPropertyChanged(nameof(Precio));
            }
        }

        private DateTime fechaEntrada;

        public DateTime FechaEntrada
        {
            get { return fechaEntrada; }
            set
            {
                fechaEntrada = value;
                OnPropertyChanged(nameof(FechaEntrada));
            }
        }

        private int stock;

        public int Stock
        {
            get { return stock; }
            set
            {
                stock = value;
                OnPropertyChanged(nameof(Stock));
            }
        }
        

        public ProductosModel()
        {
            fechaEntrada = DateTime.Today;
            proveedor = new ObservableCollection<string>();
        }

    }
}
