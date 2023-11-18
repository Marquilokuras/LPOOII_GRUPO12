using System;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private int usr_Id;
        public int Usr_Id
        {
            get { return usr_Id; }
            set
            {
                usr_Id = value;
                OnPropertyChanged("Usr_Id");
            }
        }

        private string usr_Rol;
        public string Usr_Rol
        {
            get { return usr_Rol; }
            set
            {
                usr_Rol = value;
                OnPropertyChanged("Usr_Rol");
            }
        }

        private string usr_Nombre;
        public string Usr_Nombre
        {
            get { return usr_Nombre; }
            set
            {
                usr_Nombre = value;
                OnPropertyChanged("Usr_Nombre");
            }
        }

        private string usr_Apellido;
        public string Usr_Apellido
        {
            get { return usr_Apellido; }
            set
            {
                usr_Apellido = value;
                OnPropertyChanged("Usr_Apellido");
            }
        }

        private string usr_Password;
        public string Usr_Password
        {
            get { return usr_Password; }
            set
            {
                usr_Password = value;
                OnPropertyChanged("Usr_Password");
            }
        }

        private string usr_UserName;
        public string Usr_UserName
        {
            get { return usr_UserName; }
            set
            {
                usr_UserName = value;
                OnPropertyChanged("Usr_UserName");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
             PropertyChangedEventHandler handler = PropertyChanged;
             if (handler != null)
             {
                handler(this, new PropertyChangedEventArgs(propertyName));
             }
        }
        public Usuario()
        {
        }

        public Usuario(int usrId, string usrRol, string usrNombre, string usrApellido, string usrPassword, string usrUserName)
        {
            Usr_Id = usrId;
            Usr_Rol = usrRol;
            Usr_Nombre = usrNombre;
            Usr_Apellido = usrApellido;
            Usr_Password = usrPassword;
            Usr_UserName = usrUserName;
        }

        public override string ToString()
        {
            return "Usr_Id: " + Usr_Id + ",\nUsr_Rol: " + Usr_Rol + ",\nUsr_Nombre: " + Usr_Nombre + ",\nUsr_Apellido: " + Usr_Apellido + ",\nUsr_UserName: " + Usr_UserName;
        }
    }
}
