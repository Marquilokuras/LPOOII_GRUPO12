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
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (textCodigo.Text != "" && textDescripcion.Text != "" && textTarifa.Text != "" && textImagen.Text != "")
            {
                int codigo= 0;
                decimal tarifa = 0;

                if (int.TryParse(textCodigo.Text, out codigo) && decimal.TryParse(textTarifa.Text, out tarifa))
                {
                    nuevoVehiculo.Tv_TVCodigo = codigo;
                    nuevoVehiculo.Tv_Descripcion = textDescripcion.Text;
                    nuevoVehiculo.Tv_Tarifa = tarifa;
                    nuevoVehiculo.Tv_Imagen = textImagen.Text;

                    Console.WriteLine(nuevoVehiculo);

                    if (nuevoVehiculo != null)
                    {
                        if (MessageBox.Show("¿Desea registrar al vehiculo?", "Registrar Vehiculo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            TrabajarTiposVehiculo.AgregarTipoVehiculo(nuevoVehiculo);
                            textCodigo.Text = "";
                            textDescripcion.Text = "";
                            textTarifa.Text = "";
                            textImagen.Text = "";
                            MessageBox.Show("Tipo Vehiculo Guardado con Exito!\nDatos del Vehiculo Guardado: \n"+nuevoVehiculo, "Exito");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese valores numéricos válidos para Código y Tarifa", "Error");
                }
            }
            else
            {
                MessageBox.Show("Ingrese datos en todos los campos", "Error");
            }
        }



        private void btnVerVehiculos_Click(object sender, RoutedEventArgs e)
        {
            GrillaVehiculos grillaVehiculos = new GrillaVehiculos();
            grillaVehiculos.Show();
        }

        private void textCodigo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void textTarifa_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && !char.IsPunctuation(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

    }
}
