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

        public static DataTable TraerSectores()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Sector";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void AgregarSector(Sector nuevoSector)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Sector (sec_Descripcion, sec_Habilitado, sec_Identificador, sec_ZonaCodigo, sec_SectorCodigo) " +
                              "VALUES (@Descripcion, @Habilitado, @Identificador, @ZonaCodigo, @SectorCodigo)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@Descripcion", nuevoSector.Sec_Descripcion);
            cmd.Parameters.AddWithValue("@Habilitado", nuevoSector.Sec_Habilitado);
            cmd.Parameters.AddWithValue("@Identificador", nuevoSector.Sec_Identificador);
            cmd.Parameters.AddWithValue("@ZonaCodigo", nuevoSector.Sec_ZonaCodigo);
            cmd.Parameters.AddWithValue("@SectorCodigo", nuevoSector.Sec_SectorCodigo);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar sector: "+ex);
            }
            finally
            {
                cnn.Close();
            }
        }

        public static void ModificarSector(Sector sectorModificado)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Sector " +
                              "SET sec_Descripcion = @Descripcion, sec_Habilitado = @Habilitado, sec_Identificador = @Identificador, sec_ZonaCodigo = @ZonaCodigo, "+
                              "sec_SectorCodigo = @SectorCodigo " +
                              "WHERE sec_SectorCodigo = @SectorCodigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@Descripcion", sectorModificado.Sec_Descripcion);
            cmd.Parameters.AddWithValue("@Habilitado", sectorModificado.Sec_Habilitado);
            cmd.Parameters.AddWithValue("@ZonaCodigo", sectorModificado.Sec_ZonaCodigo);
            cmd.Parameters.AddWithValue("@Identificador", sectorModificado.Sec_Identificador);
            cmd.Parameters.AddWithValue("@SectorCodigo", sectorModificado.Sec_SectorCodigo);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }

        public static void EliminarSector(int sectorCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Sector WHERE sec_SectorCodigo = @SectorCodigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@SectorCodigo", sectorCodigo);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }

        public static Sector BuscarSectorPorCodigo(int codigoSector)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Sector WHERE sec_SectorCodigo = @CodigoSector";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@CodigoSector", codigoSector);

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
                        return null;
                    }
                }
            }
            finally
            {
                cnn.Close();
            }
        }


    }

}