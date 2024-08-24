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

}