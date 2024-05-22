using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Repository.Clientes;
using Repository.Data.ConfiguracionDB;


namespace Repository.Data.Facturas
{
    public class FacturaRepository
    {
        NpgsqlConnection connection;
        ConnectionDB claseConexion;
        public FacturaRepository(string connectionString)
        {

            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool Add(Facturasmodelo facturasmodel)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSER INTO facturas(id_cliente,nro_factura,fecha_hora,total,total_iva5,total_iva10,total_iva,total_letras,sucursal)" +
                    $"Values("+
                    $"'{facturasmodel.id_cliente}'," +
                    $"'{facturasmodel.nro_factura}'," +
                    $"'{facturasmodel.fecha_hora}'," +
                    $"'{facturasmodel.total}'," +
                    $"'{facturasmodel.total_iva5}'," +
                    $"'{facturasmodel.total_iva10}'," +
                    $"'{facturasmodel.total_iva}'," +
                    $"'{facturasmodel.total_letras}'," +
                    $"'{facturasmodel.sucursal}',)"
                    ;
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public bool Update(Facturasmodelo facturasmodel)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE INTO facturas(id_cliente,nro_factura,fecha_hora,total,total_iva5,total_iva10,total_iva,total_letras,sucursal)" +
                    $"Values(" +
                    $"'{facturasmodel.id_cliente}'," +
                    $"'{facturasmodel.nro_factura}'," +
                    $"'{facturasmodel.fecha_hora}'," +
                    $"'{facturasmodel.total}'," +
                    $"'{facturasmodel.total_iva5}'," +
                    $"'{facturasmodel.total_iva10}'," +
                    $"'{facturasmodel.total_iva}'," +
                    $"'{facturasmodel.total_letras}'," +
                    $"'{facturasmodel.sucursal}',)"
                    ;
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
