
using Repository.Data.Facturas;
using Repository.Detalles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Servicios.Logica
{
    public class DetallesService
    {
        private DetallesRepository detallesRepository;
        public DetallesService(string connectionString)
        {
            detallesRepository = new DetallesRepository(connectionString);

        }

        public bool add(Detallesmodelo detalle)
        {
            return Validardatosdetalle(detalle) ? detallesRepository.add(detalle) : throw new Exception("Error de datos Corroborar");


        }
        public IEnumerable<Detallesmodelo> GetAll()
        {
            return detallesRepository.GetAll();
        }
        public bool delete(int id)
        {
            return id > 0 ? detallesRepository.delete(id) : false;
        }

        public bool update(Detallesmodelo detallemodelo)
        {
            return Validardatosdetalle(detallemodelo) ? detallesRepository.update(detallemodelo) : throw new Exception("Error de Validacion de datos corroborar");
        }
       

        private bool Validardatosdetalle(Detallesmodelo detalle)
        {
       
            if (string.IsNullOrEmpty(detalle.id_factura)) return false;
            if (string.IsNullOrEmpty(detalle.id_producto)) return false;
            if (string.IsNullOrEmpty(detalle.cantidad_producto)) return false;
            if (string.IsNullOrEmpty(detalle.subtotal)) return false;
           

            return true;
        }
    }
}
}