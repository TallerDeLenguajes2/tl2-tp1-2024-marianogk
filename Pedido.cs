public class Pedido
{
    public enum EstadoP
    {
        Pendiente,
        EnProceso,
        Completado,
        Cancelado
    }
    private int nro;
    private string obs;
    private EstadoP estado;
    private Cliente cliente;

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public EstadoP Estado { get => estado; set => estado = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }

    public Pedido()
    {
        Cliente = new Cliente();
        Estado = EstadoP.Pendiente;
    }

    public string DireccionCliente()
    {
        return cliente.Direccion;
    }

    Cliente DatosCliente()
    {
        return cliente;
    }

    public static void AgregarPedidoALista(Pedido pedido, List<Pedido> lista)
    {
        lista.Add(pedido);
    }

    // public static Pedido BuscarPedidoNro(int nro, List<Pedido> lista)
    // {
    //     var pedido = lista.FirstOrDefault(p => p.Nro == nro);

    //     if (pedido != null)
    //     {
    //         return pedido;
    //     }
    //     else
    //     {
    //         Console.WriteLine("\nEl pedido no existe:");
    //         return null;
    //     }
    // }

    public static void ActualizarEstado(Pedido pedido)
    {
        if (pedido != null)
        {
            Console.WriteLine("\n1. Pendiente ");
            Console.WriteLine("\n2. En Proceso ");
            Console.WriteLine("\n3. Completado ");
            Console.WriteLine("\n4. Cancelado ");
            Console.WriteLine("\nSeleccione el estado:");
            string opcionEstado = Console.ReadLine();
            switch (opcionEstado)
            {
                case "2":
                    pedido.Estado = EstadoP.EnProceso;
                    break;
                case "3":
                    pedido.Estado = EstadoP.Completado;
                    break;
                case "4":
                    pedido.Estado = EstadoP.Cancelado;
                    break;
                default:
                    pedido.Estado = EstadoP.Pendiente;
                    break;
            }
            Console.WriteLine("\nEstado actualizado!");
        } else
        {
            Console.WriteLine("\nNo existe el pedido");
        }
    }
    public static void MostrarPedido(Pedido pedido)
    {
        Console.WriteLine("\nPEDIDO Nro : " + pedido.Nro);
        Console.WriteLine("Observacion: " + pedido.Obs);
        Console.WriteLine("Estado: " + pedido.Estado);
        Console.WriteLine("\nCLIENTE");
        Cliente.MostrarCliente(pedido.Cliente);
    }

    // public static void MostrarListaPedidos(List<Pedido> lista)
    // {
    //     foreach (var p in lista)
    //     {
    //         Pedido.MostrarPedido(p);
    //     }
    // }

    // public static Pedido AltaPedido()
    // {
    //     Pedido nuevoPedido = new();
    //     int nroPedido;

    //     Console.WriteLine("\nIngrese el numero del pedido:");
    //     // Controlar hasta que ingrese un numero
    //     while (!int.TryParse(Console.ReadLine(), out nroPedido))
    //     {
    //         Console.WriteLine("Por favor, ingrese un numero.");
    //     }
    //     nuevoPedido.Nro = nroPedido;

    //     Console.WriteLine("\nIngrese las observaciones del pedido:");
    //     nuevoPedido.Obs = Console.ReadLine();

    //     nuevoPedido.Cliente = Cliente.CrearCliente();

    //     return nuevoPedido;
    // }

    // public static void AsignarPedido(Cadete cadete, int nroPedido)
    // {
    //     var pedido = Cadeteria.listadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
    //     if (pedido != null)
    //     {
    //         cadete.AgregarPedido(pedido);
    //         Console.WriteLine("\nPedido asignado a: " + cadete.Nombre);
    //     }
    //     else
    //     {
    //         Console.WriteLine("\nEl pedido esta vacio");
    //     }
    // }


}