public class Cadeteria
{
    private string nombre;
    private int telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos; // Agregado

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadeteria()
    {
        listadoCadetes = new List<Cadete>();
        ListadoPedidos = new List<Pedido>();
    }

    public static void AsignarPedido(Cadeteria cadeteria, int idCadete, int nroPedido)
    {
        var pedido = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);

        var cadete = cadeteria.ObtenerCadetePorID(idCadete);

        if (pedido != null && cadete != null)
        {
            cadete.AgregarPedido(pedido);
            Console.WriteLine("\nPedido asignado a: " + cadete.Nombre);
        }
        else
        {
            Console.WriteLine("\nEl pedido no existe");
        }
    }

    public static void ReasignarPedido(Cadeteria cadeteria, int idCadete, int idCadeteNuevo, int nroPedido)
    {
        var pedido = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
        var cadete = cadeteria.ObtenerCadetePorID(idCadete);

        var cadeteNuevo = cadeteria.ObtenerCadetePorID(idCadeteNuevo);

        if (pedido != null && cadete != null && cadeteNuevo != null)
        {
            cadete.EliminarPedido(pedido);
            cadeteNuevo.AgregarPedido(pedido);
            Console.WriteLine("\nPedido reasignado a: " + cadeteNuevo.Nombre);
        }
        else
        {
            Console.WriteLine("\nEl pedido no existe");
        }
    }

    public static List<Cadeteria> LeerCadeterias(string archivo)
    {
        var cadeterias = new List<Cadeteria>();
        using var lector = new StreamReader(archivo);
        string linea;
        bool esPrimeraLinea = true;

        while ((linea = lector.ReadLine()) != null)
        {
            if (esPrimeraLinea)
            {
                esPrimeraLinea = false;
                continue; // Omitir la primera linea
            }

            var valores = linea.Split(',');
            if (valores.Length < 2)
            {
                Console.WriteLine("Formato de línea invalido: " + linea);
                continue;
            }

            try
            {
                var cadeteria = new Cadeteria
                {
                    Nombre = valores[0],
                    Telefono = int.Parse(valores[1])
                };
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error en el formato de los datos: {ex.Message}");
            }
        }
        return cadeterias;
    }
    public static List<Cadete> LeerCadetes(string archivo)
    {
        var cadetes = new List<Cadete>();
        using var lector = new StreamReader(archivo);
        string linea;
        bool esPrimeraLinea = true;

        while ((linea = lector.ReadLine()) != null)
        {
            if (esPrimeraLinea)
            {
                esPrimeraLinea = false;
                continue; // Omitir la primera linea
            }

            var valores = linea.Split(',');
            if (valores.Length < 4)
            {
                Console.WriteLine("Formato de línea invalido: " + linea);
                continue;
            }

            try
            {
                var cadete = new Cadete
                {
                    Id = int.Parse(valores[0]),
                    Nombre = valores[1],
                    Direccion = valores[2],
                    Telefono = int.Parse(valores[3])
                };

                cadetes.Add(cadete);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error en el formato de los datos: {ex.Message}");
            }
        }
        return cadetes;
    }

    public void EliminarCadete(Cadete cadete)
    {
        listadoCadetes.Remove(cadete);
    }
    public Cadete ObtenerCadetePorID(int id)
    {
        return listadoCadetes.FirstOrDefault(c => c.Id == id);
    }
    public static List<Cadete> ObtenerListadoCadetes(Cadeteria cadeteria)
    {
        return cadeteria.listadoCadetes;
    }

    public static List<Pedido> ObtenerListadoPedidos(Cadeteria cadeteria)
    {
        return cadeteria.ListadoPedidos;
    }

    public static void MostrarListaCadetes(List<Cadete> lista)
    {
        foreach (var c in lista)
        {
            Cadete.MostrarCadete(c);
        }
    }

}