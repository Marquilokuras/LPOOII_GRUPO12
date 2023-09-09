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
        public WinWelcome()
        {
            InitializeComponent();
        }

        private void textUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSession_Click(object sender, RoutedEventArgs e)
        {

            string username = textUsuario.Text.Trim();
            string password = textPassword.Text.Trim();

            username = "admin";
            password = "admin";

            Usuario usuarioLogueado = new Usuario();
            usuarioLogueado.Usr_UserName = username;
            usuarioLogueado.Usr_Password = password;

            if (usuarioLogueado != null)
            {
                Console.WriteLine("Login exitoso.\nUsuario: " + username);
                MainWindow oMainWindow = new MainWindow();
                oMainWindow.Show();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado", "Ingresar Usuario");
                Console.WriteLine("No se encontro el usuario: " + username);
            }
        }
    }
}
