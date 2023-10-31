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

            cmd.CommandText += " FROM Usuario as U ";
            cmd.CommandText += " LEFT JOIN Rol as R ON (R.rol_id=U.rol_id)";
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
            string sqlQuery = "SELECT * FROM Usuario as U LEFT JOIN Rol as R ON (R.rol_id=U.rol_id)";

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
                        Rol_Id = Convert.ToInt32(reader["Rol_Id"]),
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

    }


}
