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
            
            for (int i = 0; i < 5; i++)
            {
                ProveedoresModel pr = new ProveedoresModel();
                pr._id = "CIF: " + i.ToString();
                pr.Nombre = "Proveedor: " + i.ToString();
                pr.Poblacion = "Poblacion" + i.ToString();
                pr.Telefono = 45689;
                listaProveedores.Add(pr);
            }
        }

        public static bool BorrarProveedor(ProveedoresModel proveedores)
        {
            bool borrar = false;
            try
            {
                listaProveedores.Remove(proveedores);
                borrar = true;
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

        public static ObservableCollection<ProveedoresModel> ObtenerListaProveedores()
        {
            return listaProveedores;
        }
    }
}
