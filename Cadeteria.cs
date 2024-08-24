public class Cadeteria
{
    private string nombre;
    private int telefono;
    private List<Cadete> listadoCadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public Cadeteria()
    {
        listadoCadetes = new List<Cadete>();
    }
    public void AgregarCadete(string archivo)
    {
        using var lector = new StreamReader(archivo);
        string linea;
        while ((linea = lector.ReadLine()) != null)
        {
            var valores = linea.Split(',');
            
            var cadete = new Cadete
            {
                Id = int.Parse(valores[0]),
                Nombre = valores[1],
                Direccion = valores[2],
                Telefono = int.Parse(valores[3])
            };

            listadoCadetes.Add(cadete);
        }
    }

    public void EliminarCadete(Cadete cadete)
    {
        listadoCadetes.Remove(cadete);
    }
    Cadete ObtenerCadetePorID(int id)
    {
        return ListadoCadetes[id];
    }
    List<Cadete> ObtenerListadoCadetes()
    {
        return ListadoCadetes;
    }

}