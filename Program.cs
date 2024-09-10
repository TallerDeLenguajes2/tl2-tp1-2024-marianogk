public class Program
{
    public static void Main(string[] args)
    {
        Cadeteria cadeteria1 = new();

        // List<Pedido> ListaPedidos = new();

        Pedido pedido1 = new();
        Cadete cadete1 = new(), cadete2 = new();
        string opcion;
        int nroPedido, nroCadete, nroCadete2;
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
            AccesoCSV accesoCSV = new ();

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
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    cadeteria1.AltaPedido();
                    int id = cadeteria1.ListadoPedidos.Last().Nro;
                    cadeteria1.MostrarPedido(id);
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
                    Pedido pedidoBuscado = cadeteria1.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
                    cadeteria1.AsignarCadeteAPedido(nroCadete, nroPedido);
                    break;
                case "3":
                    Console.WriteLine("\nIngrese el numero del pedido a actualizar:");
                    while (!int.TryParse(Console.ReadLine(), out nroPedido))
                    {
                        Console.WriteLine("Por favor, ingrese un numero.");
                    }
                    pedidoBuscado = cadeteria1.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
                    cadeteria1.ActualizarEstado(nroPedido);
                    cadeteria1.MostrarPedido(nroPedido);
                    break;
                case "4":
                    Console.WriteLine("\nIngrese el numero del pedido a reasignar:");
                    while (!int.TryParse(Console.ReadLine(), out nroPedido))
                    {
                        Console.WriteLine("Por favor, ingrese un numero.");
                    }
                    Console.WriteLine("\nIngrese el id del cadete asignado:");
                    while (!int.TryParse(Console.ReadLine(), out nroCadete))
                    {
                        Console.WriteLine("Por favor, ingrese un numero.");
                    }
                    Console.WriteLine("\nIngrese el id del NUEVO cadete reasignado:");
                    while (!int.TryParse(Console.ReadLine(), out nroCadete2))
                    {
                        Console.WriteLine("Por favor, ingrese un numero.");
                    }
                    cadeteria1.ReasignarPedido(nroCadete, nroCadete2, nroPedido);
                    break;
                case "5":
                    cadeteria1.MostrarListaPedidos();
                    break;
                case "6":
                    cadeteria1.MostrarListaCadetes();
                    break;
                case "7":
                    cadeteria1.MostrarInforme();
                    break;
                case "8":
                    opcion = "8";
                    break;
                default:
                    Console.WriteLine("\nOpcion no valida.\n");
                    break;
            }

        } while (opcion != "8");
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

}

