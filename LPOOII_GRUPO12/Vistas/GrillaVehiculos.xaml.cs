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
        //private CollectionView Vista;

        public GrillaVehiculos()
        {
            InitializeComponent();
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
        }

        private void load_Vehiculos(object sender, RoutedEventArgs e) 
        {
            DataTable dtVehiculos = TrabajarTiposVehiculo.TraerTiposVehiculo();
            //dgVehiculos.DataContext = dtVehiculos;
            //Vehiculos.DataContext = dtVehiculos;
            //ObjectDataProvider odp = (ObjectDataProvider)this.Resources["list_vehiculo"];

        }

    }
}
