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
        public List<Clientesmodelo> listado()
        {
            return clientesRepository.list();
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
         public bool delete(int id)
        {
            return id > 0 ? clientesRepository.delete(id) : false;
        }
        public bool update (Clientesmodelo clientemodelo)
        {
            return validardatos(clientemodelo) ? clientesRepository.Update(clientemodelo) : throw new Exception("Error de Validacion de datos en Clientes, favor corrovorar");
        } 
        private bool validardatos(Clientesmodelo cliente)
        {
            if (cliente == null)
                return false;
            if (string.IsNullOrEmpty(cliente.nombre) && cliente.nombre.Length < 3)
                return false;
            if(string.IsNullOrEmpty(cliente.apellido) && cliente.apellido.Length< 3)
                return false;
            if (string.IsNullOrEmpty(cliente.cedula) && cliente.cedula.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.documento)) return false;
            if(string.IsNullOrEmpty(cliente.direccion)) return false;
            if(string.IsNullOrEmpty(cliente.mail)) return false;    
            if(string.IsNullOrEmpty(cliente.estado)) return false;
            if (string.IsNullOrEmpty(cliente.Celular) && cliente.Celular.Length< 3)
                return false;
            return true;
        }

    }
}
