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
        public int numero;

        public TicketWindow(int ticketNro)
        {
            InitializeComponent();
            numero = ticketNro;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable tablaTickets = TrabajarTicket.TraerTicketPorNumero(numero);

            if (tablaTickets.Rows.Count > 0)
            {
                string ultimoClienteDNI = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["cli_ClienteDNI"]);
                 ultimoClienteDNI_TextBlock.Text = ultimoClienteDNI;
                 string ultimoCodigoSector = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["sec_SectorCodigo"]);
                 ultimoCodigoSector_TextBlock.Text = ultimoCodigoSector;
                string ultimoTicketNro = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["tkt_TicketNro"]);
                ultimoTicketNro_TextBlock.Text = ultimoTicketNro;
                string ultimoPatente= Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["tkt_Patente"]);
                ultimoPatente_TextBlock.Text = ultimoTicketNro;
                string ultimoEntrada = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["tkt_FechaHoraEnt"]);
                ultimoEntrada_TextBlock.Text = ultimoEntrada;
                string ultimoSalida = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["tkt_FechaHoraSal"]);
                ultimoSalida_TextBlock.Text = ultimoSalida;
                string ultimoDuracion = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["tkt_Duracion"]);
                ultimoDuracion_TextBlock.Text = ultimoDuracion;
                string ultimoCodigoVehiculo = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["tv_TVCodigo"]);
                ultimoCodigoVehiculo_TextBlock.Text = ultimoCodigoVehiculo;
                string ultimoTarifa = Convert.ToString(tablaTickets.Rows[tablaTickets.Rows.Count - 1]["tv_Tarifa"]);
                ultimoTarifa_TextBlock.Text = ultimoTarifa;
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
                return ultimoTicket.Cli_ClienteDNI;
            }
            else
            {
                throw new InvalidOperationException("La lista de tickets está vacía o nula.");
            }
        }


    }
}
