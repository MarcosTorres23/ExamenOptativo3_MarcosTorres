using Npgsql;
using Repository.Data.ConfiguracionDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Clientes
{
    public class ClientesRepository
    {

        NpgsqlConnection connection;
        ConnectionDB claseConexion;
        public ClientesRepository(string connectionString)
        {

            connection = new ConnectionDB(connectionString).OpenConnection();
        }
        public bool Add(Clientesmodelo clientemodel)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSER INTO clientes(id_banco,nombre,apellido,documento,direccion,mail,celular,estado)" +
                    $"Values(" +
                    $"'{clientemodel.id_banco}'," +
                    $"'{clientemodel.nombre}'," +
                    $"'{clientemodel.apellido}'," +
                    $"'{clientemodel.documento}'," +
                    $"'{clientemodel.direccion}'," +
                    $"'{clientemodel.mail}'," +
                    $"'{clientemodel.Celular}'," +
                    $"'{clientemodel.estado}',)"
                    ;
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex) {
                throw ex;

            }

        }

        public bool Update(Clientesmodelo clientemodel)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE INTO clientes(id_banco,nombre,apellido,documento,direccion,mail,celular,estado)" +
                    $"Values(" +
                    $"'{clientemodel.id_banco}'," +
                    $"'{clientemodel.nombre}'," +
                    $"'{clientemodel.apellido}'," +
                    $"'{clientemodel.documento}'," +
                    $"'{clientemodel.direccion}'," +
                    $"'{clientemodel.mail}'," +
                    $"'{clientemodel.Celular}'," +
                    $"'{clientemodel.estado}',)"
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

        public List<Clientesmodelo> list()
        {
            List<Clientesmodelo> cliente = new List<Clientesmodelo>();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT FROM clientes";
            var list = cmd.ExecuteReader();

            while (list.Read())
            {
                cliente.Add(new Clientesmodelo
                {
                    nombre = list.GetString(1),
                    apellido = list.GetString(2),
                    documento = list.GetString(3),
                    direccion = list.GetString(5),
                    mail = list.GetString(4),
                    Celular = list.GetString(4),
                    estado = list.GetString(6)

                });

            }
            return cliente;
        }
    }
}
