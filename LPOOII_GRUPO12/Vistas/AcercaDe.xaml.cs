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
using System.IO;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for AcercaDe.xaml
    /// </summary>
    public partial class AcercaDe : Window
    {
        public AcercaDe()
        {
            InitializeComponent();

           // mediaElement.Source = new Uri(@"RUTA ABSOLUTA Vistas\Media\bg-video.wmv");

            string carpetaBase = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("carpetaBase: " + carpetaBase);

            string rutaDirecta = Path.Combine(carpetaBase, "..", "..", "Media", "bg-video.wmv");
            Console.WriteLine("rutaDirecta: " + rutaDirecta);

            mediaElement.Source = new Uri(rutaDirecta);

            // Configurar la reproducción en bucle
            mediaElement.MediaEnded += (sender, e) => mediaElement.Position = TimeSpan.Zero;

        }
    }
}
