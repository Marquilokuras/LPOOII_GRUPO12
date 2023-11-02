using System;
using System.Collections.Generic;
using System.Windows;

namespace ClasesBase
{
    public class VentanaManager
    {
        private List<Window> ventanasAbiertas = new List<Window>();

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
            foreach (var ventana in ventanasAbiertas)
            {
                ventana.Close();
            }
            ventanasAbiertas.Clear();
        }

        public void mostrarVentanasAbiertas()
        {
            Console.WriteLine("Ventanas abiertas:");
            foreach (var ventana in ventanasAbiertas)
            {
                Console.WriteLine(ventana.Title); // Puedes imprimir el título de la ventana u otra información relevante
            }
        }

    }
}
