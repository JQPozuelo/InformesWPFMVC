using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.Services
{
    class ProveedoresDBHandler
    {
        private static ObservableCollection<ProveedoresModel> listaProveedores = new ObservableCollection<ProveedoresModel>();


        public static void CargarListaAutomatica()
        {
            Random tef = new Random();

            for (int i = 0; i < 5; i++)
            {
                ProveedoresModel pr = new ProveedoresModel();
                pr._id = "CIF: " + i.ToString();
                pr.Nombre = "Proveedor: " + i.ToString();
                pr.Poblacion = "Poblacion" + i.ToString();
                pr.Telefono = tef.Next(6789, 6990);
                listaProveedores.Add(pr);
            }

        }

        public static ObservableCollection<ProveedoresModel> cargarListaProveedores()
        {
            return listaProveedores;
        }
        public static bool BorrarProveedor(ProveedoresModel proveedores)
        {
            bool borrar = false;
            try
            {
                foreach (ProveedoresModel p in listaProveedores)
                {
                    if (p._id.Equals(proveedores._id))
                    {
                        listaProveedores.Remove(p);
                        borrar = true;
                        break;
                    }
                }
                
            }
            catch (Exception ex) { }
            return borrar;
        }


        public static bool GuardarProveedor(ProveedoresModel proveedores)
        {
            bool okEGuardar = false;

            foreach(ProveedoresModel e in listaProveedores)
            {
                if(e._id == proveedores._id)
                {
                    e.Nombre = proveedores.Nombre;
                    e.Poblacion = proveedores.Poblacion;
                    e.Telefono = proveedores.Telefono;
                    okEGuardar = true;
                    break;
                }
                
            }

            return okEGuardar;
        }

        public static bool NuevoProveedor(ProveedoresModel proveedores)
        {
            bool okInsertar = false;
            try
            {
                listaProveedores.Add(proveedores);
                okInsertar = true;
            }
            catch (Exception ex) { }
            return okInsertar;
        }

        private static ObservableCollection<string> listaProveedoresProductos = new ObservableCollection<string>();
        public static void CargarListaProveedoresProductos()
        {
            foreach (ProveedoresModel p in listaProveedores)
            {
                listaProveedoresProductos.Add(p.Nombre);
            }
        }

        public static ObservableCollection<string> ObtenerListaProveedoresProductos()
        {
            return listaProveedoresProductos;
        }
    }
}
