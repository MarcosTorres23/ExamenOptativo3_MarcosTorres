using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Repository.Clientes;
using Repository.Data.ConfiguracionDB;
using Dapper;
using Repository.Facturas;


namespace Repository.Data.Facturas
{
    public class FacturaRepository :IFacturas {

        IDbConnection connection;
       
        public FacturaRepository(string connectionString)
        {

            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool Add(Facturasmodelo facturasmodel)
        {
            try
            {

                connection.Execute("INSER INTO facturas(id_cliente,nro_factura,fecha_hora,total,total_iva5,total_iva10,total_iva,total_letras,sucursal)" +
                    $"Values(@id_cliente,@nro_factura,@fecha_hora,@total,@total_iva5,@total_iva10,@total_iva,@total_letras,@sucursal)", facturasmodel);
                    
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public IEnumerable<Facturasmodelo> GetAll()
        {
            return connection.Query<Facturasmodelo>("SELECT * FROM persona");
        }
        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM factura WHERE id ={ id}");
            return true;
        }
      
        public bool update(Facturasmodelo facturasmodel)
        {
            try
            {
                connection.Execute("UPDATE facturas SET" +
                    " @id_cliente," +
                    " @nro_factura," +
                    " @fecha_hora," +
                    " @total," +
                    " @total_iva5, " +
                    " @total_iva ," +
                    " @total_letras ," +
                    " @sucursal" +
                    $"WHERE id = @id", facturasmodel;
                    
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
