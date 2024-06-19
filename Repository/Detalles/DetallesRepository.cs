using Dapper;
using Repository.Data.ConfiguracionDB;
using Repository.Productos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Detalles
{

    public class DetallesRepository : Idetalles
    {
        IDbConnection connection;

        public DetallesRepository(string connectionString)
        {

            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool add(Detallesmodelo detallemodelo)
        {
            try
            {
                connection.Execute("INSERT INTO detalles_factura (id_factura, id_producto, cantidad_producto, subtotal)" +
                    $"Values(@id_factura, @id_producto, @cantidad_producto, @subtotal)", detallemodelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Detallesmodelo> GetAll()
        {
            return connection.Query<Detallesmodelo>("SELECT * FROM productos");
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM detalle_factura WHERE id= {id}");

        }

        public bool update(Detallesmodelo detallemodelo)
        {
            try
            {
                connection.Execute("UPDATE detalle_factura SET " +
                "@id_factura," +
                    " @id_producto, " +
                    " @cantidad_producto," +
                    " @subtotal) " +
                    $"WHERE id = @id", detallemodelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}