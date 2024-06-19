using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioTramite : ITramiteRepositorio
{
    private List<Tramite> Tramites { get; set; }
    private int ProximoId { get; set; } = 1;
    private string DireccionTXT { get; set; }

    public RepositorioTramite(string direccionTXT)
    {
        DireccionTXT = direccionTXT;        
        Tramites = CargarTramites();
        if(Tramites.Count > 0){
            ProximoId = Tramites.Last().Id + 1;
        }
    }

    private List<Tramite> CargarTramites()
    {
        List<Tramite> tramites = new List<Tramite>();
        if(Path.Exists(DireccionTXT)){
            using StreamReader sr = new StreamReader(DireccionTXT, true);
            while(!sr.EndOfStream)
            {
                string? linea = sr.ReadLine();
                if(linea != null && linea.Length > 0){
                    string[] atributos = linea.Split(','); 
                    Tramite tramite = new Tramite(atributos[3],int.Parse(atributos[1]));
                    tramite.Id = int.Parse(atributos[0]);
                    tramite.Etiqueta = (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), atributos[2]);
                    tramite.FechaHoraCreacion = DateTime.Parse(atributos[4]);
                    tramite.FechaHoraUltimaModificacion = DateTime.Parse(atributos[5]);
                    tramite.IdUsuarioUltimaModificacion = int.Parse(atributos[6]);
                    tramites.Add(tramite);
                }
            }
        }
        else {
            File.Create(DireccionTXT).Close();
        }
        return tramites;
    }

    private string FormatTramite(Tramite t)
    {
        return $"{t.Id},{t.ExpedienteId},{t.Etiqueta},{t.Contenido},{t.FechaHoraCreacion},{t.FechaHoraUltimaModificacion},{t.IdUsuarioUltimaModificacion}";
    }

    public void Agregar(Tramite tramite)
    {
        tramite.Id = ProximoId++;
        Tramites.Add(tramite);
        using StreamWriter sw = new StreamWriter(DireccionTXT, true);
        sw.WriteLine(FormatTramite(tramite));
    }

    public Tramite Eliminar(int id)
    {
        int indice = Tramites.FindIndex(t => t.Id == id);
        if(indice >= 0){
            Tramite tramite = Tramites[indice];
            Tramites.RemoveAt(indice);
            List<string> lineas = File.ReadAllLines(DireccionTXT).ToList(); 
            lineas.RemoveAt(indice);
            File.WriteAllLines(DireccionTXT,lineas);
            return tramite;      
        }
        else 
        {
            throw new RepositorioException($"No existe trámite que tenga el id #{id}");
        }
    }

    public void Modificar(Tramite tramite)
    {
        int indice = Tramites.FindIndex(t => t.Id == tramite.Id);
        if(indice >= 0){
            tramite.FechaHoraCreacion = Tramites[indice].FechaHoraCreacion;
            Tramites[indice] = tramite;
            string[] lineas = File.ReadAllLines(DireccionTXT);
            lineas[indice] = FormatTramite(tramite);
            File.WriteAllLines(DireccionTXT, lineas);
        }
        else {
            throw new RepositorioException($"No existe trámite que tenga el id #{tramite.Id}");
        }
    } 

    public List<Tramite> ConsultarPorEtiqueta(EtiquetaTramite etiqueta)
    {
        List<Tramite> tramitesConEtiqueta = new List<Tramite>();
        foreach(Tramite tramite in Tramites){
            if(tramite.Etiqueta == etiqueta){
                tramitesConEtiqueta.Add(tramite);
            }
        }
        return tramitesConEtiqueta;
    }

    public Tramite ConsultarPorId(int id) => Tramites.Find(t => t.Id == id) ?? throw new RepositorioException($"No existe trámite que tenga el id #{id}");

    public List<Tramite> ConsultarPorExpediente(int expedienteID){
        List<Tramite> tramitesDelExpedienteID = new List<Tramite>();
        foreach(Tramite tramite in Tramites){
            if(tramite.ExpedienteId == expedienteID){
                tramitesDelExpedienteID.Add(tramite);
            }
        }
        if(tramitesDelExpedienteID != null)
        {
            return tramitesDelExpedienteID;
        }
        else 
        {
            throw new RepositorioException($"No existen trámites asociados al expediente con id #{expedienteID}");
        }
    }
}
