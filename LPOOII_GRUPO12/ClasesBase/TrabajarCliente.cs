using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBase;
using System.Data.SqlClient;

namespace ClasesBase
{

    class TrabajarCliente
    {

        public Cliente TraerCliente(string clienteDNI)
        {

            using (var dbContext = new playa())
            {
                // Realiza una consulta para obtener los datos del cliente con el DNI especificado
                var clienteEncontrado = dbContext.Clientes
                    .Where(c => c.ClienteDNI == clienteDNI)
                    .FirstOrDefault();

                if (clienteEncontrado != null)
                {
                    // Mapea los datos del cliente encontrado en la base de datos a un objeto Cliente
                    Cliente oCliente = new Cliente
                    {
                        ClienteDNI = clienteEncontrado.ClienteDNI,
                        Apellido = clienteEncontrado.Apellido,
                        Nombre = clienteEncontrado.Nombre,
                        Telefono = clienteEncontrado.Telefono
                    };
                    return oCliente;
                }
                else
                {
                    return null; // Cliente no encontrado
                }
            }
        }
    }
}