using System;
using System.Collections.Generic;
using System.Windows;

namespace ClasesBase
{
    public class VentanaManager
    {
        private List<Window> ventanasAbiertas = new List<Window>();
        private List<Window> ventanasPrincipalesAbiertas = new List<Window>();

        // Variable estática privada para almacenar la instancia única
        private static VentanaManager instance;
        // Propiedad estática para acceder a la instancia única
        public static VentanaManager Instance
        {
            get
            {
                // Si la instancia aún no existe, créala
                if (instance == null)
                {
                    instance = new VentanaManager();
                }
                return instance;
            }
        }
        private VentanaManager()
        {
            // Constructor privado para evitar la creación de instancias fuera de la clase
        }

        public void agregarVentana(Window ventana)
        {
            ventanasAbiertas.Add(ventana);
        }

        public void cerrarTodasLasVentanas()
        {
            try
            {
                foreach (var ventana in ventanasAbiertas)
                {
                    ventana.Close();
                }
                ventanasAbiertas.Clear();
                Console.WriteLine("Todas las ventanas han sido cerradas");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }

        public void mostrarVentanasAbiertas()
        {
            try
            {
                Console.WriteLine("Ventanas abiertas:");
                foreach (var ventana in ventanasAbiertas)
                {
                    Console.WriteLine(ventana.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }

        public void agregarVentanaPrincipal(Window ventana)
        {
            ventanasPrincipalesAbiertas.Add(ventana);
        }

        public void cerrarTodasLasVentanasPrincipales()
        {
            try
            {
                foreach (var ventana in ventanasPrincipalesAbiertas)
                {
                    ventana.Close();
                }
                ventanasPrincipalesAbiertas.Clear();
                Console.WriteLine("Todas las ventanas principales han sido cerradas");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }

        public void mostrarVentanasPrincipalesAbiertas()
        {
            try
            {
                Console.WriteLine("Ventanas principales abiertas:");
                foreach (var ventana in ventanasPrincipalesAbiertas)
                {
                    Console.WriteLine(ventana.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }

    }
}
