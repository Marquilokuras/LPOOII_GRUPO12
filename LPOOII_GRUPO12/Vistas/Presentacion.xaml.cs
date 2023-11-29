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
using System.Windows.Threading;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Presentacion.xaml
    /// </summary>
    public partial class Presentacion : Window
    {
        private bool audioLoaded = false;

        public Presentacion()
        {
            InitializeComponent();
            Loaded += Presentacion_Loaded;
        }
        private void Presentacion_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!audioLoaded)
                {
                    // Ruta del archivo de audio
                    string audioFilePath = "C:\\Users\\eltem\\Downloads\\Boing.mp3";

                    // Establecer la fuente del MediaElement
                    mediaPlayer.Source = new Uri(audioFilePath, UriKind.RelativeOrAbsolute);

                    // Suscribirse al evento MediaEnded
                    mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;

                    // Cargar y mostrar la imagen
                    LoadAndShowImage();

                    // Marcar que el audio se ha cargado para evitar cargarlo múltiples veces
                    audioLoaded = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar la aplicación: " + ex.Message);
            }
        }
        private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            // El evento se dispara cuando el audio llega al final
            // Cierra la ventana
            Close();
        }
        private void LoadAndShowImage()
        {
            try
            {
                // Ruta de la imagen
                string imagePath = "C:\\Users\\eltem\\Downloads\\boingparking.jpg";

                // Cargar la imagen
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                mainImage.Source = bitmap;

                // Mostrar la imagen
                mainImage.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
            }
        }
    }
}

