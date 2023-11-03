using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;


namespace ClasesBase
{
    public class TrabajarUsuario
    {
        public static DataTable list_usuarios()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT *";

            cmd.CommandText += " FROM Usuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static ObservableCollection<Usuario> traerUsuarios()
        {
            ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();

            // Crear una conexión a la base de datos
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            // Definir la consulta SQL para obtener los usuarios
            string sqlQuery = "SELECT * FROM Usuario";

            // Crear un objeto SqlCommand y configurarlo
            SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            cmd.CommandType = CommandType.Text;

            try
            {
                // Abrir la conexión
                cnn.Open();

                // Ejecutar la consulta y obtener los resultados
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Usr_Id = Convert.ToInt32(reader["Usr_Id"]),
                        Usr_Rol = reader["Usr_Rol"].ToString(),
                        Usr_Nombre = reader["Usr_Nombre"].ToString(),
                        Usr_Apellido = reader["Usr_Apellido"].ToString(),
                        Usr_Password = reader["Usr_Password"].ToString(),
                        Usr_UserName = reader["Usr_UserName"].ToString()
                    };
                    usuarios.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al obtener usuarios: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                cnn.Close();
            }

            return usuarios;
        }

        public static void saveUser(Usuario user)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Usuario(usr_Apellido, usr_Nombre, usr_UserName, usr_Password, usr_Rol) ";
            cmd.CommandText += "  VALUES (@usrApellido, @usrNombre, @usrUserName, @usrPassword, @usr_Rol)";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@usrApellido", user.Usr_Apellido);
            cmd.Parameters.AddWithValue("@usrNombre", user.Usr_Nombre);
            cmd.Parameters.AddWithValue("@usrUserName", user.Usr_UserName);
            cmd.Parameters.AddWithValue("@usrPassword", user.Usr_Password);
            cmd.Parameters.AddWithValue("@usr_Rol", user.Usr_Rol);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static Boolean deleteUser(int usrId)
        {

            bool userFound = false;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();

            string deleteStatement = "DELETE FROM Usuario WHERE usr_Id = @id";

            cmd.CommandText = deleteStatement;

            using (SqlCommand command = new SqlCommand(deleteStatement, cnn))
            {
                command.Parameters.AddWithValue("@id", usrId);

                cnn.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Se eliminó el usuario con id: ", usrId);
                    userFound = true;
                }
                else
                {
                    Console.WriteLine("No se encontró ningún usuario con id: ", usrId);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                cnn.Close();
            }
            return userFound;
        }

    }


}
