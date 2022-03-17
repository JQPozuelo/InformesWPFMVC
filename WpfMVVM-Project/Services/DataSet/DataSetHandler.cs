using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.Models;
using WpfMVVM_Project.Services.DataSet.DataSetInformeTableAdapters;

namespace WpfMVVM_Project.Services.DataSet
{
    class DataSetHandler
    {
        private static ClienteTableAdapter clienteAdapter = new ClienteTableAdapter();
        private static FacturaTableAdapter facturasAdapter = new FacturaTableAdapter();
        private static DetalleFacturaTableAdapter detallesfacturaAdapter = new DetalleFacturaTableAdapter();

        public static bool insertarFactura(string dNI, DateTime fechaFactura, double totalFactura, ObservableCollection<ListaProductoModel> listaProductosC)
        {
            try
            {
                facturasAdapter.Insert(dNI, fechaFactura, (decimal?)totalFactura);
                DataRow ultimoRegistro = facturasAdapter.GetData().Last();
                int idUltimaFactura = (int)ultimoRegistro["Identificador"];
                foreach (ListaProductoModel p in listaProductosC)
                { 
                    detallesfacturaAdapter.Insert(idUltimaFactura, p.ProductoModel._id, p.ProductoModel.Descripcion ,p.Cantidad, p.ProductoModel.Precio);
                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        /*internal static bool insertarFactura(string dNI, DateTime fechaFactura, double totalFactura, ObservableCollection<ListaProductoModel> listaProductosC)
        {
            throw new NotImplementedException();
        }*/

        /*public static string GetDataByDNIC(string dni)
            {
               try
               {
                   DataTable clienteDT = clienteAdapter.GetDataByDNIC(dni);
                   DataRow clienteRow = clienteDT.Rows[0];
                   string dniCliente = (string)clienteRow["DNI"];
                   return dniCliente;
               }
               catch
               {
                   return "";
               }
            }*/

        public static ObservableCollection<ClienteModel> getAllClientes()
        {
            DataTable clientes = clienteAdapter.GetData();
            ObservableCollection<ClienteModel> listaClientes = new ObservableCollection<ClienteModel>();

            foreach (DataRow cliente in clientes.Rows)
            {
                ClienteModel myCliente = new ClienteModel();
                myCliente.DNI = cliente["DNI"].ToString();
                myCliente.Nombre = cliente["nombre"].ToString();
                myCliente.Direccion = cliente["direccion"].ToString();
                myCliente.Telefono = cliente["telefono"].ToString();
                myCliente.Email = cliente["email"].ToString();
                listaClientes.Add(myCliente);
            }
            return listaClientes;
        }
    }
}
