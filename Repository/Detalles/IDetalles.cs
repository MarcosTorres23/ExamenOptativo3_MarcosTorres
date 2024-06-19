using Repository.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Detalles
{
    internal interface Idetalles
    {
        bool add(Detallesmodelo detallemodelo);
        bool update(Detallesmodelo detallemodelo);
        bool delete(int id);
        IEnumerable<Detallesmodelo> GetALL();



    }
}