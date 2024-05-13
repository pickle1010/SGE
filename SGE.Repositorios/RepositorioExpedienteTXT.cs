namespace SGE.Repositorios;

using System.Collections.Generic;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT : IExpendienteRepositorio
{
    private List<Expediente> Expedientes { get; set; }
    private int ProximoId { get; set; } = 1;
    private string DireccionTXT { get; set; }

    public RepositorioExpedienteTXT(string direccionTXT)
    {
        DireccionTXT = direccionTXT;        
        Expedientes = CargarExpedientes();
    }

    private List<Expediente> CargarExpedientes()
    {
        List<Expediente> expedientes = new List<Expediente>();
        string[] lineas = File.ReadAllLines(DireccionTXT);
        foreach (string linea in lineas)
        {
            string[] atributos = linea.Split(',');
            Expediente expediente = new Expediente(atributos[1]);
            expediente.Id = int.Parse(atributos[0]);
            expediente.Estado = (EstadoExpediente) Enum.Parse(typeof(EstadoExpediente), atributos[2]);
            expediente.FechaHoraCreacion = DateTime.Parse(atributos[3]);
            expediente.FechaHoraUltimaModificacion = DateTime.Parse(atributos[4]);
            expediente.IdUsuarioUltimaModificacion = int.Parse(atributos[5]);
            expedientes.Add(expediente);
        }
        return expedientes;
    }

    private string FormatExpediente(Expediente expediente)
    {
        return $"{expediente.Id},{expediente.Caratula},{expediente.Estado},{expediente.FechaHoraCreacion},{expediente.FechaHoraUltimaModificacion},{expediente.IdUsuarioUltimaModificacion}";
    }

    public void Agregar(Expediente expediente)
    {
        expediente.Id = ProximoId++;
        Expedientes.Add(expediente);
        using StreamWriter sw = new StreamWriter(DireccionTXT, true);
        sw.WriteLine(FormatExpediente(expediente));
    }

    public Expediente? ConsultarPorID(int id) => Expedientes.Find(e => e.Id == id) ?? throw new RepositorioException($"No existe expediente que tenga el id #{expedienteId}");

    public List<Expediente> ConsultarTodos(){
        if (Expedientes.Count == 0)
            throw new RepositorioException($"No existen expedientes");
        else
            return Expedientes;
    }
    
    public void Eliminar(int id) 
    {
        int indice = Expedientes.FindIndex(e => e.Id == id);
        if(indice >= 0)
        {
            Expedientes.RemoveAt(indice);
            List<String> lineas = File.ReadAllLines(DireccionTXT).ToList();
            lineas.RemoveAt(indice);
            File.WriteAllLines(DireccionTXT, lineas);
        }
        {
            throw new RepositorioException($"No existe expediente que tenga el id #{id}");
        }
    }

    public void Modificar(Expediente expediente)
    {
        int indice = Expedientes.FindIndex(e => e.Id == expediente.Id);
        if(indice >= 0)
        {
            expediente.FechaHoraCreacion = Expedientes[indice];
            Expedientes[indice] = expediente;
            string[] lineas = File.ReadAllLines(DireccionTXT);
            lineas[indice] = FormatExpediente(expediente);
            File.WriteAllLines(DireccionTXT, lineas);
        }
        {
            throw new RepositorioException($"No existe expediente que tenga el id #{expediente.Id}");
        }
    }
}
