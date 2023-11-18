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
    /// Interaction logic for RegistrarSalida.xaml
    /// </summary>
    public partial class RegistrarSalida : Window
    {
        public RegistrarSalida()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            Ticket oTicket = new Ticket();

            // Obtener valores de los TextBox correctamente
            oTicket.Cli_ClienteDNI = Convert.ToInt32(txtDniCliente.Text);
            oTicket.Sec_SectorCodigo = Convert.ToInt32(txtSectorCodigo.Text);
            oTicket.Tkt_Patente = txtPatente.Text;

            // Establecer las fechas de entrada y salida (aquí debes adaptar según tu lógica)
            oTicket.Tkt_FechaHoraEnt = ObtenerFechaHoraEntrada(); // Método que debe devolver la fecha y hora de entrada
            oTicket.Tkt_FechaHoraSal = DateTime.Now; // Aquí podrías obtener la fecha y hora actual

            // Calcular la duración como TimeSpan
            TimeSpan duracion = oTicket.Tkt_FechaHoraSal - oTicket.Tkt_FechaHoraEnt;
            double duracionEnHoras = duracion.TotalHours;
            oTicket.Tkt_Duracion = duracionEnHoras;

            oTicket.Tv_TVCodigo = Convert.ToInt32(txtTvCodigo.Text);
            oTicket.Tkt_TicketNro++;
            oTicket.Tv_Tarifa = Convert.ToDecimal(txtTarifa.Text);

            // Calcular Tkt_Total utilizando la duración calculada
            oTicket.Tkt_Total = oTicket.Tv_Tarifa * ((int)duracion.TotalHours);

            try
            {
                DateTime fechaEntrada = ObtenerFechaHoraEntrada();
                DateTime fechaSalida = DateTime.Now;
                if (fechaEntrada != DateTime.MinValue && fechaEntrada <= fechaSalida)
                {
                    oTicket.Tkt_FechaHoraEnt = fechaEntrada;
                    oTicket.Tkt_FechaHoraSal = fechaSalida;

                    // Resto del código para calcular y guardar el ticket

                    TrabajarTicket.saveTicket(oTicket);
                    TicketWindow ticketWindow = new TicketWindow();
                    ticketWindow.Show();
                }
                else
                {
                    if (fechaEntrada > fechaSalida)
                    {
                        System.Windows.MessageBox.Show("La fecha y hora de entrada no pueden ser posteriores a la fecha y hora actual.", "Error de fecha", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Error: La fecha de entrada no es válida o no se ha seleccionado.", "Error de fecha", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el ticket: " + ex.Message);
            }
           
        }

        private DateTime ObtenerFechaHoraEntrada()
        {
            // Obtener los valores seleccionados de los ComboBox para horas y minutos de entrada
            int horas = int.Parse(((ComboBoxItem)comboHorasEntrada.SelectedItem).Content.ToString());
            int minutos = int.Parse(((ComboBoxItem)comboMinutosEntrada.SelectedItem).Content.ToString());
            // Obtener la fecha y hora actual
            DateTime? fechaSeleccionada = datePickerFechaEntrada.SelectedDate;
            DateTime fechaHoraActual = fechaSeleccionada.Value;

            // Crear un nuevo objeto DateTime con la fecha actual y la hora seleccionada
            DateTime fechaHoraEntrada = new DateTime(
                fechaHoraActual.Year,
                fechaHoraActual.Month,
                fechaHoraActual.Day,
                horas,
                minutos, 
                0);
            return fechaHoraEntrada;
        }
    }
}
