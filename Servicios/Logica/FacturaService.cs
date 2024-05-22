using Repository.Clientes;
using Repository.Data.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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

        public bool add(Facturasmodelo factura)
        {
            return Validardatosfactura(factura) ? facturaRepository.Add(factura) : throw new Exception("Error de datos Corroborar");


        }
        public IEnumerable<Facturasmodelo> GetAll()
        {
            return facturaRepository.GetAll();
        }
        public bool delete(int id)
        {
            return id > 0 ? facturaRepository.delete(id) : false;
        }

        public bool update(Facturasmodelo facturamodelo)
        {
            return Validardatosfactura(facturamodelo) ? facturaRepository.update(facturamodelo) : throw new Exception("Error de Validacion de datos corroborar");
        }
        private bool esnumero(string cadena)
        {
            foreach (char c in cadena)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }

        private bool Validardatosfactura(Facturasmodelo factura)
        {
            Regex regexNroFactura = new Regex(@"^\d{3}-\d{3}-\d{6}$");

            if (!regexNroFactura.IsMatch(factura.nro_factura))
            {
                Console.WriteLine("Nro Factura no cumple con el formato requerido");
                return false;
            }
            if (factura == null)
                return false;
            if (string.IsNullOrEmpty(factura.id_cliente))
                return false;
            if (string.IsNullOrEmpty(factura.nro_factura))
                return false;
            if (string.IsNullOrEmpty(factura.total) || !!esnumero(factura.total)) return false;
            if (string.IsNullOrEmpty(factura.total_iva5) || !!esnumero(factura.total_iva5)) return false;
            if (string.IsNullOrEmpty(factura.total_iva10) || !!esnumero(factura.total_iva10)) return false;
            if (string.IsNullOrEmpty(factura.total_iva) || !!esnumero(factura.total_iva)) return false;
            if (string.IsNullOrEmpty(factura.total_letras) && factura.total_letras.Length < 6) return false;
            if (string.IsNullOrEmpty(factura.sucursal)) return false;

         return true;
        }
    }
}
