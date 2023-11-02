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
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            
            if (Validation.GetHasError(textDni) || Validation.GetHasError(textApellido) || Validation.GetHasError(textNombre) || Validation.GetHasError(textTelefono))
            {
                MessageBox.Show("Por favor ingrese datos validos", "Error de Validación");
            }
            else
            {
                if (MessageBox.Show("¿Desea registrar al cliente?", "Registrar Cliente", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    Console.WriteLine(nuevoCliente.ToString());

                    textDni.Text = "";
                    textApellido.Text = "";
                    textNombre.Text = "";
                    textTelefono.Text = "";
                    MessageBox.Show("Cliente Registrado");

                }
            }   
        }
        private void textDni_LostFocus(object sender, RoutedEventArgs e)
        {
            string dni = textDni.Text;

            if (!string.IsNullOrEmpty(dni))
            {
                TrabajarCliente trabajarCliente = new TrabajarCliente();
                Cliente clienteEncontrado = new Cliente();
                clienteEncontrado = trabajarCliente.TraerCliente(dni);
                if (clienteEncontrado != null)
                {
                    textApellido.Text = clienteEncontrado.Cli_Apellido;
                    textNombre.Text = clienteEncontrado.Cli_Nombre;
                    textTelefono.Text = clienteEncontrado.Cli_Telefono;
                }
                else
                {
                    textApellido.Text = "";
                    textNombre.Text = "";
                    textTelefono.Text = "";
                }
            }
     
        }

        

    }
}
