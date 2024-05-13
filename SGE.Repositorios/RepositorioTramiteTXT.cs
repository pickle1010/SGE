using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioTramiteTXT : ITramiteRepositorio
{
    private List<Tramite> Tramites { get; set; }
    private int ProximoId { get; set; } = 1;
    private string DireccionTXT { get; set; }

    public RepositorioTramiteTXT(string direccionTXT)
    {
        DireccionTXT = direccionTXT;        
        Tramites = CargarTramites();
    }

    private List<Tramite> CargarTramites()
    {
        List<Tramite> tramites = new List<Tramite>();
        var lineasArchivo = File.ReadAllLines(DireccionTXT); 
        foreach (var linea in lineasArchivo)
        {
            string[] atributos = linea.Split(',');
            Tramite tramite = new Tramite(atributos[3]);
            tramite.Id = int.Parse(atributos[0]);
            tramite.ExpedienteId = int.Parse(atributos[1]);
            tramite.Etiqueta = (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), atributos[2]);
            tramite.FechaHoraCreacion = DateTime.Parse(atributos[4]);
            tramite.FechaHoraUltimaModificacion = DateTime.Parse(atributos[5]);
            tramite.IdUsuarioUltimaModificacion = int.Parse(atributos[6]);
            tramites.Add(tramite);
        }
        return tramites;
    }

    public void Agregar(Tramite tramite)
    {
        tramite.Id = ProximoId++;
        Tramites.Add(tramite);
        GuardarTramite(tramite);
    }

    private void GuardarTramite(Tramite tramite)
    {
        using (StreamWriter sw = File.AppendText(DireccionTXT)){
            sw.WriteLine($"{tramite.Id},{tramite.ExpedienteId},{tramite.Etiqueta},{tramite.Contenido},{tramite.FechaHoraCreacion},{tramite.FechaHoraUltimaModificacion},{tramite.IdUsuarioUltimaModificacion}");
        }
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
            lineas[indice] = $"{tramite.Id},{tramite.ExpedienteId},{tramite.Etiqueta},{tramite.Contenido},{tramite.FechaHoraCreacion},{tramite.FechaHoraUltimaModificacion},{tramite.IdUsuarioUltimaModificacion}";
            File.WriteAllLines(DireccionTXT, lineas);
        }
        {
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

    public Tramite ConsultarPorId(int id){
        foreach(Tramite tramite in Tramites){
            if(tramite.Id == id){
                return tramite;
            }
        }
        {
            throw new RepositorioException($"No existe trámite que tenga el id #{id}");
        }    
    }

    public List<Tramite> ConsultarPorExpediente(int expedienteID){
        List<Tramite> tramitesDelExpedienteID = new List<Tramite>();
        foreach(Tramite tramite in Tramites){
            if(tramite.ExpedienteId == expedienteID){
                tramitesDelExpedienteID.Add(tramite);
            }
        }
        if(tramitesDelExpedienteID != null){
            return tramitesDelExpedienteID;
        }
        {
            throw new RepositorioException($"No existen trámites asociados al expediente con id #{expedienteID}");
        } 
    }
}
