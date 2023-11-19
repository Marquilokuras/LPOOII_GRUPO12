using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBase;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{

    public class TrabajarCliente
    {

        public static Cliente TraerCliente(string cdni)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            string selectStatement = "SELECT * FROM Cliente WHERE Cli_ClienteDNI = @cli_ClienteDNI";
            cmd.CommandText = selectStatement;
            using (SqlCommand command = new SqlCommand(selectStatement, cnn))
            {
              command.Parameters.AddWithValue("@cli_ClienteDNI", cdni);
              cnn.Open();
              SqlDataReader reader = command.ExecuteReader();
              Cliente cliente = null;
              if (reader.Read())
              {
                 cliente = new Cliente();
                 cliente.Cli_ClienteDNI = reader["Cli_ClienteDNI"].ToString();
                 cliente.Cli_Apellido = reader["Cli_Apellido"].ToString();
                 cliente.Cli_Nombre = reader["Cli_Nombre"].ToString();
                 cliente.Cli_Telefono = reader["Cli_Telefono"].ToString();
              }

              reader.Close();
              cnn.Close();
              return cliente;
            }
        }

        public static DataTable TraerClientes()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Cliente";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void AgregarCliente(Cliente nuevoCliente)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Cliente (Cli_ClienteDNI, Cli_Apellido, Cli_Nombre, Cli_Telefono) VALUES (@ClienteDNI, @Apellido, @Nombre, @Telefono)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@ClienteDNI", nuevoCliente.Cli_ClienteDNI);
                cmd.Parameters.AddWithValue("@Apellido", nuevoCliente.Cli_Apellido);
                cmd.Parameters.AddWithValue("@Nombre", nuevoCliente.Cli_Nombre);
                cmd.Parameters.AddWithValue("@Telefono", nuevoCliente.Cli_Telefono);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding Cliente: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static void ModificarCliente(Cliente clienteModificado)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Cliente SET Cli_Apellido = @Apellido, Cli_Nombre = @Nombre, Cli_Telefono = @Telefono WHERE Cli_ClienteDNI = @ClienteDNI";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cmd.Parameters.AddWithValue("@ClienteDNI", clienteModificado.Cli_ClienteDNI);
                cmd.Parameters.AddWithValue("@Apellido", clienteModificado.Cli_Apellido);
                cmd.Parameters.AddWithValue("@Nombre", clienteModificado.Cli_Nombre);
                cmd.Parameters.AddWithValue("@Telefono", clienteModificado.Cli_Telefono);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error modifying Cliente: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static void EliminarCliente(string clienteDNI)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Cliente WHERE Cli_ClienteDNI = @ClienteDNI";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cmd.Parameters.AddWithValue("@ClienteDNI", clienteDNI);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting Cliente: " + ex.Message);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

    }
}