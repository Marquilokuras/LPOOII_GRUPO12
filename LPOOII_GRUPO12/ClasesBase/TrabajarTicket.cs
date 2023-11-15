using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace ClasesBase
{
    public class TrabajarTicket
    {

        public static DataTable TraerTicketsPorSector(int sectorCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Ticket WHERE SectorCodigo = @SectorCodigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            // Agrega el parámetro para el código de sector
            cmd.Parameters.AddWithValue("@SectorCodigo", sectorCodigo);

            // Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }


    }
}
