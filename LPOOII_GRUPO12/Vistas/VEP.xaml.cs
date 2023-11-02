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
    /// Interaction logic for VEP.xaml
    /// </summary>
    public partial class VEP : Window
    {
        private SolidColorBrush greenBrush;
        private SolidColorBrush redBrush;
        private SolidColorBrush grayBrush;

        public VEP()
        {
            InitializeComponent();

            redBrush = new SolidColorBrush(Colors.Red);
            greenBrush = new SolidColorBrush(Colors.Green);
            grayBrush = new SolidColorBrush(Colors.Gray);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnE1.Background = greenBrush;
            btnE2.Background = greenBrush;
            btnE3.Background = greenBrush;
            btnE4.Background = grayBrush;
            btnE5.Background = greenBrush;
            btnE6.Background = greenBrush;
            btnE7.Background = redBrush;
            btnE8.Background = greenBrush;
            btnE9.Background = greenBrush;
            btnE10.Background = greenBrush;
        }

        private void btnE1_Click(object sender, RoutedEventArgs e)
        {
            if (btnE1.Background == greenBrush)
            {
                MessageBox.Show("Sector Disponible. Registrar Entrada", "Disponibilidad");
            }
            else if (btnE1.Background == redBrush)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida", "Disponibilidad");
            }
            else if (btnE1.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE2_Click(object sender, RoutedEventArgs e)
        {
            if (btnE2.Background == greenBrush)
            {
                MessageBox.Show("Sector Disponible. Registrar Entrada", "Disponibilidad");
            }
            else if (btnE2.Background == redBrush)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida", "Disponibilidad");
            }
            else if (btnE2.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE3_Click(object sender, RoutedEventArgs e)
        {
            if (btnE3.Background == greenBrush)
            {
                MessageBox.Show("Sector Disponible. Registrar Entrada", "Disponibilidad");
            }
            else if (btnE3.Background == redBrush)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida", "Disponibilidad");
            }
            else if (btnE3.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE4_Click(object sender, RoutedEventArgs e)
        {
            if (btnE4.Background == greenBrush)
            {
                MessageBox.Show("Sector Disponible. Registrar Entrada", "Disponibilidad");
            }
            else if (btnE4.Background == redBrush)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida", "Disponibilidad");
            }
            else if (btnE4.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE5_Click(object sender, RoutedEventArgs e)
        {
            if (btnE5.Background == greenBrush)
            {
                MessageBox.Show("Sector Disponible. Registrar Entrada", "Disponibilidad");
            }
            else if (btnE5.Background == redBrush)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida", "Disponibilidad");
            }
            else if (btnE5.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE6_Click(object sender, RoutedEventArgs e)
        {
            if (btnE6.Background == greenBrush)
            {
                MessageBox.Show("Sector Disponible. Registrar Entrada", "Disponibilidad");
            }
            else if (btnE6.Background == redBrush)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida", "Disponibilidad");
            }
            else if (btnE6.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE7_Click(object sender, RoutedEventArgs e)
        {
            if (btnE7.Background == greenBrush)
            {
                MessageBox.Show("Sector Disponible. Registrar Entrada", "Disponibilidad");
            }
            else if (btnE7.Background == redBrush)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida", "Disponibilidad");
            }
            else if (btnE7.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE8_Click(object sender, RoutedEventArgs e)
        {
            if (btnE8.Background == greenBrush)
            {
                MessageBox.Show("Sector Disponible. Registrar Entrada", "Disponibilidad");
            }
            else if (btnE8.Background == redBrush)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida", "Disponibilidad");
            }
            else if (btnE8.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE9_Click(object sender, RoutedEventArgs e)
        {
            if (btnE9.Background == greenBrush)
            {
                MessageBox.Show("Sector Disponible. Registrar Entrada", "Disponibilidad");
            }
            else if (btnE9.Background == redBrush)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida", "Disponibilidad");
            }
            else if (btnE9.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnE10_Click(object sender, RoutedEventArgs e)
        {
            if (btnE10.Background == greenBrush)
            {
                MessageBox.Show("Sector Disponible. Registrar Entrada", "Disponibilidad");
            }
            else if (btnE10.Background == redBrush)
            {
                MessageBox.Show("Sector Ocupado. Registrar Salida", "Disponibilidad");
            }
            else if (btnE10.Background == grayBrush)
            {
                MessageBox.Show("Sector deshabilitado.", "Disponibilidad");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
