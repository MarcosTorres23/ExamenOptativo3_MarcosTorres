using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Data.ConfiguracionDB;
using Dapper;
using System.Threading.Tasks;

namespace Repository.Sucursal
{
    internal class ISucursal
    {
        bool add(Sucursalmodelo sucursalmodelo);
        bool update(Sucursalmodelo sucursalmodelo);
        bool delete(Sucursalmodelo sucursalmodelo);
        IEnumerable<Sucursalmodelo> GetALL();
    


    }
}
