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

        private Usuario usuarioLogueado = new Usuario();

        public WinWelcome()
        {
            InitializeComponent();
        }

        private void textUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSession_Click(object sender, RoutedEventArgs e)
        {

            //string username = textUsuario.Text.Trim();
            //string password = textPassword.Text.Trim();

            //Asigna lo escrito en el control de usuario
            string username = login.Usuario;
            string password = login.Password;

            Console.WriteLine(username + " " + password);

            //username = "admin";
            //password = "admin";


            //ToDo validar username y password

            if (username != "" && password != "") {
                //Usuario usuarioLogueado = new Usuario();
                usuarioLogueado.Usr_UserName = username;
                usuarioLogueado.Usr_Password = password;
                usuarioLogueado.Rol_Id = 1;

                //1 = Admin
                //2 = Operador


                if (usuarioLogueado != null)
                {

                    MenuPrincipalWindow menuWindow = new MenuPrincipalWindow(usuarioLogueado);
                    menuWindow.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado", "Ingresar Usuario");
                    Console.WriteLine("No se encontro el usuario: " + username);
                }
            }

            else
                MessageBox.Show("Ingrese un usuario y contraseña");
        }
    }
}
