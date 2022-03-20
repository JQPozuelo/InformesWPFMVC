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
    }
}
