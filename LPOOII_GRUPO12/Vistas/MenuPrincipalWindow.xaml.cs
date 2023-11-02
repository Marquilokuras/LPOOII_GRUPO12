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
    /// Interaction logic for MenuPrincipalWindow.xaml
    
    /// </summary>
    /// 

    public partial class MenuPrincipalWindow : Window
    {

        private Usuario usuarioLogueado;
        public MenuPrincipalWindow(Usuario u)
        {
            InitializeComponent();
            usuarioLogueado = u;
            Console.WriteLine(u.ToString());
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            switch (usuarioLogueado.Rol_Id)
                {
                    case 1: // Administrador
                        // Oculta elementos del menú que no necesita
        
                       // menuGestionClientes.Visibility = Visibility.Collapsed;
                       // menuGestionEstacionamiento.Visibility = Visibility.Collapsed;
                
                        break;

                    case 2: // Operador
                        // Oculta elementos del menú que no necesita
                        menuSectores.Visibility = Visibility.Collapsed;
                        menuTiposVehiculo.Visibility = Visibility.Collapsed;
                        break;

                    default:
                        // Oculta todos los elementos del menú si el rol no coincide con ninguno de los casos anteriores
                        menuSectores.Visibility = Visibility.Collapsed;
                        menuTiposVehiculo.Visibility = Visibility.Collapsed;
                        menuGestionClientes.Visibility = Visibility.Collapsed;
                        menuGestionEstacionamiento.Visibility = Visibility.Collapsed;
             
                        break;
                }
            
    
        }

        private void usuarioDatos_Click(object sender, RoutedEventArgs e)
        {
            if (usuarioLogueado != null)
            {
                MessageBox.Show(usuarioLogueado.ToString(), "Datos del Usuario Logueado");
            }
            else
            {
                MessageBox.Show("No hay usuario logueado.", "Error");
            }
        }

        private void menuSalir_Click(object sender, RoutedEventArgs e)
        {
            VentanaManager.Instance.cerrarTodasLasVentanas();
            WinWelcome loginWindow = new WinWelcome();
            loginWindow.Show();
        }

        private void menuSectores_Click(object sender, RoutedEventArgs e)
        {
            ABMSector sectorWindow = new ABMSector();
            sectorWindow.Show();
        }

        private void menuTiposVehiculo_Click(object sender, RoutedEventArgs e)
        {
            ABMVehiculo vehiculoWindow = new ABMVehiculo();
            vehiculoWindow.Show();
        }

        private void menuGestionClientes_Click(object sender, RoutedEventArgs e)
        {
            // Cargar el UserControl de gestión de clientes
            // ABMCliente clienteWindow = new ABMCliente();
            // contentControl.Content = clienteUserControl;

            ABMCliente clienteWindow = new ABMCliente();
            clienteWindow.Show();
        }

        private void menuGestionEstacionamiento_Click(object sender, RoutedEventArgs e)
        {
            ABMEstacionamiento estacionamientoWindow = new ABMEstacionamiento();
            estacionamientoWindow.Show();
        }

        private void menuValidarUsuario_Click(object sender, RoutedEventArgs e)
        {
            ValidarCliente validarClienteWindow = new ValidarCliente();
            validarClienteWindow.Show();
        }
        private void menuGestionUsuarios_Click(object sender, RoutedEventArgs e)
        {
            ABMUsuario abmUsuario = new ABMUsuario();
            abmUsuario.Show();
        }

        private void menuVehiculosEnPlaya_Click(object sender, RoutedEventArgs e)
        {
            VEP vep = new VEP();
            vep.Show();
        }

        private void menuEstadoSector_Click(object sender, RoutedEventArgs e)
        {
            EstadoSector estadoSector = new EstadoSector();
            estadoSector.Show();
        }

        private void menuListadoUsuarios_Click(object sender, RoutedEventArgs e)
        {
            ListadoUsuario listadoUsuario = new ListadoUsuario();
            listadoUsuario.Show();
        }

        
      
    }
}
