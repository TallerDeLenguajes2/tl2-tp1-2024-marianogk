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

    void ActualizarEstado(EstadoP Estado)
    {
        estado = Estado;
    }
    public void MostrarPedido(Pedido pedido)
    {
        Console.WriteLine("\nPEDIDO Nro : " + pedido.Nro);
        Console.WriteLine("Observacion: " + pedido.Obs);
        Console.WriteLine("Estado: " + pedido.Estado);
        Console.WriteLine("\nCLIENTE");
        Cliente.MostrarCliente(pedido.Cliente);
    }

}