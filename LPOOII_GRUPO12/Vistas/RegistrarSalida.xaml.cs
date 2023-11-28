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
    /// Interaction logic for RegistrarSalida.xaml
    /// </summary>
    public partial class RegistrarSalida : Window
    {
        public int codigoSector;
        public int zona;
        public int duracionH;
        public decimal totalCobro;

        public RegistrarSalida(int sectorId, int zonaCodigo)
        {
            InitializeComponent();
            codigoSector = sectorId;
            zona = zonaCodigo;
            DataTable oTicket = TrabajarTicket.TraerUltimoTicketPorSector(sectorId);
            lblFechaHora.Content = DateTime.Now.ToString();

            foreach (DataRow row in oTicket.Rows)
            {
                DateTime fechaHoraEnt = (DateTime)row["Tkt_FechaHoraEnt"];
                decimal tarifa = (decimal)row["Tv_Tarifa"];

                TimeSpan duracion = DateTime.Now - fechaHoraEnt;
                double duracionEnHoras = duracion.TotalHours;

                int duracionEnHorasEntero = (int)duracionEnHoras;
                duracionTotal.Content = duracionEnHorasEntero;
                duracionH = duracionEnHorasEntero;

             //   row["Tkt_Duracion"] = duracionEnHoras;
               // row["Tkt_Total"] = tarifa * (decimal)duracionEnHoras;

                totalMonto.Content = tarifa * (int)duracionEnHoras;
                totalCobro = tarifa * (int)duracionEnHoras;
            }
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            DataTable oTicket = TrabajarTicket.TraerUltimoTicketPorSector(codigoSector);

            DataRow row = oTicket.Rows[0]; // Suponiendo que solo hay un ticket en el DataTable

            // Modificar los valores en la fila del DataTable
            row["Tkt_FechaHoraSal"] = DateTime.Now;
            row["Tkt_Duracion"] = duracionH;
            row["Tkt_Total"] = totalCobro;
            int numero = (int)row["Tkt_TicketNro"];
            try
            {
                TrabajarTicket.ModificarTicket(oTicket);
                TicketWindow ticketWindow = new TicketWindow(numero);
                ticketWindow.Show();


                this.Close();

                Sectores SectorWindow = new Sectores(numero);
                SectorWindow.Close();

                if (SectorWindow != null && SectorWindow.IsVisible)
                {
                    SectorWindow.Close();
                }

                SectorWindow.Show();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el ticket: " + ex.Message);
            }
           
        }

    }
}
