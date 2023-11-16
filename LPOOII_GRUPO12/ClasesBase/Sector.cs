using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Sector
    {
        private int sec_SectorCodigo;
        private string sec_Descripcion;
        private string sec_Identificador;
        private bool sec_Habilitado;

        public bool Sec_Habilitado
        {
            get { return sec_Habilitado; }
            set { sec_Habilitado = value; }
        }

        public string Sec_Identificador
        {
            get { return sec_Identificador; }
            set { sec_Identificador = value; }
        }

        public string Sec_Descripcion
        {
            get { return sec_Descripcion; }
            set { sec_Descripcion = value; }
        }

        public int Sec_SectorCodigo
        {
            get { return sec_SectorCodigo; }
            set { sec_SectorCodigo = value; }
        }
    }
}
