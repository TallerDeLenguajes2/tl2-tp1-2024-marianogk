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

    public void AgregarPedido(int nro, string obs)
    {
        Pedido pedido = new()
        {
            Nro = nro,
            Obs = obs,
            Estado = Pedido.EstadoP.Pendiente,
            Cliente = Cliente.CrearCliente(),
            Cadete = null
        };
        listadoPedidos.Add(pedido);
    }

    public void EliminarPedido(int idPedido)
    {
        Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
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

    public void AltaPedido()
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

        AgregarPedido(nuevoPedido.Nro, nuevoPedido.Obs);
    }


    public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        try
        {
            Cadete cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);

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

    public void ReasignarPedido(int idCadete, int idCadeteNuevo, int idPedido)
    {
        try
        {
            Cadete cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            Cadete cadeteNuevo = listadoCadetes.FirstOrDefault(c => c.Id == idCadeteNuevo);
            Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);

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


    public void EliminarCadete(int idCadete)
    {
        Cadete cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
        listadoCadetes.Remove(cadete);
    }

    public void MostrarListaCadetes()
    {
        foreach (var c in listadoCadetes)
        {
            Cadete.MostrarCadete(c);
        }
    }

    public void MostrarInforme()
    {
        Console.WriteLine("\nInforme de Pedidos al Finalizar la Jornada:");

        // Cálculo de datos
        float montoTotal = 0;
        int totalEnviados = 0;

        foreach (var cadete in listadoCadetes)
        {
            int enviosCadete = CantidadPedidosEntregados(cadete.Id);
            float jornalCadete = JornalACobrar(cadete.Id);

            montoTotal += jornalCadete;
            totalEnviados += enviosCadete;

            // Mostrar datos por cadete
            Console.WriteLine($"Cadete ID: {cadete.Id}");
            Console.WriteLine($"Nombre: {cadete.Nombre}");
            Console.WriteLine($"Cantidad de Envios: {enviosCadete}");
            Console.WriteLine($"Monto Ganado: ${jornalCadete:F2}");
            Console.WriteLine("------------------------------------------------");
        }

        float promedioEnviados = listadoCadetes.Count > 0 ? (float)totalEnviados / listadoCadetes.Count : 0;

        // Mostrar datos totales
        Console.WriteLine($"Total de Envíos: {totalEnviados}");
        Console.WriteLine($"Monto Total Ganado: ${montoTotal:F2}");
        Console.WriteLine($"Promedio de Envíos por Cadete: {promedioEnviados:F2}");

    }
}