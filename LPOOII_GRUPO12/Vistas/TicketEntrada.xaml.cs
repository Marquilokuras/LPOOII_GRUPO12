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
    /// Interaction logic for TicketEntrada.xaml
    /// </summary>
    public partial class TicketEntrada : Window
    {
        Ticket ticket = new Ticket();

        public TicketEntrada(Ticket tic)
        {
            InitializeComponent();
            ticket = tic;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Cliente oCli = TrabajarCliente.TraerCliente(Convert.ToString(ticket.Cli_ClienteDNI));
            TipoVehiculo oTv = TrabajarTiposVehiculo.BuscarTipoVehiculo(ticket.Tv_TVCodigo);

            txtNumeroTicket.Text = Convert.ToString(ticket.Tkt_TicketNro);
            //Modificar cuando se agregue el sector
            txtSector.Text = Convert.ToString(ticket.Sec_SectorCodigo);
            txtDNI.Text = oCli.Cli_ClienteDNI;
            txtCliente.Text = oCli.Cli_Apellido + ", " + oCli.Cli_Nombre;
            txtPatente.Text = ticket.Tkt_Patente;
            txtTipoVehiculo.Text = oTv.Tv_Descripcion;
            txtIngreso.Text = Convert.ToString(ticket.Tkt_FechaHoraEnt);
            txtTarifa.Text = Convert.ToString(ticket.Tv_Tarifa);
        }
    }
}
