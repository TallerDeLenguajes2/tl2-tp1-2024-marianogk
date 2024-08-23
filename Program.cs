public class Pedido
{
    class Cliente
    {
        private string nombre;
        private string direccion;
        private int telefono;
        private string datosReferenciaDireccion;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
    }
    enum estado
    {
        Pendiente,
        EnProceso,
        Completado,
        Cancelado
    }
    private int nro;
    private string obs;
    private Cliente cliente;

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }



    private enum estado;
}
class Cadeteria
{
    private string nombre;
    private int telefono;
    private List<Cadete> listadoCadetes
public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }

    class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private int telefono;
        private List<int> listadoPedidos = public Cadete()
        {
            listadoPedidos = new List<Pedido>();
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
    }
}

