using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Services
{
    public class ProductosDBHandler
    {
        private static ObservableCollection<ProductosModel> listaProductos = new ObservableCollection<ProductosModel>();

        //private static ObservableCollection<string> listaPr = new ObservableCollection<string>();

        //private static ObservableCollection<ProveedoresModel> listaPr = new ObservableCollection<ProveedoresModel>();

        private static bool cargado = false;
        /*public static void cargarLista(ObservableCollection<string> listaProveedores)
        {
            Random r = new Random();
            if (cargado == false)
            {
                for (int i = 0; i < 8; i++)
                {
                    ProductosModel a = new ProductosModel();
                    a._id = i.ToString();
                    //a.Proveedor.Add("Campa " + r.Next(1,4));
                    a.Marca = "Marca " + i.ToString();
                    a.Categoria = "Categoria " + i.ToString();
                    a.Color = "Color " + i.ToString();
                    a.Bastidor = "Bastidor " + i.ToString();
                    a.Descripcion = "Descripcion " + i.ToString();
                    a.Precio = r.Next(1, 50);
                    a.FechaEntrada = DateTime.Today;
                    a.Stock = r.Next(5, 500);
                    listaProductos.Add(a);
                    cargado = true;
                }
            }

        }*/
        public static bool NuevoProducto(ProductosModel productos)
        {
            bool okInsertar = false;
            try
            {
                listaProductos.Add(productos);
                okInsertar = true;
            }
            catch (Exception ex) { }
            return okInsertar;
        }

        public static ObservableCollection<ProductosModel> busquedaProductos(string palabra)
        {
            ObservableCollection<ProductosModel> lista = new ObservableCollection<ProductosModel>();
            foreach (ProductosModel p in listaProductos)
            {
                string precio = p.Precio.ToString();
                string stock = p.Stock.ToString();
                
                if (p._id.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (p.Categoria.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (p.Descripcion.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (p.Marca.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (precio.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (stock.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (p.Color.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (p.Bastidor.Equals(palabra))
                {
                    lista.Add(p);
                }
                else if (p.FechaEntrada.Equals(palabra))
                {
                    lista.Add(p);
                }

            }
            return lista;
        }

        public static ObservableCollection<ProductosModel> ObtenerListaProductos()
        {
            return listaProductos;
        }

       

        /*public static ObservableCollection<string> ObtenerPr()
        {
            return listaPr;
        }*/

        public static bool borrarProducto(ProductosModel producto)
        {
            bool okBorrar = false;
            try
            {
                foreach (ProductosModel p in listaProductos)
                {
                    if (p._id.Equals(producto._id))
                    {
                        listaProductos.Remove(p);
                        okBorrar = true;
                        break;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return okBorrar;
        }
        public static bool GuardarProducto(ProductosModel productos)
        {
            bool okEGuardar = false;

            foreach (ProductosModel e in listaProductos)
            {
                if (e._id == productos._id)
                {
                    
                    e.Bastidor = productos.Bastidor;
                    e.FechaEntrada = productos.FechaEntrada;
                    e.Categoria = productos.Categoria;
                    e.Color = productos.Color;
                    e.Descripcion = productos.Descripcion;
                    e.Precio = productos.Precio;
                    //e.Proveedor = productos.Proveedor;
                    e.Marca = productos.Marca;
                    e.Stock = productos.Stock;
                    okEGuardar = true;
                    break;
                }

            }

            return okEGuardar;
        }
    }
}

