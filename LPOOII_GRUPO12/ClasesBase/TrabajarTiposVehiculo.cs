using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarTiposVehiculo
    {

        public static DataTable TraerTiposVehiculo() 
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT *";
            cmd.CommandText += " FROM TipoVehiculo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void AgregarTipoVehiculo(TipoVehiculo nuevoVehiculo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.playaConnection);

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO TipoVehiculo (tv_TVCodigo, tv_Descripcion, tv_Tarifa, tv_Imagen) VALUES (@TVCodigo, @Descripcion, @Tarifa, @Imagen)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cmd.Parameters.AddWithValue("@TVCodigo", nuevoVehiculo.Tv_TVCodigo);
                cmd.Parameters.AddWithValue("@Descripcion", nuevoVehiculo.Tv_Descripcion);
                cmd.Parameters.AddWithValue("@Tarifa", nuevoVehiculo.Tv_Tarifa);
                cmd.Parameters.AddWithValue("@Imagen", nuevoVehiculo.Tv_Imagen);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding TipoVehiculo: " + ex.Message);
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
