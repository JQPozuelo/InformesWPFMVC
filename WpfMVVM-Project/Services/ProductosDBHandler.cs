using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.Services
{
    public class ProductosDBHandler
    {
        private static ObservableCollection<ProductosModel> listaProductos = new ObservableCollection<ProductosModel>();

        public static bool NuevoProducto(ProductosModel productos)
        {
            bool okInsertar = false;
            try 
            {
                listaProductos.Add(productos);
                okInsertar = true;
            }catch(Exception ex) { }
            return okInsertar;
        }

        public static ObservableCollection<ProductosModel> ObtenerListaProductos()
        {
            return listaProductos;
        }
    }
}
