﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Project.Models
{
    class ListaProductoModel : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        private ProductosModel productoModel { get; set; }
        public ProductosModel ProductoModel
        {
            get { return productoModel; }
            set
            {
                productoModel = value;
                OnPropertyChanged(nameof(ProductoModel));
            }
        }
        private int cantidad { get; set; }
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                OnPropertyChanged(nameof(Cantidad));
            }
        }

        private double total { get; set; }
        public double Total
        {
            get { return total; }
            set
            {
                total = value;
                OnPropertyChanged(nameof(Total));
            }
        }
    }
}
