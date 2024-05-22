using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Clientes
{
    public interface ICliente
    {
        bool add(Clientesmodelo clientemodel);
        bool update(Clientesmodelo clientesmodelo);
        bool delete(int id);
        IEnumerable<Clientesmodelo>GetAll();
    }
}
