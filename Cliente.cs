public class Cliente
{
    private string nombre;
    private string direccion;
    private int telefono;
    private string datosReferenciaDireccion;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

    public Cliente() { }

    public void MostrarCliente(Cliente cliente)
    {
        Console.WriteLine("Nombre: " + cliente.Nombre);
        Console.WriteLine("Direccion: " + cliente.Direccion);
        Console.WriteLine("Telefono: " + cliente.Telefono);
        Console.WriteLine("Direccion referencia: " + cliente.DatosReferenciaDireccion);
    }

    public static Cliente CrearCliente()
    {
        Cliente nuevoCliente = new();

        Console.WriteLine("Ingrese el nombre del cliente:");
        nuevoCliente.Nombre = Console.ReadLine();

        Console.WriteLine("Ingrese la dirección:");
        nuevoCliente.Direccion = Console.ReadLine();

        Console.WriteLine("Ingrese el telefono:");
        nuevoCliente.Telefono = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese datos de referencia para la direccion:");
        nuevoCliente.DatosReferenciaDireccion = Console.ReadLine();
        return nuevoCliente;
    }
}