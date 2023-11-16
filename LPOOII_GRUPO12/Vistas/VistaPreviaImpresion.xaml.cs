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
    /// Interaction logic for VistaPreviaImpresion.xaml
    /// </summary>
    public partial class VistaPreviaImpresion : Window
    {

        public VistaPreviaImpresion()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)DocPrueba).DocumentPaginator, "Impresión Documento Dinámico");
            } 
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection changed event here
            // You can access the selected items using e.Added and e.Removed
        }

    }
}
