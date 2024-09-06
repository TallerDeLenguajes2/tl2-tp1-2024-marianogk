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
    private Cadete cadete;

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public EstadoP Estado { get => estado; set => estado = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Cadete Cadete { get => cadete; set => cadete = value; }

    public Pedido()
    {
        Cliente = new Cliente();
        Cadete = new Cadete();
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
        }
        else
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
        Console.WriteLine("\nCADETE");
        Cadete.MostrarCadete(pedido.Cadete);
    }

    public static void MostrarListaPedidos(List<Pedido> lista)
    {
        foreach (var p in lista)
        {
            MostrarPedido(p);
        }
    }


}