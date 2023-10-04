using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    class TrabajarCliente
    {
        public Cliente TraerCliente(string dni)
        {
            // Aquí debes escribir el código para consultar la base de datos y obtener los datos del cliente.
            // Puedes utilizar Entity Framework u otra tecnología de acceso a datos.
            // Luego, crea un objeto Cliente y devuelve los datos.
            Cliente oCliente = new Cliente();
            // Llena los datos del cliente desde la base de datos.
            oCliente.ClienteDNI = dni;
            oCliente.Apellido = "Apellido desde la base de datos";
            oCliente.Nombre = "Nombre desde la base de datos";
            oCliente.Telefono = "Teléfono desde la base de datos";
            return oCliente;
        }
    }
}
