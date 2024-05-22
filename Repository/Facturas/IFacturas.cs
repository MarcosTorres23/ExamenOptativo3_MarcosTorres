using Repository.Clientes;
using Repository.Data.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Facturas
{
    public interface IFacturas
    {
        bool add(Facturasmodelo facturamodelo);
        bool update(Facturasmodelo facturamodelo);
        bool delete(int id);
        IEnumerable<Facturasmodelo> GetAll();
    }
}
