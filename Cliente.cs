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

    public static Cliente CrearCliente(string nombre, string direccion, string telefono, string datosReferencia)
    {
        Cliente nuevoCliente = new Cliente{
            Nombre = nombre,
            Direccion = direccion,
            Telefono = telefono,
            DatosReferenciaDireccion = datosReferencia
        };

        // Console.WriteLine("\nIngrese el nombre del cliente:");
        //  Console.ReadLine();

        // Console.WriteLine("\nIngrese la dirección:");
        // nuevoCliente.Direccion = Console.ReadLine();

        // Console.WriteLine("\nIngrese el telefono:");
        // nuevoCliente.Telefono = Console.ReadLine();

        // Console.WriteLine("\nIngrese datos de referencia para la direccion:");
        // nuevoCliente.DatosReferenciaDireccion = Console.ReadLine();
        return nuevoCliente;
    }
}