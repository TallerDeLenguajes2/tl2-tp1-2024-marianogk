public class Program
{
    public static void Main(string[] args)
    {
        Pedido pedido1 = new();
        
        Cadete cadete1, cadete2;
        cadete1 = new();
        cadete2 = new();

        MenuPrincipal();
        string opcion;
        opcion = Console.ReadLine();
        do
        {
            switch (opcion)
            {
                case "1":
                    Pedido.AltaPedido();
                    break;
                case "2":
                    Pedido.AsignarPedido(cadete1, pedido1);
                    break;
                case "3":
                    Pedido.ActualizarEstado(pedido1);
                    break;
                case "4":
                    Pedido.ReasignarPedido(cadete1, cadete2, pedido1);
                    break;
                case "5":
                    opcion = "5";
                    break;

                default:
                    Console.WriteLine("\nOpcion no valida.\n");
                    break;
            }

        } while (opcion != "5");
    }


    public static void MenuPrincipal()
    {
        Console.WriteLine("\n1. CREAR PERSONAJES ");
        Console.WriteLine("\n2. NUEVA PARTIDA ");
        Console.WriteLine("\n3. CARGAR PARTIDA ");
        Console.WriteLine("\n4. MOSTRAR HISTORIAL ");
        Console.WriteLine("\n5. SALIR ");
        Console.WriteLine("\nINGRESE:");
    }


}

