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
using System.Data;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ListadoUsuario.xaml
    /// </summary>
    public partial class ListadoUsuario : Window
    {

        private List<Usuario> usuarios = new List<Usuario>(); // Usaremos una lista en lugar de DataTable

        public ListadoUsuario()
        {
            InitializeComponent();
            // Configurar el evento de selección en la grilla
            userGrid.SelectionChanged += userGrid_SelectionChanged;

            obtenerUsuarios();
        }

        private void obtenerUsuarios()
        {
            DataTable dtUsuarios = TrabajarUsuario.list_usuarios(); // Obtener el DataTable

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
            userGrid.ItemsSource = usuarios; 
        }

        private void userGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userGrid.SelectedItem != null)
            {
                Usuario selectedUser = (Usuario)userGrid.SelectedItem;

                // Accede a los datos del usuario seleccionado (por ejemplo, UserName)
                string userName = selectedUser.Usr_UserName;

                // Realiza aquí las operaciones que desees con el usuario seleccionado
                Console.WriteLine("Usuario seleccionado: " + userName);
            }
        }
    }
}
