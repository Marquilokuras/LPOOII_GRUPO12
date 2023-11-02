using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;
using System.Data;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for GrillaVehiculos.xaml
    /// </summary>
    public partial class GrillaVehiculos : Window
    {
        public GrillaVehiculos()
        {
            InitializeComponent();
        }

        private void load_Vehiculos(object sender, RoutedEventArgs e) 
        {
            DataTable dtVehiculos = TrabajarTiposVehiculo.TraerTiposVehiculo();
            dgVehiculos.DataContext = dtVehiculos;
        }

    }
}
