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
    /// Interaction logic for TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        public string UltimoClienteDNI { get; set; }

        public TicketWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable tablaTickets = TrabajarTicket.TraerTickets();

            if (tablaTickets.Rows.Count > 0)
            {
                string ultimoClienteDNI = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["cli_ClienteDNI"]);
                 ultimoClienteDNI_TextBlock.Text = ultimoClienteDNI;
                Console.WriteLine("Último valor de ClienteDNI en el último ticket: " + ultimoClienteDNI);
                string ultimoTicketNro = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["tkt_TicketNro"]);
                ultimoTicketNro_TextBlock.Text = ultimoTicketNro;
                string ultimoPatente= Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["tkt_Patente"]);
                ultimoPatente_TextBlock.Text = ultimoTicketNro;
                string ultimoEntrada = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["tkt_FechaHoraEnt"]);
                ultimoEntrada_TextBlock.Text = ultimoEntrada;


                string ultimoTotal = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["tkt_Total"]);
                ultimoTotal_TextBlock.Text = ultimoTotal;
            }
            else
            {
                Console.WriteLine("La tabla de tickets está vacía.");
            }
        }

        public static int ObtenerUltimoClienteDNI(List<Ticket> listaTickets)
        {
            if (listaTickets != null && listaTickets.Count > 0)
            {
                Ticket ultimoTicket = listaTickets[listaTickets.Count - 1];
                return ultimoTicket.cli_ClienteDNI;
            }
            else
            {
                throw new InvalidOperationException("La lista de tickets está vacía o nula.");
            }
        }


    }
}
