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




}