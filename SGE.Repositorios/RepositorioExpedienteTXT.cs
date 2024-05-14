namespace SGE.Repositorios;

using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
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
        if(Expedientes.Count > 0){
            ProximoId = Expedientes.Last().Id + 1;
        }

    }

    private List<Expediente> CargarExpedientes()
    {
        List<Expediente> expedientes = new List<Expediente>();
        if(Path.Exists(DireccionTXT)){
            using StreamReader sr = new StreamReader(DireccionTXT, true);
            while(!sr.EndOfStream)
            {
                string? linea = sr.ReadLine();
                if(linea != null && linea.Length > 0){
                    string[] atributos = linea.Split(',');
                    Expediente expediente = new Expediente(atributos[1]);
                    expediente.Id = int.Parse(atributos[0]);
                    expediente.Estado = (EstadoExpediente) Enum.Parse(typeof(EstadoExpediente), atributos[2]);
                    expediente.FechaHoraCreacion = DateTime.Parse(atributos[3]);
                    expediente.FechaHoraUltimaModificacion = DateTime.Parse(atributos[4]);
                    expediente.IdUsuarioUltimaModificacion = int.Parse(atributos[5]);
                    expedientes.Add(expediente);
                }
            }
        }
        else{
            File.Create(DireccionTXT).Close();
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

    public Expediente ConsultarPorID(int id) => Expedientes.Find(e => e.Id == id) ?? throw new RepositorioException($"No existe expediente que tenga el id #{id}");

    public List<Expediente> ConsultarTodos() => Expedientes;

    public Expediente Eliminar(int id) 
    {
        int indice = Expedientes.FindIndex(e => e.Id == id);
        if(indice >= 0)
        {
            Expediente expediente = Expedientes[indice];
            Expedientes.RemoveAt(indice);
            List<String> lineas = File.ReadAllLines(DireccionTXT).ToList();
            lineas.RemoveAt(indice);
            File.WriteAllLines(DireccionTXT, lineas);
            return expediente;
        }
        else {
            throw new RepositorioException($"No existe expediente que tenga el id #{id}");
        }
    }

    public void Modificar(Expediente expediente)
    {
        int indice = Expedientes.FindIndex(e => e.Id == expediente.Id);
        if(indice >= 0)
        {
            expediente.FechaHoraCreacion = Expedientes[indice].FechaHoraCreacion; //Habia Incompatibilidad de tipos, no recuerdo si esto estaba corregido
            Expedientes[indice] = expediente;
            string[] lineas = File.ReadAllLines(DireccionTXT);
            lineas[indice] = FormatExpediente(expediente);
            File.WriteAllLines(DireccionTXT, lineas);
        }
        else{
            throw new RepositorioException($"No existe expediente que tenga el id #{expediente.Id}");
        }
    }
}
