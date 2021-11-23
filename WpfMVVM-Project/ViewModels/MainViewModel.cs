using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.Commands;
using WpfMVVM_Project.Models;

namespace WpfMVVM_Project.ViewModels
{
    class MainViewModel
    {
        
        public TextModel textmodel { set; get; }

        public HomeViewModel SelectedViewModel { set; get; }

        public ICommand UpdateViewCommand { set; get;}


        public MainViewModel()
        {
            textmodel = new TextModel();
            textmodel.Marca = "Nike";
            textmodel.Referencia = "1234";

            UpdateViewCommand = new UpdateViewCommand();

            SelectedViewModel = new HomeViewModel();
        }
    }
}
