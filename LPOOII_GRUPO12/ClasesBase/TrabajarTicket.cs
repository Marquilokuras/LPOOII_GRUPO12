using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
   public class TrabajarTicket
    {
       public static void saveTicketEntrada(Ticket ticket) 
       {
           SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

           SqlCommand cmd = new SqlCommand();

           cmd.CommandText = "SELECT MAX(tkt_TicketNro) FROM Ticket"; // Obtener el máximo número de ticket actual
           cmd.Connection = cnn;

           cnn.Open();
           object maxTicketNumber = cmd.ExecuteScalar();
           cnn.Close();

           int nextTicketNumber = 1; // Si no hay registros aún
           if (maxTicketNumber != DBNull.Value)
           {
               nextTicketNumber = Convert.ToInt32(maxTicketNumber) + 1;
           }

           ticket.Tkt_TicketNro = nextTicketNumber;

           cmd.CommandText = "INSERT INTO Ticket(cli_ClienteDNI, sec_SectorCodigo, tkt_FechaHoraEnt, tkt_Patente, tkt_TicketNro, tv_Tarifa, tv_TVCodigo) ";
           cmd.CommandText += "VALUES (@cliClienteDNI, @secSectorCodigo, @tktFechaHoraEnt, @tktPatente, @tktTicketNro, @tvTarifa, @tvTVCodigo)";

           cmd.CommandType = CommandType.Text;
           cmd.Connection = cnn;

           Console.WriteLine("entro");
           cmd.Parameters.AddWithValue("@cliClienteDNI", ticket.Cli_ClienteDNI);
           cmd.Parameters.AddWithValue("@secSectorCodigo", ticket.Sec_SectorCodigo);
           cmd.Parameters.AddWithValue("@tktFechaHoraEnt", ticket.Tkt_FechaHoraEnt);
           cmd.Parameters.AddWithValue("@tktPatente", ticket.Tkt_Patente);
           cmd.Parameters.AddWithValue("@tktTicketNro", ticket.Tkt_TicketNro);
           cmd.Parameters.AddWithValue("@tvTarifa", ticket.Tv_Tarifa);
           cmd.Parameters.AddWithValue("@tvTVCodigo", ticket.Tv_TVCodigo);

           cnn.Open();
           cmd.ExecuteNonQuery();
           cnn.Close();
       }

       public static void saveTicket(Ticket ticket)
       {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT MAX(tkt_TicketNro) FROM Ticket"; // Obtener el máximo número de ticket actual
            cmd.Connection = cnn;

            cnn.Open();
            object maxTicketNumber = cmd.ExecuteScalar();
            cnn.Close();

            int nextTicketNumber = 1; // Si no hay registros aún
            if (maxTicketNumber != DBNull.Value)
            {
                nextTicketNumber = Convert.ToInt32(maxTicketNumber) + 1;
            }

            ticket.Tkt_TicketNro = nextTicketNumber;

            cmd.CommandText = "INSERT INTO Ticket(cli_ClienteDNI, sec_SectorCodigo, tkt_Duracion, tkt_FechaHoraEnt, tkt_FechaHoraSal, tkt_Patente, tkt_TicketNro, tkt_Total, tv_Tarifa, tv_TVCodigo) ";
            cmd.CommandText += "VALUES (@cliClienteDNI, @secSectorCodigo, @tktDuracion, @tktFechaHoraEnt, @tktFechaHoraSal, @tktPatente, @tktTicketNro, @tktTotal, @tvTarifa, @tvTVCodigo)";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            Console.WriteLine("entro");
            cmd.Parameters.AddWithValue("@cliClienteDNI", ticket.Cli_ClienteDNI);
            cmd.Parameters.AddWithValue("@secSectorCodigo", ticket.Sec_SectorCodigo);
            cmd.Parameters.AddWithValue("@tktDuracion", ticket.Tkt_Duracion);
            cmd.Parameters.AddWithValue("@tktFechaHoraEnt", ticket.Tkt_FechaHoraEnt);
            cmd.Parameters.AddWithValue("@tktFechaHoraSal", ticket.Tkt_FechaHoraSal);
            cmd.Parameters.AddWithValue("@tktPatente", ticket.Tkt_Patente);
            cmd.Parameters.AddWithValue("@tktTicketNro", ticket.Tkt_TicketNro);
            cmd.Parameters.AddWithValue("@tktTotal", ticket.Tkt_Total);
            cmd.Parameters.AddWithValue("@tvTarifa", ticket.Tv_Tarifa);
            cmd.Parameters.AddWithValue("@tvTVCodigo", ticket.Tv_TVCodigo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable TraerTicketsPorSector(int sectorCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Ticket WHERE sec_SectorCodigo = @SectorCodigo";
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


        public static DataTable TraerUltimoTicketPorSector(int sectorCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT TOP 1 * FROM Ticket WHERE sec_SectorCodigo = @SectorCodigo ORDER BY tkt_FechaHoraEnt DESC";
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

        public static DataTable TraerTicketPorNumero(int? numeroTicket)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Ticket WHERE tkt_TicketNro = @NumeroTicket";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            // Agrega el parámetro para el número de ticket
            cmd.Parameters.AddWithValue("@NumeroTicket", numeroTicket);

            // Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Retorna el DataTable con los resultados de la consulta
            return dt;
        }

        public static DataTable TraerTickets()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Ticket";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            // Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

    }
}
