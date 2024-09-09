using System.Text.Json;
public abstract class AccesoADatos
{
    public abstract List<Cadeteria> LeerCadeterias(string archivo);
    public abstract List<Cadete> LeerCadetes(string archivo);
}
public class AccesoCSV : AccesoADatos
{
    public override List<Cadeteria> LeerCadeterias(string archivo)
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
    public override List<Cadete> LeerCadetes(string archivo)
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

public class AccesoJSON : AccesoADatos
{
    public override List<Cadeteria> LeerCadeterias(string archivo)
    {
        try
        {
            if (Existe(archivo))
            {
                string jsonString = File.ReadAllText(archivo);
                List<Cadeteria> cadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(jsonString);
                return cadeterias;
            }
            else
            {
                return [];
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError al leer el archivo: " + ex.Message);
            return [];
        }
    }

    public override List<Cadete> LeerCadetes(string archivo)
    {
        try
        {
            if (Existe(archivo))
            {
                string jsonString = File.ReadAllText(archivo);
                List<Cadete> cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonString);
                return cadetes;
            }
            else
            {
                return [];
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError al leer el archivo: " + ex.Message);
            return [];
        }
    }

    // Metodo para verificar si un archivo existe y tiene datos
    public static bool Existe(string archivo)
    {
        return File.Exists(archivo) && new FileInfo(archivo).Length > 0;
    }

}
