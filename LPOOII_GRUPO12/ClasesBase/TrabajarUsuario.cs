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
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static ObservableCollection<Usuario> traerUsuarios()
        {
            ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            string sqlQuery = "SELECT * FROM Usuario";
            SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                cnn.Open();
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
                Console.WriteLine("Error al obtener usuarios: " + ex.Message);
            }
            finally
            {
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

        public static Usuario findUserByCredentials(string username, string password)
        {
            Usuario usuario = null;
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            string sqlQuery = "SELECT * FROM Usuario WHERE BINARY_CHECKSUM(Usr_UserName) = BINARY_CHECKSUM(@username) AND BINARY_CHECKSUM(Usr_Password) = BINARY_CHECKSUM(@password)";
            SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        Usr_Id = Convert.ToInt32(reader["Usr_Id"]),
                        Usr_Rol = reader["Usr_Rol"].ToString(),
                        Usr_Nombre = reader["Usr_Nombre"].ToString(),
                        Usr_Apellido = reader["Usr_Apellido"].ToString(),
                        Usr_Password = reader["Usr_Password"].ToString(),
                        Usr_UserName = reader["Usr_UserName"].ToString()
                    };
                }
                else
                {
                    Console.WriteLine("No se encontró el usuario: " + username);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar usuario por credenciales: " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return usuario;
        }


    }


}
