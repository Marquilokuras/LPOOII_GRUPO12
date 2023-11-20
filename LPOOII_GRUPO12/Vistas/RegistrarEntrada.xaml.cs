using System;
using System.Data;
using System.Windows;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for RegistrarEntrada.xaml
    /// </summary>
    public partial class RegistrarEntrada : Window
    {
        public RegistrarEntrada()
        {
            InitializeComponent();

            // Cargar tipos de vehículo en el ComboBox
            CargarTiposVehiculo();
        }

        private void CargarTiposVehiculo()
        {
            try
            {
                DataTable dtTiposVehiculo = TrabajarTiposVehiculo.TraerTiposVehiculo();

                comboTiposVehiculo.ItemsSource = dtTiposVehiculo.DefaultView;
                comboTiposVehiculo.DisplayMemberPath = "tv_Descripcion";
                comboTiposVehiculo.SelectedValuePath = "tv_TVCodigo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de vehículo: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegistrarEntrada_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Entrada registrada con éxito", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}













