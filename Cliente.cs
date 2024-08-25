public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string datosReferenciaDireccion;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

    public Cliente() { }

    public static void MostrarCliente(Cliente cliente)
    {
        Console.WriteLine("Nombre: " + cliente.Nombre);
        Console.WriteLine("Direccion: " + cliente.Direccion);
        Console.WriteLine("Telefono: " + cliente.Telefono);
        Console.WriteLine("Direccion referencia: " + cliente.DatosReferenciaDireccion);
    }

    public static Cliente CrearCliente()
    {
        Cliente nuevoCliente = new();

        Console.WriteLine("\nIngrese el nombre del cliente:");
        nuevoCliente.Nombre = Console.ReadLine();

        Console.WriteLine("\nIngrese la dirección:");
        nuevoCliente.Direccion = Console.ReadLine();

        Console.WriteLine("\nIngrese el telefono:");
        nuevoCliente.Telefono = Console.ReadLine();

        Console.WriteLine("\nIngrese datos de referencia para la direccion:");
        nuevoCliente.DatosReferenciaDireccion = Console.ReadLine();
        return nuevoCliente;
    }
}