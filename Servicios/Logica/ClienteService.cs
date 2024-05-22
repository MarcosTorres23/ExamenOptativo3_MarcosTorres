using Repository.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Servicios.Logica
{
    public class ClienteService : ICliente
    {
        private ClientesRepository clientesRepository;
        public ClienteService(string connectionString)
        {
            clientesRepository=new ClientesRepository(connectionString);
            
        }
        public bool add (Clientesmodelo cliente){
            return validardatos(cliente) ? clientesRepository.add(cliente) : throw new Exception("Error de Datos, comprovar en Facturas");

        }
        public IEnumerable<Clientesmodelo> GetAll() { 
            
            return clientesRepository.GetAll(); }
         public bool delete(int id)
        {
            return id > 0 ? clientesRepository.delete(id) : false;
        }
        public bool update (Clientesmodelo clientemodelo)
        {
            return validardatos(clientemodelo) ? clientesRepository.update(clientemodelo) : throw new Exception("Error de Validacion de datos en Clientes, favor corrovorar");
        }
        private bool esnumero(string cadena)
        {
            foreach (char c in cadena)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;

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
            if (string.IsNullOrEmpty(cliente.Celular)||cliente.Celular.Length !=10 ||!!esnumero(cliente.Celular))
                return false;
            if (string.IsNullOrEmpty(cliente.estado)) return false;

            

                return false;
            return true;
        }

    }
}
