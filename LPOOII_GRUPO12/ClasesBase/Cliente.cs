using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Cliente
    {
        private int cli_ClienteDNI;
        private string cli_Apellido;
        private string cli_Nombre;
        private string cli_Telefono;

        public string Cli_Telefono
        {
            get { return cli_Telefono; }
            set { cli_Telefono = value; }
        }

        public string Cli_Nombre
        {
            get { return cli_Nombre; }
            set { cli_Nombre = value; }
        }

        public string Cli_Apellido
        {
            get { return cli_Apellido; }
            set { cli_Apellido = value; }
        }

        public int Cli_ClienteDNI
        {
            get { return cli_ClienteDNI; }
            set { cli_ClienteDNI = value; }
        }
    }
}
