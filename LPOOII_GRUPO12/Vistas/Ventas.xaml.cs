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
using System.Data;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        DataTable dtVentas;
        string total;

        public Ventas()
        {
            InitializeComponent();
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dtVentas = TrabajarTicket.TraerTicketsVendidos();
            dgVentas.ItemsSource = dtVentas.DefaultView;

            object resultado = dtVentas.Compute("SUM(tkt_Total)", "");
            if (resultado != DBNull.Value)
            {
                total = Convert.ToString(resultado);
                txtTotal.Text = total;
            }
            else
            {
                total = "0";
                txtTotal.Text = total;
            }

            //Console.WriteLine(dtVentas.ToString());
            //MostrarDatos(dtVentas);
        }

        /*private static void MostrarDatos(DataTable dataTable)
        {
            // Mostrar los nombres de las columnas
            foreach (DataColumn columna in dataTable.Columns)
            {
                Console.Write(columna.ColumnName + "\t");
            }
            Console.WriteLine();

            // Mostrar los datos de cada fila
            foreach (DataRow fila in dataTable.Rows)
            {
                foreach (var item in fila.ItemArray)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
        }*/

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerFechaEntrada.SelectedDate == null && datePickerFechaSalida.SelectedDate == null)
            {
                dtVentas = TrabajarTicket.TraerTicketsVendidos();
                dgVentas.ItemsSource = dtVentas.DefaultView;

                object resultado = dtVentas.Compute("SUM(tkt_Total)", "");
                if (resultado != DBNull.Value)
                {
                    total = Convert.ToString(resultado);
                    txtTotal.Text = total;
                }
                else
                {
                    total = "0";
                    txtTotal.Text = total;
                }
            }
            else if (datePickerFechaEntrada.SelectedDate == null || datePickerFechaSalida.SelectedDate == null)
            {
                MessageBox.Show("Ingrese un rango de fechas", "Error");
            }
            else if (datePickerFechaEntrada.SelectedDate > datePickerFechaSalida.SelectedDate)
            {
                MessageBox.Show("Ingrese un rango de fechas posible", "Error");
            }
            else
            {
                dtVentas = TrabajarTicket.TraerTicketsVendidosPorFecha(datePickerFechaEntrada.SelectedDate.Value, datePickerFechaSalida.SelectedDate.Value);
                dgVentas.ItemsSource = dtVentas.DefaultView;

                object resultado = dtVentas.Compute("SUM(tkt_Total)", "");
                if (resultado != DBNull.Value)
                {
                    total = Convert.ToString(resultado);
                    txtTotal.Text = total;
                }
                else
                {
                    total = "0";
                    txtTotal.Text = total;
                }
            }
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (TieneDatos(dtVentas))
            {
                VistaPreviaVentas vistaPreviaVentasWindow = new VistaPreviaVentas(dtVentas, total);
                vistaPreviaVentasWindow.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("No hay datos para imprimir", "Error");
            }
            
        }

        static bool TieneDatos(DataTable dataTable)
        {
            // Verificar si hay al menos una fila en el DataTable
            return (dataTable != null && dataTable.Rows.Count > 0);
        }
    }
}
