using Npgsql;
using Dapper;
using Repository.Data.ConfiguracionDB;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository.Clientes
{
    public class ClientesRepository : ICliente {


        IDbConnection connection;
        public ClientesRepository(string connectionString)
        {

            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool add(Clientesmodelo clientemodel)
        {
            try
            {
                connection.Execute("INSER INTO clientes(id_banco,nombre,apellido,cedula,documento,direccion,mail,celular,estado)" +
                      $"Values(@id_banco, @nombre, @apellido, @cedula, @documento, @direccion, @mail, @celular, @estado )", clientemodel);
                return true;
            }
            catch (Exception ex) {
                throw ex;

            }

        }
        public IEnumerable<Clientesmodelo> GetAll()
        {
            return connection.Query<Clientesmodelo>("Select * From clientes");
        }

        public bool delete(int id)
        {
            connection.Execute($"Delete From Cliente Where id={id}");
        }
        public bool update(Clientesmodelo clientemodel)
        {
            try
            {

                connection.Execute("UPDATE INTO cliente Set " +
                    "nombre=@nombre" +
                    "apellido=@apellido," +
                    "cedula=@cedula," +
                    "documento@documento," +
                    "direccion@direccion," +
                    "mail@mail," +
                    "celular@celular," +
                    "estado@estado" +
                    $"WERE id=@id", clientemodel);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
    
}
