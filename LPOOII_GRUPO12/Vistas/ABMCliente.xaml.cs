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
        private Cliente nuevoCliente = new Cliente();

        public ABMCliente()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

            Console.WriteLine(textDni.Text + " - " + textApellido.Text + ", " + textNombre.Text + " - " + textTelefono.Text);

            if (textDni.Text != "" && textApellido.Text != "" && textNombre.Text != "" && textTelefono.Text != "") {

                nuevoCliente.Cli_ClienteDNI = int.Parse(textDni.Text);
                nuevoCliente.Cli_Apellido = textApellido.Text;
                nuevoCliente.Cli_Nombre = textNombre.Text;
                nuevoCliente.Cli_Telefono = textTelefono.Text;

                if (nuevoCliente != null) {

                    if (MessageBox.Show("¿Desea registrar al cliente?", "Registrar Cliente", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                        textDni.Text = "";
                        textApellido.Text = "";
                        textNombre.Text = "";
                        textTelefono.Text = "";
                        MessageBox.Show("DNI: " + nuevoCliente.Cli_ClienteDNI + "\r\n" + "Apellido: " + nuevoCliente.Cli_Apellido + "\r\n" + "Cliente: " + nuevoCliente.Cli_Nombre + "\r\n" + "Telefono: " + nuevoCliente.Cli_Telefono, "Cliente Registrado");
                        this.Close();
                    }

                }

            }
            else
                MessageBox.Show("Ingrese datos", "Error");

        }

    }
}
