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

    public void AgregarPedido(int nro, string obs, string nombre, string direccion, string telefono, string datosReferencia)
    {
        Pedido pedido = new()
        {
            Nro = nro,
            Obs = obs,
            Estado = Pedido.EstadoP.Pendiente,
            Cliente = Cliente.CrearCliente(nombre, direccion, telefono, datosReferencia),
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

    public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        Cadete cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
        Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);

        if (cadete != null && pedido != null)
        {
            pedido.Cadete = cadete;
        }
    }

    public void ReasignarPedido(int idCadeteNuevo, int idPedido)
    {
        Cadete cadeteNuevo = listadoCadetes.FirstOrDefault(c => c.Id == idCadeteNuevo);
        Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);

        if (cadeteNuevo != null && pedido != null)
        {
            pedido.Cadete = cadeteNuevo;
        }
    }


    public void EliminarCadete(int idCadete)
    {
        Cadete cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
        listadoCadetes.Remove(cadete);
    }

    public List<string> MostrarInforme()
    {
        List<string> informe = new();
        float montoTotal = 0;
        int totalEnviados = 0;

        foreach (var cadete in listadoCadetes)
        {
            int enviosCadete = CantidadPedidosEntregados(cadete.Id);
            float jornalCadete = JornalACobrar(cadete.Id);

            montoTotal += jornalCadete;
            totalEnviados += enviosCadete;

            // Mostrar datos por cadete
            informe.Add($"Cadete ID: {cadete.Id}");
            informe.Add($"Nombre: {cadete.Nombre}");
            informe.Add($"Cantidad de Envios: {enviosCadete}");
            informe.Add($"Monto Ganado: ${jornalCadete:F2}");
            informe.Add("------------------------------------------------");
        }

        float promedioEnviados = listadoCadetes.Count > 0 ? (float)totalEnviados / listadoCadetes.Count : 0;

        // Mostrar datos totales
        informe.Add($"Total de Envíos: {totalEnviados}");
        informe.Add($"Monto Total Ganado: ${montoTotal:F2}");
        informe.Add($"Promedio de Envíos por Cadete: {promedioEnviados:F2}");

        return informe;
    }

    public void ActualizarEstado(int idPedido, string opcionEstado)
    {
        Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
        if (pedido != null)
        {
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
        }
    }

    public List<string> MostrarPedido(int idPedido)
    {
        Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
        if (pedido != null)
        {
            List<string> pedidoInfo =
            [
                "\nPEDIDO Nro : " + pedido.Nro,
                "Observacion: " + pedido.Obs,
                "Estado: " + pedido.Estado,
                "\nCLIENTE",
            ];

            pedidoInfo.AddRange(MostrarCliente(pedido.Nro));

            if (pedido.Cadete != null)
            {
                pedidoInfo.Add("\nCADETE");
                pedidoInfo.AddRange(MostrarCadete(pedido.Cadete.Id));
            }
            return pedidoInfo;
        }
        else
        {
            return ["Pedido no encontrado."];
        }
    }

    public List<string> MostrarListaPedidos()
    {
        List<string> listaPedidos = new();
        foreach (var p in listadoPedidos)
        {
            listaPedidos.AddRange(MostrarPedido(p.Nro));
            listaPedidos.Add("------------------------------------------------");
        }
        return listaPedidos;
    }

    public List<string> MostrarCliente(int idPedido)
    {
        Pedido pedido = listadoPedidos.FirstOrDefault(p => p.Nro == idPedido);
        if (pedido != null)
        {
            List<string> clienteInfo =
            [
                "Nombre: " + pedido.Cliente.Nombre,
                "Direccion: " + pedido.Cliente.Direccion,
                "Telefono: " + pedido.Cliente.Telefono,
                "Direccion referencia: " + pedido.Cliente.DatosReferenciaDireccion,
            ];
            return clienteInfo;
        }
        else
        {
            return ["Cliente no encontrado."];
        }
    }

    public List<string> MostrarCadete(int idCadete)
    {
        Cadete cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
        if (cadete != null)
        {
            List<string> cadeteInfo =
            [
            "Nro : " + cadete.Id,
            "Nombre: " + cadete.Nombre,
            "Direccion: " + cadete.Direccion,
            "Telefono: " + cadete.Telefono
            ];
            return cadeteInfo;
        }
        else
        {
            return ["Cadete no encontrado."];
        }
    }

    public List<string> MostrarListaCadetes()
    {
        List<string> listaCadetes = new();
        foreach (var c in listadoCadetes)
        {
            listaCadetes.AddRange(MostrarCadete(c.Id));
            listaCadetes.Add("------------------------------------------------");
        }
        return listaCadetes;
    }

}