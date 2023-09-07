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
            MainWindow oMainWindow = new MainWindow();
            oMainWindow.Show();
        }
    }
}
