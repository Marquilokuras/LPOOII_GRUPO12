using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
   public class TrabajarZonas
    {
        public static List<Zona> TraerZonas()
        {
            List<Zona> zonas = new List<Zona>();
            
            using (SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Zonas", cnn);
                cmd.CommandType = CommandType.Text;

                try
                {
                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Zona zona = new Zona
                            {
                                Zona_ZonaCodigo = Convert.ToInt32(reader["zona_ZonaCodigo"]),
                                Zona_Descripcion = Convert.ToString(reader["zona_Descripcion"]),
                                Zona_Piso = Convert.ToString(reader["zona_Piso"])
                            };

                            zonas.Add(zona);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al traer zonas: " + ex);
                }
            }

            return zonas;
        }
    }
}
