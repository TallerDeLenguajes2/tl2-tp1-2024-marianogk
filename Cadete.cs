public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> listadoPedidos;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadete()
    {
        ListadoPedidos = new List<Pedido>();
    }
    public void AgregarPedido(Pedido pedido)
    {
        listadoPedidos.Add(pedido);
    }

    public void EliminarPedido(Pedido pedido)
    {
        listadoPedidos.Remove(pedido);
    }

    public static List<Pedido> ObtenerPedidos(Cadete cadete)
    {
        return cadete.ListadoPedidos;
    }
    public float CalcularJornal()
    {
        float valorPorPedido = 500;
        return listadoPedidos.Count * valorPorPedido;
    }

    public static void MostrarCadete(Cadete cadete)
    {
        Console.WriteLine("\nCADETE Nro : " + cadete.Id);
        Console.WriteLine("Nombre: " + cadete.Nombre);
        Console.WriteLine("Direccion: " + cadete.Direccion);
        Console.WriteLine("Telefono: " + cadete.Telefono);
        Console.WriteLine("\nPEDIDOS");
        foreach (var pedi2 in ObtenerPedidos(cadete))
        {
            Pedido.MostrarPedido(pedi2);
        }
    }


}