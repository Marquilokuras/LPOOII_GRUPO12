using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{ 

    public class Cliente : IDataErrorInfo
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

        public string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case "Cli_ClienteDNI":
                        if (cli_ClienteDNI <= 0)
                            error = "El DNI del cliente debe ser mayor que cero.";
                        break;
                    case "Cli_Apellido":
                        if (string.IsNullOrEmpty(cli_Apellido))
                            error = "El apellido del cliente es obligatorio.";
                        break;
                    case "Cli_Nombre":
                        if (string.IsNullOrEmpty(cli_Nombre))
                            error = "El nombre del cliente es obligatorio.";
                        break;
                    case "Cli_Telefono":
                        if (string.IsNullOrEmpty(cli_Telefono))
                            error = "El teléfono del cliente es obligatorio.";
                        break;
                }
                return error;
            }
        }

        public string Error { get { return null; } }
    }
}