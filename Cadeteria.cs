public class Cadeteria
{
    private string nombre;
    private int telefono;
    private List<Cadete> listadoCadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public Cadeteria()
    {
        listadoCadetes = new List<Cadete>();
    }

    public static Pedido AltaPedido()
    {
        Pedido nuevoPedido = new();
        int nroPedido;

        Console.WriteLine("\nIngrese el numero del pedido:");
        // Controlar hasta que ingrese un numero
        while (!int.TryParse(Console.ReadLine(), out nroPedido))
        {
            Console.WriteLine("Por favor, ingrese un numero.");
        }
        nuevoPedido.Nro = nroPedido;

        Console.WriteLine("\nIngrese las observaciones del pedido:");
        nuevoPedido.Obs = Console.ReadLine();

        nuevoPedido.Cliente = Cliente.CrearCliente();

        return nuevoPedido;
    }


    public static void AsignarPedido(Cadeteria cadeteria, int idCadete, Pedido pedido)
    {
        List<Cadete> listadoCadetes = cadeteria.ListadoCadetes;
        Cadete cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);

        if (cadete == null)
        {
            throw new Exception("Cadete no encontrado.");
        }

        // Verificar que el pedido esté correctamente creado (opcional)
        if (pedido == null)
        {
            throw new Exception("El pedido debe ser creado primero.");
        }

        // Asignar el pedido al cadete
        cadete.AgregarPedido(pedido);
        Console.WriteLine("\nPedido asignado al cadete: " + cadete.Id);
    }

    // public static void ReasignarPedido(Cadeteria cadeteria, int idCadete, int idCadeteNuevo, int nroPedido)
    // {
    //     var pedido = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
    //     var cadete = cadeteria.ListadoCadetes.ObtenerCadetePorID(cadeteria, idCadete);

    //     var cadeteNuevo = cadeteria.ListadoCadetes.ObtenerCadetePorID(cadeteria, idCadeteNuevo);

    //     if (pedido != null && cadete != null && cadeteNuevo != null)
    //     {
    //         cadete.EliminarPedido(pedido);
    //         cadeteNuevo.AgregarPedido(pedido);
    //         Console.WriteLine("\nPedido reasignado a: " + cadeteNuevo.Nombre);
    //     }
    //     else
    //     {
    //         Console.WriteLine("\nEl pedido no existe");
    //     }
    // }



    public void EliminarCadete(Cadete cadete)
    {
        listadoCadetes.Remove(cadete);
    }

    public static List<Cadete> ObtenerListadoCadetes(Cadeteria cadeteria)
    {
        return cadeteria.listadoCadetes;
    }

    public static Cadete ObtenerCadetePorID(Cadeteria cadeteria, int id)
    {
        return cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == id);
    }

    public static void MostrarListaCadetes(List<Cadete> lista)
    {
        foreach (var c in lista)
        {
            Cadete.MostrarCadete(c);
        }
    }

}