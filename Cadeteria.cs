public class Cadeteria
{
    private string nombre;
    private int telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadeteria()
    {
        listadoCadetes = new List<Cadete>();
        listadoPedidos = new List<Pedido>();
    }

    public void AgregarPedido(Pedido pedido)
    {
        listadoPedidos.Add(pedido);
    }

    public void EliminarPedido(Pedido pedido)
    {
        listadoPedidos.Remove(pedido);
    }

    public static int CantidadPedidosEntregados(int idCadete)
    {
        Cadeteria cadeteria = new();
        int envios = 0;
        foreach (var pedido in cadeteria.ListadoPedidos)
        {
            if (pedido.Cadete.Id == idCadete)
            {
                envios += 1;
            }
        }
        return envios;
    }

    public static float JornalACobrar(int idCadete)
    {
        float valorPorPedido = 500;

        return CantidadPedidosEntregados(idCadete) * valorPorPedido;
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


    public static void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        try
        {
            Cadeteria cadeteria = new();
            Cadete cadete = cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            Pedido pedido = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro == idPedido);

            pedido.Cadete = cadete;

            if (cadete == null)
            {
                throw new Exception("Cadete no encontrado.");
            }

            // Verificar que el pedido esté correctamente creado (opcional)
            if (pedido == null)
            {
                throw new Exception("El pedido debe ser creado primero.");
            }

            Console.WriteLine("\nPedido asignado al cadete: " + cadete.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al asignar el pedido: {ex.Message}");
        }
    }

    public static void ReasignarPedido(int idCadete, int idCadeteNuevo, int idPedido)
    {
        try
        {
            Cadeteria cadeteria = new();
            Cadete cadete = cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            Cadete cadeteNuevo = cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == idCadeteNuevo);
            Pedido pedido = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro == idPedido);

            if (cadete == null || cadeteNuevo == null)
            {
                throw new Exception("Cadete no encontrado.");
            }

            // Verificar que el pedido esté correctamente creado (opcional)
            if (pedido == null)
            {
                throw new Exception("El pedido no se encuentra.");
            }

            // Asignar el pedido al NUEVO cadete
            pedido.Cadete = null;
            pedido.Cadete = cadeteNuevo;
            Console.WriteLine("\nPedido reasignado al cadete: " + cadeteNuevo.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al reasignar el pedido: {ex.Message}");
        }
    }


    public void EliminarCadete(Cadete cadete)
    {
        listadoCadetes.Remove(cadete);
    }

    public static void MostrarListaCadetes(List<Cadete> lista)
    {
        foreach (var c in lista)
        {
            Cadete.MostrarCadete(c);
        }
    }

    public static void MostrarInforme(Cadeteria cadeteria)
    {
        Console.WriteLine("\nInforme de Pedidos al Finalizar la Jornada:");

        // Cálculo de datos
        float montoTotal = 0;
        int totalEnviados = 0;

        foreach (var cadete in cadeteria.listadoCadetes)
        {
            int enviosCadete = CantidadPedidosEntregados(cadete.Id);
            float jornalCadete = Cadeteria.JornalACobrar(cadete.Id);

            montoTotal += jornalCadete;
            totalEnviados += enviosCadete;

            // Mostrar datos por cadete
            Console.WriteLine($"Cadete ID: {cadete.Id}");
            Console.WriteLine($"Nombre: {cadete.Nombre}");
            Console.WriteLine($"Cantidad de Envios: {enviosCadete}");
            Console.WriteLine($"Monto Ganado: ${jornalCadete:F2}");
            Console.WriteLine("------------------------------------------------");
        }

        float promedioEnviados = cadeteria.listadoCadetes.Count > 0 ? (float)totalEnviados / cadeteria.listadoCadetes.Count : 0;

        // Mostrar datos totales
        Console.WriteLine($"Total de Envíos: {totalEnviados}");
        Console.WriteLine($"Monto Total Ganado: ${montoTotal:F2}");
        Console.WriteLine($"Promedio de Envíos por Cadete: {promedioEnviados:F2}");

    }
}