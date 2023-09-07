using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Usuario
    {
        private string usr_UserName;
        private string usr_Password;
        private string usr_Apellido;
        private string usr_Nombre;
        private int rol_id;
        private int usr_Id;

        public int Usr_Id
        {
            get { return usr_Id; }
            set { usr_Id = value; }
        }

        public int Rol_id
        {
            get { return rol_id; }
            set { rol_id = value; }
        }

        public string Usr_Nombre
        {
            get { return usr_Nombre; }
            set { usr_Nombre = value; }
        }

        public string Usr_Apellido
        {
            get { return usr_Apellido; }
            set { usr_Apellido = value; }
        }

        public string Usr_Password
        {
            get { return usr_Password; }
            set { usr_Password = value; }
        }

        public string Usr_UserName
        {
            get { return usr_UserName; }
            set { usr_UserName = value; }
        }
    }
}
