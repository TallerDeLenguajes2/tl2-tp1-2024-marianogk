public class Pedido
{
    public enum Estado
    {
        Pendiente,
        EnProceso,
        Completado,
        Cancelado
    }
    private int nro;
    private string obs;
    private Estado estado;
    private Cliente cliente;

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }

    public Pedido()
    {
        Cliente = new Cliente();
        // estado = Estado.Pendiente;
    }

}