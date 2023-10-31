using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using ClasesBase;
using System.Collections.ObjectModel; // Asegúrate de importar la clase Usuario

namespace Vistas
{
    public partial class ABMUsuario : Window
    {
        private int indiceActual = 0;
        private List<Usuario> usuarios = new List<Usuario>(); // Usaremos una lista en lugar de DataTable

        public ABMUsuario()
        {
            InitializeComponent();
            CargarUsuarios();
            MostrarUsuarioActual();
        }

        private void MostrarUsuarioActual()
        {
            Console.WriteLine(usuarios);
            if (usuarios.Count > 0 && indiceActual >= 0 && indiceActual < usuarios.Count)
            {
                Usuario usuario = usuarios[indiceActual];
                txtApellido.Text = usuario.Usr_Apellido;
                txtNombre.Text = usuario.Usr_Nombre;
                txtUsername.Text = usuario.Usr_UserName;
                txtPassword.Text = usuario.Usr_Password;
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void CargarUsuarios()
        {
            DataTable dtUsuarios = TrabajarUsuario.list_usuarios();

            // Convierte los datos del DataTable a una lista de Usuarios
            usuarios = new List<Usuario>();
            foreach (DataRow row in dtUsuarios.Rows)
            {
                usuarios.Add(new Usuario(
                    Convert.ToInt32(row["Usr_Id"]),
                    Convert.ToInt32(row["Rol_id"]),
                    row["Usr_Nombre"].ToString(),
                    row["Usr_Apellido"].ToString(),
                    row["Usr_Password"].ToString(),
                    row["Usr_UserName"].ToString()
                ));
            }

            // TRAER USUARIOS traerUsuarios
            ObservableCollection<Usuario> usuarios2 = TrabajarUsuario.traerUsuarios();
            foreach (Usuario usuario in usuarios2)
            {
                Console.WriteLine(usuario.ToString());
            }
        }


        // Resto de los métodos se mantienen igual

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            // Implementar lógica para agregar un nuevo usuario a la colección (lista)
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            // Implementar lógica para eliminar el usuario actual de la colección (lista)
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Implementar lógica para guardar los cambios en el usuario actual (lista)
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Primero_Click(object sender, RoutedEventArgs e)
        {
            indiceActual = 0;
            MostrarUsuarioActual();
        }

        private void Anterior_Click(object sender, RoutedEventArgs e)
        {
            if (indiceActual > 0)
            {
                indiceActual--;
                MostrarUsuarioActual();
            }
        }

        private void Siguiente_Click(object sender, RoutedEventArgs e)
        {
            if (indiceActual < usuarios.Count - 1)
            {
                indiceActual++;
                MostrarUsuarioActual();
            }
        }

        private void Ultimo_Click(object sender, RoutedEventArgs e)
        {
            indiceActual = usuarios.Count - 1;
            MostrarUsuarioActual();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // Resto de los métodos de navegación y manipulación de datos se mantienen igual
    }
}
