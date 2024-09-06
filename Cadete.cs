public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }



    // public static List<Pedido> ObtenerPedidos(Cadete cadete)
    // {
    //     return cadete.ListadoPedidos;
    // }


    public static void MostrarCadete(Cadete cadete)
    {
        Console.WriteLine("\nCADETE Nro : " + cadete.Id);
        Console.WriteLine("Nombre: " + cadete.Nombre);
        Console.WriteLine("Direccion: " + cadete.Direccion);
        Console.WriteLine("Telefono: " + cadete.Telefono);
    }


}