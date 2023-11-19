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

        private void LimpiarCampos()
        {
            textCodigo.Clear();
            textImagen.Clear();
            textDescripcion.Clear();
            textTarifa.Clear();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (formLleno())
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
                            LimpiarCampos();
                            MessageBox.Show("Tipo Vehiculo Guardado con Exito!\nDatos del Vehiculo Guardado: \n"+nuevoVehiculo, "Exito");
                            btnRegistrar.IsEnabled = false;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnBuscar.IsEnabled = false;
            btnRegistrar.IsEnabled = false;
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnBuscar.IsEnabled = !string.IsNullOrEmpty(txtBuscar.Text);
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            int codigoABuscar = 0;
            if (int.TryParse(txtBuscar.Text, out codigoABuscar))
            {
                TipoVehiculo vehiculoEncontrado = TrabajarTiposVehiculo.BuscarTipoVehiculo(codigoABuscar);

                if (vehiculoEncontrado != null)
                {
                    textCodigo.Text = vehiculoEncontrado.Tv_TVCodigo.ToString();
                    textDescripcion.Text = vehiculoEncontrado.Tv_Descripcion;
                    textTarifa.Text = vehiculoEncontrado.Tv_Tarifa.ToString();
                    textImagen.Text = vehiculoEncontrado.Tv_Imagen;

                    MessageBox.Show("Vehículo encontrado:\n" + vehiculoEncontrado.ToString(), "Éxito");

                    btnRegistrar.IsEnabled = false;
                    btnEliminar.IsEnabled = true;
                    btnModificar.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontró ningún vehículo con el código proporcionado.", "Información");
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Ingrese un código válido para buscar el vehículo.", "Error");
                LimpiarCampos();
            }
            txtBuscar.Text = "";
        }


        private void textCamposVehiculo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (formLleno())
            {
                btnRegistrar.IsEnabled = true;
            }
            else
            {
                btnRegistrar.IsEnabled = false;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (btnEliminar.IsEnabled==true)
            {
                int codigoAEliminar = Convert.ToInt32(textCodigo.Text);

                if (MessageBox.Show("¿Desea eliminar el vehículo?", "Eliminar Vehículo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    TrabajarTiposVehiculo.EliminarTipoVehiculo(codigoAEliminar);
                    LimpiarCampos();
                    MessageBox.Show("Tipo Vehiculo Eliminado con Éxito.", "Éxito");
                    btnEliminar.IsEnabled = false;
                    btnModificar.IsEnabled = false;
                }
            }
            else
            {
                MessageBox.Show("Seleccione un vehículo para eliminar.", "Error");
            }
        }

        private bool formLleno()
        {
            if (!string.IsNullOrEmpty(textCodigo.Text) &&
                   !string.IsNullOrEmpty(textDescripcion.Text) &&
                   !string.IsNullOrEmpty(textTarifa.Text) &&
                   !string.IsNullOrEmpty(textImagen.Text))
            {
                return true;
            }
            else {
                return false;
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (formLleno() && btnModificar.IsEnabled==true)
            {
                int codigoAModificar = Convert.ToInt32(textCodigo.Text);
                decimal tarifa = Convert.ToDecimal(textTarifa.Text);

                Console.WriteLine("codigoAmodificar, tarifa: " + codigoAModificar + ", " + tarifa);

                TipoVehiculo vehiculoModificado = new TipoVehiculo
                {
                    Tv_TVCodigo = codigoAModificar,
                    Tv_Descripcion = textDescripcion.Text,
                    Tv_Tarifa = tarifa,
                    Tv_Imagen = textImagen.Text
                };

                if (MessageBox.Show("¿Desea modificar el vehículo?", "Modificar Vehículo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    TrabajarTiposVehiculo.ModificarTipoVehiculo(vehiculoModificado);
                    LimpiarCampos();
                    MessageBox.Show("Tipo Vehiculo Modificado con Éxito.", "Éxito");
                    btnEliminar.IsEnabled = false;
                    btnModificar.IsEnabled = false;
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos para modificar el vehículo.", "Error");
            }
        }

    }
}
