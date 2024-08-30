public class Program
{
    public static void Main(string[] args)
    {
        Cadeteria Cadeteria1 = new();

        List<Pedido> ListaPedidos = new();

        Pedido pedido1 = new();
        Cadete cadete1 = new(), cadete2 = new();
        string opcion;
        int nroPedido, nroCadete, nroCadete2;
        string archivoCadeterias = "cadeteria.csv";
        string archivoCadetes = "cadete.csv";
        var ListaCadeterias = new List<Cadeteria>();
        var ListaCadetes = new List<Cadete>();

        ListaCadeterias = Cadeteria.LeerCadeterias(archivoCadeterias);
        ListaCadetes = Cadeteria.LeerCadetes(archivoCadetes);


        // Asignar pedidos a ListaPedidos
        ListaPedidos.Add(pedido1);

        do
        {
            MenuPrincipal();
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    pedido1 = Pedido.AltaPedido();
                    Pedido.AgregarPedidoALista(pedido1, Cadeteria1.ListadoPedidos);
                    Pedido.MostrarPedido(pedido1);
                    break;
                case "2":
                    cadete1.AgregarPedido(pedido1);
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

                    cadete1 = Cadeteria.ObtenerCadetePorID(Cadeteria1, nroCadete);
                    pedido1 = ListaPedidos.FirstOrDefault(p => p.Nro == nroPedido);
                    cadete1.AgregarPedido(pedido1);
                    // Cadeteria1.ListadoCadetes.FirstOrDefault(c => c.Id == nroCadete).AgregarPedido();
                    // Cadeteria.AsignarPedido(Cadeteria1, nroCadete, nroPedido);
                    break;
                case "3":
                    Pedido.ActualizarEstado(pedido1);
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
                    cadete1 = Cadeteria.ObtenerCadetePorID(Cadeteria1, nroCadete);

                    if (Cadete.ObtenerPedidoPorID(cadete1.ListadoPedidos, nroPedido) != null)
                    {
                        cadete2 = Cadeteria.ObtenerCadetePorID(Cadeteria1, nroCadete2);
                        pedido1 = cadete1.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
                        cadete2.AgregarPedido(pedido1);
                        cadete1.EliminarPedido(pedido1);
                    }
                    break;
                case "5":
                    Pedido.MostrarListaPedidos(Cadeteria1.ListadoPedidos);
                    break;
                case "6":
                    Cadeteria.MostrarListaCadetes(ListaCadetes);
                    break;
                case "7":
                    opcion = "7";
                    break;
                default:
                    Console.WriteLine("\nOpcion no valida.\n");
                    break;
            }

        } while (opcion != "7");
    }


    public static void MenuPrincipal()
    {
        Console.WriteLine("\n1. Alta Pedido ");
        Console.WriteLine("\n2. Asignar Pedido ");
        Console.WriteLine("\n3. Cambiar Estado ");
        Console.WriteLine("\n4. Reasignar Pedido ");
        Console.WriteLine("\n5. Mostrar pedidos ");
        Console.WriteLine("\n6. Mostrar cadetes ");
        Console.WriteLine("\n7. Salir ");
        Console.WriteLine("\nIngrese:");
    }

}

