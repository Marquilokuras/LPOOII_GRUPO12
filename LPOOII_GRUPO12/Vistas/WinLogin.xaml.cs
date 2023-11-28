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
    /// Interaction logic for WinWelcome.xaml
    /// </summary>
    public partial class WinWelcome : Window
    {

        private Usuario usuarioLogueado;

        public WinWelcome()
        {
            InitializeComponent();
        }

        private void btnSession_Click(object sender, RoutedEventArgs e)
        {
            string username = login.Usuario;
            string password = login.Password;
            Console.WriteLine("\nCredenciales: "+username + " " + password+"\n");
            if (username != "" && password != "")
            {
                usuarioLogueado = ClasesBase.TrabajarUsuario.findUserByCredentials(username, password);
                if (usuarioLogueado != null)
                {
                    Console.WriteLine(usuarioLogueado.ToString());
                    MenuPrincipalWindow menuWindow = new MenuPrincipalWindow(usuarioLogueado);
                    menuWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas", "Ingresar Usuario");
                    Console.WriteLine("No se encontro el usuario: " + username);
                }
            }

            else
                MessageBox.Show("Ingrese un usuario y contraseña");
        }

        private void sobreNostros_Click(object sender, RoutedEventArgs e)
        {
            AcercaDe acercaDe = new AcercaDe();
            acercaDe.Show();
        }
    }
}
