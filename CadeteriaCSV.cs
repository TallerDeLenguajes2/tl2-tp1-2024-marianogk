class CadeteriaCSV
{
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
                cadeterias.Add(cadeteria);
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
}