using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMVVM_Project.ViewModels;

namespace WpfMVVM_Project.Views
{
    /// <summary>
    /// Lógica de interacción para ConsultasView.xaml
    /// </summary>
    public partial class ConsultasView : UserControl
    {
        public ConsultasView()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            cbClienteFechas.Visibility = Visibility.Visible;
            
        }

        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            cbClienteFechas.Visibility = Visibility.Collapsed;
            txtCliente.Visibility = Visibility.Collapsed;
        }
    }
}
