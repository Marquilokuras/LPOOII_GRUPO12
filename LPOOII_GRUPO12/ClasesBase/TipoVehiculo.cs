using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class TipoVehiculo
    {
        private int tv_TVCodigo;
        private string tv_Descripcion;
        private decimal tv_Tarifa;

        public decimal Tv_Tarifa
        {
            get { return tv_Tarifa; }
            set { tv_Tarifa = value; }
        }

        public string Tv_Descripcion
        {
            get { return tv_Descripcion; }
            set { tv_Descripcion = value; }
        }

        public int Tv_TVCodigo
        {
            get { return tv_TVCodigo; }
            set { tv_TVCodigo = value; }
        }
    }
}
