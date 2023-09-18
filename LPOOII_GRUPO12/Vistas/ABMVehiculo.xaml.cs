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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ABMVehiculo.xaml
    /// </summary>
    public partial class ABMVehiculo : Window
    {
        private TipoVehiculo nuevoVehiculo = new TipoVehiculo();

        public ABMVehiculo()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

            Console.WriteLine(textCodigo.Text + " - " + textDescripcion.Text + " - " + textTarifa.Text);

            if (textCodigo.Text != "" && textDescripcion.Text != "" && textTarifa.Text != "") {

                nuevoVehiculo.Tv_TVCodigo = int.Parse(textCodigo.Text);
                nuevoVehiculo.Tv_Descripcion = textDescripcion.Text;
                nuevoVehiculo.Tv_Tarifa = decimal.Parse(textTarifa.Text);

                if (nuevoVehiculo != null) {

                    if (MessageBox.Show("¿Desea registrar al vehiculo?", "Registrar Vehiculo", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {

                        textCodigo.Text = "";
                        textDescripcion.Text = "";
                        textTarifa.Text = "";

                        MessageBox.Show("Codigo: " + nuevoVehiculo.Tv_TVCodigo + "\r\n" + "Descripcion: " + nuevoVehiculo.Tv_Descripcion + "\r\n" + "Tarifa: " + nuevoVehiculo.Tv_Tarifa, "Vehiculo Registrado");
                        this.Close();

                    }

                }

            }
            else
                MessageBox.Show("Ingrese datos", "Error");

        }

    }
}
