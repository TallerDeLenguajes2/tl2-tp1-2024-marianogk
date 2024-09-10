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

    public int CantidadPedidosEntregados(int idCadete)
    {
        int envios = 0;
        foreach (var pedido in listadoPedidos)
        {
            if (pedido.Cadete.Id == idCadete)
            {
                envios += 1;
            }
        }
        return envios;
    }

    public float JornalACobrar(int idCadete)
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

        AgregarPedido(nuevoPedido.Nro, nuevoPedido.Obs);
    }


    public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        try
        {
            Cadete cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);

            if (cadete == null)
            {
                throw new Exception("Cadete no encontrado.");
            }

            // Verificar que el pedido esté correctamente creado (opcional)
            if (pedido == null)
            {
                throw new Exception("El pedido debe ser creado primero.");
            }
            pedido.Cadete = cadete;

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
            MostrarCadete(c.Id);
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

    public void ActualizarEstado(int idPedido)
    {
        Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
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
                    pedido.Estado = Pedido.EstadoP.EnProceso;
                    break;
                case "3":
                    pedido.Estado = Pedido.EstadoP.Completado;
                    break;
                case "4":
                    pedido.Estado = Pedido.EstadoP.Cancelado;
                    break;
                default:
                    pedido.Estado = Pedido.EstadoP.Pendiente;
                    break;
            }
            Console.WriteLine("\nEstado actualizado!");
        }
        else
        {
            Console.WriteLine("\nNo existe el pedido");
        }
    }

    public void MostrarPedido(int idPedido)
    {

        Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
        if (pedido != null)
        {
            Console.WriteLine("\nPEDIDO Nro : " + pedido.Nro);
            Console.WriteLine("Observacion: " + pedido.Obs);
            Console.WriteLine("Estado: " + pedido.Estado);
            Console.WriteLine("\nCLIENTE");
            MostrarCliente(pedido.Nro);
            if (pedido.Cadete != null)
            {
                Console.WriteLine("\nCADETE");
                MostrarCadete(pedido.Cadete.Id);
            }
        }
    }

    public void MostrarListaPedidos()
    {
        foreach (var p in listadoPedidos)
        {
            MostrarPedido(p.Nro);
        }
    }

    public void MostrarCliente(int idPedido)
    {
        Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
        if (pedido != null)
        {
            Console.WriteLine("Nombre: " + pedido.Cliente.Nombre);
            Console.WriteLine("Direccion: " + pedido.Cliente.Direccion);
            Console.WriteLine("Telefono: " + pedido.Cliente.Telefono);
            Console.WriteLine("Direccion referencia: " + pedido.Cliente.DatosReferenciaDireccion);
        }
    }

    public void MostrarCadete(int idCadete)
    {
        Cadete cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
        if (cadete != null)
        {
            Console.WriteLine("\nCADETE Nro : " + cadete.Id);
            Console.WriteLine("Nombre: " + cadete.Nombre);
            Console.WriteLine("Direccion: " + cadete.Direccion);
            Console.WriteLine("Telefono: " + cadete.Telefono);
        }
    }

}