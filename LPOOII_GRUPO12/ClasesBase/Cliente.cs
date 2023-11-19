using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{ 

    public class Cliente : IDataErrorInfo
    {
        private string cli_ClienteDNI;
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

        public string Cli_ClienteDNI
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
                        if (string.IsNullOrEmpty(cli_ClienteDNI))
                        {
                            error = "El DNI del cliente es obligatorio.";
                        }
                        else if (!IsNumeric(cli_ClienteDNI,10))
                        {
                            if(cli_ClienteDNI.Length > 10)
                                error = "Maximo 10 caracteres";
                            else
                                error = "El DNI debe contener solo números.";
                        }
                        break;
                    case "Cli_Apellido":
                        if (string.IsNullOrEmpty(cli_Apellido))
                        {
                            error = "El apellido del cliente es obligatorio.";
                        }
                        else if (!IsAlphaWithSpaces(cli_Apellido))
                        {
                            error = "El apellido debe contener solo letras y espacios.";
                        }
                        break;
                    case "Cli_Nombre":
                        if (string.IsNullOrEmpty(cli_Nombre))
                        {
                            error = "El nombre del cliente es obligatorio.";
                        }
                        else if (!IsAlphaWithSpaces(cli_Nombre))
                        {
                            error = "El nombre debe contener solo letras y espacios.";
                        }
                        break;
                    case "Cli_Telefono":
                        if (string.IsNullOrEmpty(cli_Telefono))
                        {
                            error = "El teléfono del cliente es obligatorio.";
                        }
                        else if (!IsNumeric(cli_Telefono,20))
                        {
                            if (cli_Telefono.Length > 20)
                                error = "Maximo 20 caracteres";
                            else
                                error = "El telefono debe contener solo números";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error { get { return null; } }

        private bool IsNumeric(string text, int maxLength)
        {
            if (text.Length > maxLength)
            {
                return false;
            }

            long numero;
            return long.TryParse(text, out numero);
        }

        private bool IsAlphaWithSpaces(string text)
        {
            return text.All(char.IsLetter) || text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        public override string ToString()
        {
            return "DNI: "+Cli_ClienteDNI+",\nApellido: "+Cli_Apellido+",\nNombre: "+Cli_Nombre;
        }
    }
}