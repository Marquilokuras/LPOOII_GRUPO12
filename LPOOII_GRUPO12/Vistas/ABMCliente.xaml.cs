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
    /// Interaction logic for ABMCliente.xaml
    /// </summary>
    public partial class ABMCliente : Window
    {
        private Cliente nuevoCliente;

        public ABMCliente()
        {
            InitializeComponent();
            this.nuevoCliente = new Cliente();
            this.DataContext = nuevoCliente;
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnRegistrar.IsEnabled = false;
            btnBuscar.IsEnabled = false;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (CamposInvalidos()==true)
            {
                MessageBox.Show("Por favor ingrese datos válidos", "Error de Validación");
            }
            else
            {
                if (MessageBox.Show("¿Desea registrar al cliente?", "Registrar Cliente", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Cliente nuevoCliente = new Cliente
                    {
                        Cli_ClienteDNI = textDni.Text,
                        Cli_Apellido = textApellido.Text,
                        Cli_Nombre = textNombre.Text,
                        Cli_Telefono = textTelefono.Text
                    };

                    TrabajarCliente.AgregarCliente(nuevoCliente);

                    LimpiarCampos();
                    MessageBox.Show("Cliente Registrado");
                }
            }
        }

        private void btnVerClientes_Click(object sender, RoutedEventArgs e)
        {
            GrillaClientes listadoClientes = new GrillaClientes();
            listadoClientes.Show();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string dni = textDni.Text;

            if (!string.IsNullOrEmpty(dni) && IsNumeric(dni, 10) && btnEliminar.IsEnabled==true )
            {
                Cliente clienteEncontrado = TrabajarCliente.TraerCliente(dni);

                if (clienteEncontrado != null)
                {
                    if (MessageBox.Show("¿Desea eliminar al cliente?", "Eliminar Cliente", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        TrabajarCliente.EliminarCliente(clienteEncontrado.Cli_ClienteDNI);
                        LimpiarCampos();
                        MessageBox.Show("Cliente Eliminado");

                        btnEliminar.IsEnabled = false;
                        btnModificar.IsEnabled = false;
                        btnRegistrar.IsEnabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró un cliente con el DNI proporcionado", "Cliente no encontrado");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un DNI válido antes de intentar eliminar", "Error de Validación");
            }
        }


        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            string dni = textDni.Text;

            if (!string.IsNullOrEmpty(dni) && IsNumeric(dni, 10) && btnModificar.IsEnabled)
            {
                Cliente clienteModificado = new Cliente
                {
                    Cli_ClienteDNI = textDni.Text,
                    Cli_Apellido = textApellido.Text,
                    Cli_Nombre = textNombre.Text,
                    Cli_Telefono = textTelefono.Text
                };

                TrabajarCliente.ModificarCliente(clienteModificado);

                LimpiarCampos();
                MessageBox.Show("Cliente Modificado");

                btnEliminar.IsEnabled = false;
                btnModificar.IsEnabled = false;
                btnRegistrar.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un DNI válido antes de intentar modificar", "Error de Validación");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
            btnEliminar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnRegistrar.IsEnabled = false;
            btnBuscar.IsEnabled = false;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string dni = textBuscar.Text;

            if (!string.IsNullOrEmpty(dni) && IsNumeric(dni, 10))
            {
                Cliente clienteEncontrado = TrabajarCliente.TraerCliente(dni);

                if (clienteEncontrado != null)
                {
                    textDni.Text = clienteEncontrado.Cli_ClienteDNI;
                    textApellido.Text = clienteEncontrado.Cli_Apellido;
                    textNombre.Text = clienteEncontrado.Cli_Nombre;
                    textTelefono.Text = clienteEncontrado.Cli_Telefono;

                    btnModificar.IsEnabled = true;
                    btnEliminar.IsEnabled = true;
                    btnRegistrar.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("No se encontró un cliente con el DNI proporcionado", "Cliente no encontrado");
                    LimpiarCampos();
                    btnModificar.IsEnabled = false;
                    btnEliminar.IsEnabled = false;
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un DNI válido antes de intentar buscar", "Error de Validación");
            }
        }

        private bool IsNumeric(string text, int maxLength)
        {
            if (text.Length > maxLength)
            {
                return false;
            }
            long numero;
            return long.TryParse(text, out numero);
        }

        private void textDni_LostFocus(object sender, RoutedEventArgs e)
        {
            string dni = textBuscar.Text;
            if (!string.IsNullOrEmpty(dni) && IsNumeric(dni, 10))
            {
                Cliente clienteEncontrado = new Cliente();
                clienteEncontrado = TrabajarCliente.TraerCliente(dni);
                if (clienteEncontrado != null)
                {
                    textApellido.Text = clienteEncontrado.Cli_Apellido;
                    textNombre.Text = clienteEncontrado.Cli_Nombre;
                    textTelefono.Text = clienteEncontrado.Cli_Telefono;
                    btnModificar.IsEnabled = true;
                    btnEliminar.IsEnabled = true;
                    btnRegistrar.IsEnabled = false;
                }
                else
                {
                    textApellido.Clear();
                    textNombre.Clear();
                    textTelefono.Clear();
                    btnModificar.IsEnabled = false;
                    btnEliminar.IsEnabled = false;
                }
            }
        }

        private void LimpiarCampos()
        {
            textApellido.Clear();
            textNombre.Clear();
            textTelefono.Clear();
            textDni.Clear();
        }

        private bool CamposInvalidos()
        {
            return Validation.GetHasError(textDni) || Validation.GetHasError(textApellido) || Validation.GetHasError(textNombre) || Validation.GetHasError(textTelefono);
        }

        private void CamposForm_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnRegistrar.IsEnabled = !CamposInvalidos() && btnModificar.IsEnabled==false;
        }

        private void textBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnBuscar.IsEnabled = !string.IsNullOrEmpty(textBuscar.Text);
        }

    }
}
