﻿using System;
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
using System.Data;
using System.Data.SqlClient;
using ClasesBase;

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
            VentanaManager.Instance.agregarVentana(this);
            VentanaManager.Instance.mostrarVentanasAbiertas();
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
                    row["Usr_Rol"].ToString(),
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

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            FilterUsers();
        }

        private List<Usuario> FilterUsers()
        {
            string filterText = txtFilter.Text.ToLower();

            // Filtra los usuarios que contienen la palabra clave en el nombre de usuario
            var filteredUsers = usuarios.Where(user => user.Usr_UserName.ToLower().Contains(filterText)).ToList();

            userGrid.ItemsSource = filteredUsers;

            return filteredUsers;
        }

        private void BtnVistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            // Crear e mostrar la ventana VistaPreviaImpresion
            VistaPreviaImpresion ventanaVistaPrevia = new VistaPreviaImpresion();

            ventanaVistaPrevia.UsuariosFiltrados = FilterUsers();

            ventanaVistaPrevia.ShowDialog();
        }

    }
}