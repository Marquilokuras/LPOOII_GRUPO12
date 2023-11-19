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
    /// Interaction logic for ValidarCliente.xaml
    /// </summary>
    public partial class ValidarCliente : Window
    {
        public ValidarCliente()
        {
            InitializeComponent();
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
        }

        private void btnVerificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDni.Text != "")
            {
                Cliente cliente = TrabajarCliente.TraerCliente(txtDni.Text);
                if (cliente != null)
                {
                    Console.WriteLine("Apellido: " + cliente.Cli_Apellido);
                    Console.WriteLine("DNI: " + cliente.Cli_ClienteDNI);
                    Console.WriteLine("Nombre: " + cliente.Cli_Nombre);
                    Console.WriteLine("Telefono: " + cliente.Cli_Telefono);
                }
                else
                {
                    Console.WriteLine("Cliente no encontrado");
                }
            }
        }

       

    }
}
