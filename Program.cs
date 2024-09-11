public class Program
{
    public static void Main(string[] args)
    {
        Cadeteria cadeteria1 = new();

        string opcionMenu;
        int nroPedido, nroCadete;
        string archivoCadeterias = "cadeteria.csv";
        string archivoCadetes = "cadete.csv";
        var ListaCadeterias = new List<Cadeteria>();
        var ListaCadetes = new List<Cadete>();

        Console.WriteLine("\nComo desea cargar los datos?");
        Console.WriteLine("\nIngrese:   1. JSON   2. CSV");
        string opcionArchivo = Console.ReadLine();
        if (opcionArchivo == "1")
        {
            AccesoJSON accesoJSON = new();

            ListaCadeterias = accesoJSON.LeerCadeterias(archivoCadeterias);
            ListaCadetes = accesoJSON.LeerCadetes(archivoCadetes);
        }
        else
        {
            AccesoCSV accesoCSV = new();

            ListaCadeterias = accesoCSV.LeerCadeterias(archivoCadeterias);
            ListaCadetes = accesoCSV.LeerCadetes(archivoCadetes);
        }



        // Suponiendo que solo trabajamos con la primera cadetería
        cadeteria1 = ListaCadeterias.FirstOrDefault();
        if (cadeteria1 == null)
        {
            Console.WriteLine("No se encontro ninguna cadeteria.");
            return;
        }
        // Asignar cadetes a la cadetería 
        cadeteria1.ListadoCadetes.AddRange(ListaCadetes);

        do
        {
            MenuPrincipal();
            opcionMenu = Console.ReadLine();

            switch (opcionMenu)
            {
                case "1":
                    try
                    {
                        AltaPedido(out nroPedido, out string obs, out string nombre, out string direccion, out string telefono, out string datosReferencia);
                        cadeteria1.AgregarPedido(nroPedido, obs, nombre, direccion, telefono, datosReferencia);
                        List<string> pedidoInfo = cadeteria1.MostrarPedido(nroPedido);
                        foreach (var linea in pedidoInfo)
                        {
                            Console.WriteLine(linea);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nError al crear el pedido: {ex.Message}");
                    }
                    break;
                case "2":
                    Console.WriteLine("\nIngrese el numero del pedido a asignar:");
                    while (!int.TryParse(Console.ReadLine(), out nroPedido))
                    {
                        Console.WriteLine("Por favor, ingrese un numero.");
                    }
                    Console.WriteLine("\nIngrese el id del cadete asignado:");
                    while (!int.TryParse(Console.ReadLine(), out nroCadete))
                    {
                        Console.WriteLine("Por favor, ingrese un numero.");
                    }
                    try
                    {
                        cadeteria1.AsignarCadeteAPedido(nroCadete, nroPedido);
                        Console.WriteLine("\nPedido asignado al cadete: " + nroCadete);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nError al asignar el pedido: {ex.Message}");
                    }
                    break;
                case "3":
                    Console.WriteLine("\nIngrese el numero del pedido a actualizar:");
                    while (!int.TryParse(Console.ReadLine(), out nroPedido))
                    {
                        Console.WriteLine("Por favor, ingrese un numero.");
                    }
                    Console.WriteLine("\n1. Pendiente ");
                    Console.WriteLine("\n2. En Proceso ");
                    Console.WriteLine("\n3. Completado ");
                    Console.WriteLine("\n4. Cancelado ");
                    Console.WriteLine("\nSeleccione el estado:");
                    string opcionEstado = Console.ReadLine();
                    try
                    {
                        cadeteria1.ActualizarEstado(nroPedido, opcionEstado);
                        Console.WriteLine("\nEstado actualizado!");
                        List<string> pedidoInfo = cadeteria1.MostrarPedido(nroPedido);
                        foreach (var linea in pedidoInfo)
                        {
                            Console.WriteLine(linea);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nError al actualizar el estado del pedido: {ex.Message}");
                    }
                    break;
                case "4":
                    Console.WriteLine("\nIngrese el numero del pedido a reasignar:");
                    while (!int.TryParse(Console.ReadLine(), out nroPedido))
                    {
                        Console.WriteLine("Por favor, ingrese un numero.");
                    }
                    Console.WriteLine("\nIngrese el id del NUEVO cadete reasignado:");
                    while (!int.TryParse(Console.ReadLine(), out nroCadete))
                    {
                        Console.WriteLine("Por favor, ingrese un numero.");
                    }
                    try
                    {
                        cadeteria1.ReasignarPedido(nroCadete, nroPedido);
                        Console.WriteLine("\nPedido reasignado al cadete: " + nroCadete);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nError al reasignar el pedido: {ex.Message}");
                    }
                    break;
                case "5":
                    List<string> listaPedidos = cadeteria1.MostrarListaPedidos();
                    foreach (var linea in listaPedidos)
                    {
                        Console.WriteLine(linea);
                    }
                    break;
                case "6":
                    List<string> listaCadetes = cadeteria1.MostrarListaCadetes();
                    foreach (var linea in listaCadetes)
                    {
                        Console.WriteLine(linea);
                    }
                    break;
                case "7":
                    Console.WriteLine("\nInforme de Pedidos al Finalizar la Jornada:");
                    List<string> informe = cadeteria1.MostrarInforme();
                    foreach (var linea in informe)
                    {
                        Console.WriteLine(linea);
                    }
                    break;
                case "8":
                    opcionMenu = "8";
                    break;
                default:
                    Console.WriteLine("\nOpcionMenu no valida.\n");
                    break;
            }

        } while (opcionMenu != "8");
    }

    public static void MenuPrincipal()
    {
        Console.WriteLine("\n1. Alta Pedido ");
        Console.WriteLine("\n2. Asignar Pedido ");
        Console.WriteLine("\n3. Cambiar Estado ");
        Console.WriteLine("\n4. Reasignar Pedido ");
        Console.WriteLine("\n5. Mostrar pedidos ");
        Console.WriteLine("\n6. Mostrar cadetes ");
        Console.WriteLine("\n7. Mostrar informe ");
        Console.WriteLine("\n8. Salir ");
        Console.WriteLine("\nIngrese:");
    }

    public static void AltaPedido(out int nroPedido, out string obs, out string nombre, out string direccion, out string telefono, out string datosReferencia)
    {
        Console.WriteLine("\nIngrese el numero del pedido:");
        // Controlar hasta que ingrese un numero
        while (!int.TryParse(Console.ReadLine(), out nroPedido))
        {
            Console.WriteLine("Por favor, ingrese un numero.");
        }

        Console.WriteLine("\nIngrese las observaciones del pedido:");
        obs = Console.ReadLine();

        Console.WriteLine("\nIngrese el nombre del cliente:");
        nombre = Console.ReadLine();

        Console.WriteLine("\nIngrese la dirección:");
        direccion = Console.ReadLine();

        Console.WriteLine("\nIngrese el telefono:");
        telefono = Console.ReadLine();

        Console.WriteLine("\nIngrese datos de referencia para la direccion:");
        datosReferencia = Console.ReadLine();
    }

}

