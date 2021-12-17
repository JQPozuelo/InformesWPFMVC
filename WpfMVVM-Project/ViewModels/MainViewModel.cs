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
    class MainViewModel : ViewModelBase 
    {

        private ViewModelBase selectedViewModel { set; get; }
        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set 
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ICommand UpdateViewCommand { set; get;}


        public MainViewModel()
        {
            SelectedViewModel = new ViewModelBase();
            UpdateViewCommand = new UpdateViewCommand(this);

        }
    }
}
