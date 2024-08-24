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
        // estado = Estado.Pendiente;
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
        Console.WriteLine("\n1. Pendiente ");
        Console.WriteLine("\n2. En Proceso ");
        Console.WriteLine("\n3. Completado ");
        Console.WriteLine("\n4. Cancelado ");
        Console.WriteLine("\nINGRESE:");
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
    }
    public void MostrarPedido(Pedido pedido)
    {
        Console.WriteLine("\nPEDIDO Nro : " + pedido.Nro);
        Console.WriteLine("Observacion: " + pedido.Obs);
        Console.WriteLine("Estado: " + pedido.Estado);
        Console.WriteLine("\nCLIENTE");
        Cliente.MostrarCliente(pedido.Cliente);
    }
    public static Pedido AltaPedido()
    {
        Pedido nuevoPedido = new();

        Console.WriteLine("Ingrese el número del pedido:");
        nuevoPedido.Nro = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese las observaciones del pedido:");
        nuevoPedido.Obs = Console.ReadLine();
        nuevoPedido.Estado = EstadoP.Pendiente;

        nuevoPedido.Cliente = Cliente.CrearCliente();

        return nuevoPedido;
    }

    public static void AsignarPedido()
    {
        throw new NotImplementedException();
    }
    public static void ReasignarPedido()
    {
        throw new NotImplementedException();
    }


}