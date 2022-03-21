using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM_Project.Services.DataSet;

namespace WpfMVVM_Project.ViewModels
{
    class ReportViewModel : ViewModelBase
    {
        public string pdfData { get; set; }
        ReportViewer myReport { get; set; }
        ReportDataSource rds { get; set; }

        private string CurrentPath = Environment.CurrentDirectory;
        private string InformePorCliente = "Reports/InformeClienteProducto.rdlc";
        private string InformePorFactura = "Reports/InformeFacturaProducto.rdlc";
        private string InformePorFecha = "Reports/InformePorFecha.rdlc";
        private string InformeEntreFechas = "Reports/InformeEFechas.rdlc";
        public ReportViewModel()
        {
            myReport = new ReportViewer();
            rds = new ReportDataSource();
        }

        public bool GenerarInformePorCliente(string dni)
        {
            rds.Name = "DataSet1";
            DataTable dt = DataSetHandler.GetDataByDniClienteInforme(dni);
            if(dt.Rows.Count > 0)
            {
                rds.Value = dt;
                rds.Value = DataSetHandler.GetDataByDniClienteInforme(dni);
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeClienteProducto.rdlc";
                //myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformePorCliente);
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            else 
            {
                return false;
            }
        }
        public bool GenerarInformePorFactura(int idFactura)
        {
            rds.Name = "DataSet1";
            DataTable dt = DataSetHandler.GetDataByIdFacturaInforme(idFactura);
            if (dt.Rows.Count > 0)
            {
                rds.Value = dt;
                rds.Value = DataSetHandler.GetDataByIdFacturaInforme(idFactura);
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeFacturaProducto.rdlc";
                //myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformePorFactura);
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GenerarInformePorFecha(DateTime fecha)
        {
            rds.Name = "DataSet1";
            DataTable dt = DataSetHandler.GetDataByFechaSInforme(fecha);
            if (dt.Rows.Count > 0)
            {
                rds.Value = dt;
                rds.Value = DataSetHandler.GetDataByFechaSInforme(fecha);
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformePorFecha.rdlc";
                //myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformePorFecha);
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GenerarInformePorFechas(DateTime fechain, DateTime fechafn)
        {
            rds.Name = "DataSet1";
            DataTable dt = DataSetHandler.GetDataByFechas(fechain, fechafn);
            if (dt.Rows.Count > 0)
            {
                rds.Value = dt;
                rds.Value = DataSetHandler.GetDataByFechas(fechain, fechafn);
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformePorFecha.rdlc";
                //myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformePorFecha);
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GenerarInformeClienteFechas(string dni, DateTime fechain, DateTime fechafn)
        {
            rds.Name = "DataSet1";
            DataTable dt = DataSetHandler.GetDataByCDFechas(dni, fechain, fechafn);
            if (dt.Rows.Count > 0)
            {
                rds.Value = dt;
                rds.Value = DataSetHandler.GetDataByCDFechas(dni, fechain, fechafn);
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeClienteProducto.rdlc";
                //myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformePorFecha);
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
