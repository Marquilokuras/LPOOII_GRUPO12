using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using ClasesBase;
using System.Collections.ObjectModel; // Asegúrate de importar la clase Usuario
using System.Windows.Data;

namespace Vistas
{
    public partial class ABMUsuario : Window
    {
        private int indiceActual = 0;
        //private List<Usuario> usuarios = new List<Usuario>(); // Usaremos una lista en lugar de DataTable

        private CollectionView Vista;
        private ObservableCollection<Usuario> listaUsuario;
        private Usuario usuarioAux;

        public ABMUsuario()
        {
            InitializeComponent();
            //CargarUsuarios();
            //MostrarUsuarioActual();
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
        }

        /*private void MostrarUsuarioActual()
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
        }*/

        private void LimpiarCampos()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        /*private void CargarUsuarios()
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
        }*/


        // Resto de los métodos se mantienen igual

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            // Implementar lógica para agregar un nuevo usuario a la colección (lista)
            LimpiarCampos();
            btnNuevo.IsEnabled = false;
            btnCancelar.IsEnabled = true;
            btnGuardar.IsEnabled = true;
            btnEliminar.IsEnabled = false;

            btnPrimero.IsEnabled = false;
            btnAnterior.IsEnabled = false;
            btnSiguiente.IsEnabled = false;
            btnUltimo.IsEnabled = false;

            btnSeleccionar.IsEnabled = false;

            txtUsername.IsEnabled = true;
            txtPassword.IsEnabled = true;
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            // Implementar lógica para eliminar el usuario actual de la colección (lista)
            if (camposLlenos())
            {
                //Modificar para que no se puedan eliminar los primeros 2 usuarios (Admin y Operador)
                if (usuarioAux.Usr_Rol == "Admin")
                {
                    MessageBox.Show("No se puede eliminar usuario Admin");
                }
                else 
                {
                    if (usuarioAux.Usr_Id == 2)
                    {
                        MessageBox.Show("No se puede eliminar este usuario");
                    }
                    else 
                    {

                        listaUsuario.RemoveAt(indiceActual);
                        TrabajarUsuario.deleteUser(usuarioAux.Usr_Id);

                        MessageBox.Show("Usuario eliminado correctamente");
                        Vista.MoveCurrentToFirst();
                        indiceActual = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("Llene los campos", "Error");
            }
            LimpiarCampos();
            btnNuevo.IsEnabled = true;
            btnEliminar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            btnGuardar.IsEnabled = false;

            btnPrimero.IsEnabled = true;
            btnAnterior.IsEnabled = true;
            btnSiguiente.IsEnabled = true;
            btnUltimo.IsEnabled = true;

            btnSeleccionar.IsEnabled = true;

            txtUsername.IsEnabled = true;
            txtPassword.IsEnabled = true;
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Implementar lógica para guardar los cambios en el usuario actual (lista)
            if (camposLlenos())
            {
                Usuario oUser = new Usuario();
                oUser.Usr_Rol = "Operador";
                oUser.Usr_Apellido = txtApellido.Text;
                oUser.Usr_Nombre = txtNombre.Text;
                oUser.Usr_UserName = txtUsername.Text;
                oUser.Usr_Password = txtPassword.Text;

                listaUsuario.Add(oUser);
                TrabajarUsuario.saveUser(oUser);

                MessageBox.Show("Usuario agregado correctamente");
                indiceActual = listaUsuario.Count - 1;
                Vista.MoveCurrentToLast();

                btnNuevo.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                btnCancelar.IsEnabled = false;
                btnGuardar.IsEnabled = false;

                btnPrimero.IsEnabled = false;
                btnAnterior.IsEnabled = false;
                btnSiguiente.IsEnabled = false;
                btnUltimo.IsEnabled = false;

                btnSeleccionar.IsEnabled = false;

                txtUsername.IsEnabled = true;
                txtPassword.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Llene los campos", "Error");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {

            LimpiarCampos();
            btnNuevo.IsEnabled = true;
            btnCancelar.IsEnabled = false;
            btnGuardar.IsEnabled = false;
            btnEliminar.IsEnabled = false;

            btnPrimero.IsEnabled = true;
            btnAnterior.IsEnabled = true;
            btnSiguiente.IsEnabled = true;
            btnUltimo.IsEnabled = true;

            btnSeleccionar.IsEnabled = true;

            txtUsername.IsEnabled = true;
            txtPassword.IsEnabled = true;
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            txtApellido.Text = listaUsuario[indiceActual].Usr_Apellido;
            txtNombre.Text = listaUsuario[indiceActual].Usr_Nombre;
            txtUsername.Text = listaUsuario[indiceActual].Usr_UserName;
            txtPassword.Text = listaUsuario[indiceActual].Usr_Password;

            usuarioAux = listaUsuario[indiceActual];

            btnNuevo.IsEnabled = false;
            btnCancelar.IsEnabled = true;
            btnGuardar.IsEnabled = false;
            btnEliminar.IsEnabled = true;

            btnPrimero.IsEnabled = false;
            btnAnterior.IsEnabled = false;
            btnSiguiente.IsEnabled = false;
            btnUltimo.IsEnabled = false;

            txtUsername.IsEnabled = false;
            txtPassword.IsEnabled = false;
        }

        private void Primero_Click(object sender, RoutedEventArgs e)
        {
            //indiceActual = 0;
            //MostrarUsuarioActual();

            Vista.MoveCurrentToFirst();
            indiceActual = 0;
        }

        private void Anterior_Click(object sender, RoutedEventArgs e)
        {
            /*if (indiceActual > 0)
            {
                indiceActual--;
                MostrarUsuarioActual();
            }*/

            Vista.MoveCurrentToPrevious();
            indiceActual--;
            if (Vista.IsCurrentBeforeFirst)
            {
                indiceActual = listaUsuario.Count - 1;
                Vista.MoveCurrentToLast();
            }
        }

        private void Siguiente_Click(object sender, RoutedEventArgs e)
        {
            /*if (indiceActual < usuarios.Count - 1)
            {
                indiceActual++;
                MostrarUsuarioActual();
            }*/

            Vista.MoveCurrentToNext();
            indiceActual++;
            if (Vista.IsCurrentAfterLast)
            {
                indiceActual = 0;
                Vista.MoveCurrentToFirst();
            }
        }

        private void Ultimo_Click(object sender, RoutedEventArgs e)
        {
            //indiceActual = usuarios.Count - 1;
            //MostrarUsuarioActual();

            Vista.MoveCurrentToLast();
            indiceActual = listaUsuario.Count - 1;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["list_user"];
            listaUsuario = odp.Data as ObservableCollection<Usuario>;

            Console.WriteLine("hola " + listaUsuario);
            foreach (Usuario usuario in listaUsuario)
            {
                Console.WriteLine(usuario.ToString());
            }

            Vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);

            btnNuevo.IsEnabled = true;
            btnCancelar.IsEnabled = false;
            btnGuardar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
        }

        // Resto de los métodos de navegación y manipulación de datos se mantienen igual

        private bool camposLlenos()
        {
            if (txtApellido.Text == "" && txtNombre.Text == "" && txtUsername.Text == "" && txtPassword.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void listadoUsuario_Click(object sender, RoutedEventArgs e)
        {
            ListadoUsuario listadoUsuario = new ListadoUsuario();
            listadoUsuario.Show();
        }


    }
}