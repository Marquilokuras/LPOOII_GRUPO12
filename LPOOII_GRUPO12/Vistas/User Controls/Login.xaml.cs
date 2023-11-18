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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vistas.User_Controls
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        public String Usuario{
            get { return textUsuario.Text; }
        }

        public String Password{
            get { return textPassword.Password; }
        }

        private void chkMostrarContrasena_Checked(object sender, RoutedEventArgs e)
        {
            PasswordUnmask.Visibility = Visibility.Visible;
            textPassword.Visibility = Visibility.Hidden;
            PasswordUnmask.Text = textPassword.Password;
        }

        private void chkMostrarContrasena_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordUnmask.Visibility = Visibility.Hidden;
            textPassword.Visibility = Visibility.Visible;
        }
    }
}
