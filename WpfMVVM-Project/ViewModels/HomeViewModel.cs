using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands;
using WpfMVVM_Project.Commands.Proveedores;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<ProveedoresModel> listaProveedores { get; set; }

        public ObservableCollection<ProveedoresModel> ListaProveedores
        {
            get
            {
                return listaProveedores;
            }
            set
            {
                listaProveedores = value;
                OnPropertyChanged(nameof(listaProveedores));
            }
        }
        private ProveedoresModel currentProveedores { get; set; }

        public ProveedoresModel CurrentProveedores
        {
            get { return currentProveedores; }
            set
            {
                currentProveedores = value;
                OnPropertyChanged(nameof(CurrentProveedores));
            }
             
                
        }

        private ProveedoresModel selectedProveedores;

        public ProveedoresModel SelectedProveedores
        {
            get { return selectedProveedores; }
            set 
            {
                selectedProveedores = value;
                OnPropertyChanged(nameof(SelectedProveedores));
            }
        }
        public ICommand NewProveedoresCommand { set; get; }

        public ICommand LoadProveedorCommand { set; get; }

        public ICommand LoadProveedoresCommand { set; get; }

        public ICommand SalirEditarProveedorCommand { set; get; }

        public ICommand SaveProveedorCommand { set; get; }

        public ICommand DeleteProveedorCommand { set; get; }
        public HomeViewModel()
        {
            CurrentProveedores = new ProveedoresModel();
            NewProveedoresCommand = new NewProveedoresCommand(this);
            LoadProveedorCommand = new LoadProveedorCommand(this);
            LoadProveedoresCommand = new LoadProveedoresCommand(this);
            SalirEditarProveedorCommand = new SalirEditarProveedorCommand(this);
            SaveProveedorCommand = new SaveProveedorCommand(this);
            DeleteProveedorCommand = new DeleteProveedorCommand(this);
            ListaProveedores = new ObservableCollection<ProveedoresModel>();
        }
    }
}
