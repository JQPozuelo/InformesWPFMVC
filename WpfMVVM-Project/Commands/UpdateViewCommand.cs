using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Commands
{
    class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine(parameter.ToString());
            string vista = parameter.ToString();
            if (vista.Equals("Home"))
            {
                MainViewModel.SelectedViewModel = new HomeViewModel();
            }
            else if (vista.Equals("Info"))
            {
                MainViewModel.SelectedViewModel = new InfoViewModel();
            }
            else if (vista.Equals("Formulario"))
            {
                MainViewModel.SelectedViewModel = new FormularioViewModel();
            }

        }

        public MainViewModel MainViewModel { set; get; }

        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            
        }
    }
}
