﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarSector
    {

        public static Sector TraerSectorPorZonaYIdentificador(int zonaCodigo, string identificador)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Sector WHERE sec_ZonaCodigo = @ZonaCodigo AND sec_Identificador = @Identificador";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            // Agrega los parámetros para ZonaCodigo e Identificador
            cmd.Parameters.AddWithValue("@ZonaCodigo", zonaCodigo);
            cmd.Parameters.AddWithValue("@Identificador", identificador);

            try
            {
                cnn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Sector sector = new Sector
                        {
                            Sec_SectorCodigo = Convert.ToInt32(reader["sec_SectorCodigo"]),
                            Sec_Descripcion = Convert.ToString(reader["sec_Descripcion"]),
                            Sec_Identificador = Convert.ToString(reader["sec_Identificador"]),
                            Sec_Habilitado = Convert.ToBoolean(reader["sec_Habilitado"]),
                            Sec_ZonaCodigo = Convert.ToInt32(reader["sec_ZonaCodigo"])
                        };

                        return sector;
                    }
                    else
                    {
                        return null; // No se encontró ningún registro
                    }
                }
            }
            finally
            {
                cnn.Close();
            }

        }

        public static DataTable TraerSectoresPorZona(int zonaCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Sector WHERE sec_ZonaCodigo = @ZonaCodigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            // Agrega el parámetro para el código de zona
            cmd.Parameters.AddWithValue("@ZonaCodigo", zonaCodigo);

            // Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }


    }

}