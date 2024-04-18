using Repository.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Logica
{
    public class ClienteService
    {
        ClientesRepository clientesRepository;
        public ClienteService(string connectionString)
        {
            clientesRepository=new ClientesRepository(connectionString);
            
        }
        public bool insertar(Clientesmodelo cliente)
        {
            if (validardatos(cliente))
            {
                return clientesRepository.Add(cliente);
            }else
            {
                throw new Exception("Error en la validacion de los datos, favor verivique los datos");
            }

        }
        private bool validardatos(Clientesmodelo cliente)
        {
            if (cliente == null)
                return false;
            if (string.IsNullOrEmpty(cliente.nombre))
                return false;
            if(string.IsNullOrEmpty(cliente.apellido))
                return false;
            if(string.IsNullOrEmpty(cliente.documento)) return false;
            if(string.IsNullOrEmpty(cliente.direccion)) return false;
            if(string.IsNullOrEmpty(cliente.mail)) return false;    
            if(string.IsNullOrEmpty(cliente.Celular)) return false; 
            if(string.IsNullOrEmpty(cliente.estado)) return false;


            return true;
        }

    }
}
