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

        private Usuario usuarioLogeado;
        public MenuPrincipalWindow(Usuario u)
        {
            InitializeComponent();
            usuarioLogeado = u;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         
                switch (usuarioLogeado.Rol_Id)
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

        private void menuSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            test test = new test();
            contentControl.Content = test;

            
            // Crea una instancia de la página ABMCliente y la establece en el Frame
            //moduloFrame.Navigate(new ABMCliente());
            //ABMCliente clienteWindow = new ABMCliente();
            //clienteWindow.Show();
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





    }
}
