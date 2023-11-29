using System;
using System.Data;
using System.Windows;
using ClasesBase;
using System.Windows.Controls;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for RegistrarEntrada.xaml
    /// </summary>
    public partial class RegistrarEntrada : Window
    {

        public int codigoSector;
        public int zona;

        public RegistrarEntrada(int sectorId, int zonaCodigo)
        {
            InitializeComponent();
            codigoSector = sectorId;
            this.zona = zonaCodigo;

            // Cargar tipos de vehículo en el ComboBox
            CargarTiposVehiculo();
        }

        private void CargarTiposVehiculo()
        {
            try
            {
                DataTable dtTiposVehiculo = TrabajarTiposVehiculo.TraerTiposVehiculo();

                comboTiposVehiculo.ItemsSource = dtTiposVehiculo.DefaultView;
                comboTiposVehiculo.DisplayMemberPath = "tv_Descripcion";
                comboTiposVehiculo.SelectedValuePath = "tv_TVCodigo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de vehículo: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRegistrarEntrada_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Entrada registrada con éxito", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            //Console.WriteLine("Datos: " + txtDniCliente.Text + txtPatente.Text + comboTiposVehiculo.SelectedValue + comboHorasEntrada.SelectedValue + comboMinutosEntrada.SelectedValue);
            //Console.WriteLine(comboTiposVehiculo.SelectedValue);
            //Console.WriteLine(datePickerFechaEntrada);
            //Console.WriteLine(((ComboBoxItem)comboHorasEntrada.SelectedItem).Content.ToString());
            //Console.WriteLine(((ComboBoxItem)comboMinutosEntrada.SelectedItem).Content.ToString());
            //Console.WriteLine(datePickerFechaEntrada.SelectedDate.ToString());
            if (!camposVacios()) 
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

                Ticket oTicket = new Ticket();
                TipoVehiculo oTv = new TipoVehiculo();
                oTv = TrabajarTiposVehiculo.BuscarTipoVehiculo(Convert.ToInt32(comboTiposVehiculo.SelectedValue));

                //Se debe añadir el sector y con el sector la zona
                oTicket.Sec_SectorCodigo = codigoSector;
                oTicket.Cli_ClienteDNI = Convert.ToInt32(txtDniCliente.Text);
                oTicket.Tkt_Patente = txtPatente.Text;
                oTicket.Tkt_FechaHoraEnt = fechaHoraEntrada;
                oTicket.Tv_TVCodigo = oTv.Tv_TVCodigo;
                oTicket.Tv_Tarifa = oTv.Tv_Tarifa;

                TrabajarTicket.saveTicketEntrada(oTicket);
                
                TicketEntrada ticketEntrada = new TicketEntrada(oTicket);
                ticketEntrada.Show();
                Console.WriteLine(oTicket.ToString());

                
                
            }
        }

        private bool camposVacios() {
            if (txtDniCliente.Text == "" || txtPatente.Text == "" || comboTiposVehiculo.SelectedIndex == -1 || datePickerFechaEntrada.SelectedDate == null || comboHorasEntrada.SelectedIndex == -1 || comboMinutosEntrada.SelectedIndex == -1)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}













