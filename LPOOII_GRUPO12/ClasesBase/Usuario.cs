using System;

namespace ClasesBase
{
    public class Usuario
    {
        public int Usr_Id { get; set; }
        public int Rol_id { get; set; }
        public string Usr_Nombre { get; set; }
        public string Usr_Apellido { get; set; }
        public string Usr_Password { get; set; }
        public string Usr_UserName { get; set; }

        public Usuario()
        {
        }

        public Usuario(int usrId, int rolId, string usrNombre, string usrApellido, string usrPassword, string usrUserName)
        {
            Usr_Id = usrId;
            Rol_id = rolId;
            Usr_Nombre = usrNombre;
            Usr_Apellido = usrApellido;
            Usr_Password = usrPassword;
            Usr_UserName = usrUserName;
        }
    }
}
