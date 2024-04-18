

using Repository.Clientes;
using Servicios.Logica;

string connectionString = "Host=localhost;port=5432;Database=optativo3;Username=postgres;Password=123456;";
ClienteService clienteService = new ClienteService(connectionString);

Console.WriteLine(" Hola inserta a o b");
string opcion = Console.ReadLine();
if (opcion == "a")
{
    clienteService.insertar(new Clientesmodelo
    {
        nombre = "Juan",
        apellido = "Perez",
        documento = "4567",
        direccion = "Dr predro ciancio",
        mail = "nose@qtimpt",
        Celular="0971470459",
        estado = "Activo"
    });
}
if (opcion == "b")
{
    clienteService.listado().ForEach(cliente =>
    Console.WriteLine(
        $"nombre: {cliente.nombre} \n " +
        $"apellido: {cliente.apellido} \n " +
        $"documento: {cliente.documento} \n " +
        $"direccion {cliente.direccion} \n " +
        $"mail: {cliente.mail} \n " +
        $"celular: {cliente.Celular} \n " +
        $"estado: {cliente.estado} \n "
        )
    );
}