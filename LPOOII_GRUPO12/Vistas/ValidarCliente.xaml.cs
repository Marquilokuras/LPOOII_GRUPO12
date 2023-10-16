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
        }

        private void btnVerificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDni.Text != "")
            {
                // Crear una instancia de TrabajarCliente
                TrabajarCliente trabajarCliente = new TrabajarCliente();

                // Llamar al método TraerCliente en la instancia creada
                Cliente cliente = trabajarCliente.TraerCliente(txtDni.Text);
            }
        }

       

    }
}
