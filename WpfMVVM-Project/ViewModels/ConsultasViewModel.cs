using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands;
using WpfMVVM_Project.Commands.FacturaCom;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.ViewModels
{
    internal class ConsultasViewModel : ViewModelBase
    {
        public ICommand UpdateClienteCommand { get; set; }

        public ICommand DniClienteConsultCommand { get; set; }

        public ICommand IdFacturaCommand { get; set; }

        public ICommand FechaConsultaCommand { get; set; }
        private ClienteModel clienteM { get; set; }
        public ClienteModel ClienteM
        {
            get { return clienteM; }
            set
            {
                clienteM = value;
                OnPropertyChanged(nameof(ClienteM));
            }
        }
        private ObservableCollection<ClienteModel> listaClientes { set; get; }
        public ObservableCollection<ClienteModel> ListaClientes
        {
            get { return listaClientes; }
            set
            {
                listaClientes = value;
                OnPropertyChanged(nameof(ListaClientes));
            }
        }

        public int idFactura { get; set; }
        public DateTime FechaSL { set; get; }
        public DateTime FechaSI { set; get; }
        public DateTime FechaSF { set; get; }

        public UpdateViewCommand updateViewCommand { set; get; }
        public ConsultasViewModel( UpdateViewCommand updateViewCommand)
        {
            this.updateViewCommand = updateViewCommand;
            ClienteM = new ClienteModel();
            UpdateClienteCommand = new UpdateClienteCommand(this);
            DniClienteConsultCommand = new DniClienteConsultCommand(this);
            FechaConsultaCommand = new FechaConsultaCommand(this);
            IdFacturaCommand = new IdFacturaCommand(this);
            ListaClientes = new ObservableCollection<ClienteModel>();

            FechaSI = DateTime.Today;
            FechaSL = DateTime.Today;
            FechaSF = DateTime.Today;
        }
    }
}
