using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBase;
using System.Data.SqlClient;

namespace ClasesBase
{

    public class TrabajarCliente
    {

        public Cliente TraerCliente(string cdni)
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
    }
}