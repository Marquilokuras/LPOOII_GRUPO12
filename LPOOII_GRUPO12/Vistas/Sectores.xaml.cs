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
using System.Data;
using System.Data.SqlClient;
using ClasesBase;

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

        public int zona = 1;
        

        public VEP()
        {
            InitializeComponent();
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();

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

        private void btnE1_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E1");
        }

        private void btnE2_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E2");
        }

        private void btnE3_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E3");
        }

        private void btnE4_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E4");
        }

        private void btnE5_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E5");
        }

        private void btnE6_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E6");
        }

        private void btnE7_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E7");
        }

        private void btnE8_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E8");
        }

        private void btnE9_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E9");
        }

        private void btnE10_MouseEnter(object sender, MouseEventArgs e)
        {
            mostrarEstadoSector("E10");
        }


        private void mostrarEstadoSector(string identificadorSector)
        {

            Sector sector = ClasesBase.TrabajarSector.TraerSectorPorZonaYIdentificador(zona, identificadorSector);


            Console.Write("Sector Descripcion: " + sector.Sec_Descripcion);

            // Lógica para obtener la información del tiempo que lleva libre el sector.
            // Puedes consultar la base de datos para obtener esta información.

            //DateTime fechaInicioReferencia = ObtenerFechaInicioReferencia(identificadorSector);
            DateTime fechaActual = DateTime.Now;

            //TimeSpan tiempoLibre = fechaActual - fechaInicioReferencia;

            // Muestra la información en un cuadro de diálogo o en algún control visual.
            //   MessageBox.Show($"El sector {identificadorSector} está libre desde {fechaInicioReferencia}. Tiempo libre: {tiempoLibre}");
        }


    }
}
