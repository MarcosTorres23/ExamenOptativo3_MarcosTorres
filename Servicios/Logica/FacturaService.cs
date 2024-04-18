using Repository.Clientes;
using Repository.Data.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Logica
{
    public class FacturaService
    {
        private FacturaRepository facturaRepository;
        public FacturaService(string connectionString)
        {
            facturaRepository = new FacturaRepository(connectionString);

        }

        public bool Insertar(Facturasmodelo factura)
        {
            if (Validardatos(factura))
            {
                return facturaRepository.Add(factura);
            }
            else
            {
                throw new Exception("Error en la validacion de los datos, favor verivique los datos");
            }

        }
        private bool Validardatos(Facturasmodelo factura)
        {
            if (factura == null)
                return false;
            if (string.IsNullOrEmpty(factura.id_cliente))
                return false;
            if (string.IsNullOrEmpty(factura.nro_factura))
                return false;
            if (string.IsNullOrEmpty(factura.total)) return false;
            if (string.IsNullOrEmpty(factura.total_iva5)) return false;
            if (string.IsNullOrEmpty(factura.total_iva10)) return false;
            if (string.IsNullOrEmpty(factura.total_letras)) return false;
            if (string.IsNullOrEmpty(factura.sucursal)) return false;


            return true;
        }

    }
}
