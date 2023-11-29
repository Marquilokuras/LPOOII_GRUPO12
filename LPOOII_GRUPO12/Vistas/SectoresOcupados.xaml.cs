using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for SectoresOcupados.xaml
    /// </summary>
    public partial class SectoresOcupados : Window
    {
        private List<DataRow> _data;

        public SectoresOcupados()
        {
            InitializeComponent();
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
            CargarSectoresOcupados();
        }

        private void CargarSectoresOcupados()
        {
            try
            {
                // Obtener DataTable con los sectores ocupados
                DataTable dtSectoresOcupados = TrabajarSector.TraerSectoresOcupados();

                // Calcular tiempo transcurrido
                foreach (DataRow row in dtSectoresOcupados.Rows)
                {
                    if (row["tkt_FechaHoraEnt"] != DBNull.Value)
                    {
                        DateTime fechaEntrada = Convert.ToDateTime(row["tkt_FechaHoraEnt"]);
                        TimeSpan tiempoTranscurrido = DateTime.Now - fechaEntrada;
                        row["TiempoTranscurrido"] = String.Format("{0}hs {1}m", tiempoTranscurrido.Hours, tiempoTranscurrido.Minutes);
                    }
                }

                // Asignar el DataTable al DataGrid
                dgSectoresOcupados.ItemsSource = dtSectoresOcupados.DefaultView;

                // Guardar los datos para imprimir
                _data = new List<DataRow>();
                foreach (DataRow row in dtSectoresOcupados.Rows)
                {
                    _data.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sectores ocupados: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private FlowDocument CrearFlowDocument(List<DataRow> data)
        {
            FlowDocument flowDocument = new FlowDocument();

            foreach (DataRow row in data)
            {
                Paragraph paragraph = new Paragraph();

                paragraph.Inlines.Add(new Run("Sector: " +
            row["sec_Descripcion"] + ", Fecha y Hora de Entrada: " +
            row["tkt_FechaHoraEnt"] + ", Apellido y Nombre del Cliente: " +
            row["Cliente"] + ", Tipo de Vehículo: " +
            row["TipoVehiculo"] + ", Patente: " +
            row["tkt_Patente"] + ", Tiempo Transcurrido: " +
            row["TiempoTranscurrido"]));


                flowDocument.Blocks.Add(paragraph);
            }

            return flowDocument;
        }

        private void btnImprimirListado_Click(object sender, RoutedEventArgs e)
        {
            ImprimirListado(_data);
        }

        private void ImprimirListado(List<DataRow> data)
        {
            FlowDocument flowDocument = CrearFlowDocument(data);

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                IDocumentPaginatorSource paginatorSource = flowDocument;
                printDialog.PrintDocument(paginatorSource.DocumentPaginator, "Listado de Sectores Ocupados");
            }
        }

    }
}