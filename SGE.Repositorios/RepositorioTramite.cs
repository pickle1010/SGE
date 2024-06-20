using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioTramite : ITramiteRepositorio
{
    private SGEContext context; 
    public RepositorioTramite(SGEContext context)
    {
        this.context = context;
    } 

    public void Agregar(Tramite tramite)
    {
        context.Add(tramite);
        context.SaveChanges();
    }

    public Tramite Eliminar(int id)
    {
        var tramite = context.Tramites.Where(t => t.Id == id).SingleOrDefault();
        if (tramite == null){
            throw new RepositorioException($"No existe trámite que tenga el id #{id}");
        }
        context.Remove(tramite);
        context.SaveChanges();
        return tramite;
    }

    public void Modificar(Tramite tramite)
    {
        var tramiteExistente = context.Tramites.Where(t => t.Id == tramite.Id).SingleOrDefault();
        if(tramiteExistente == null){
            throw new RepositorioException($"No existe trámite que tenga el id #{tramite.Id}");
        }
        tramiteExistente.Etiqueta = tramite.Etiqueta;
        tramiteExistente.Contenido = tramite.Contenido;
        tramiteExistente.FechaHoraUltimaModificacion = tramite.FechaHoraUltimaModificacion;
        tramiteExistente.IdUsuarioUltimaModificacion = tramite.IdUsuarioUltimaModificacion;
        context.SaveChanges();
    } 

    public List<Tramite> ConsultarPorEtiqueta(EtiquetaTramite etiqueta)
    {
        return context.Tramites.Where(t => t.Etiqueta == etiqueta).ToList();
    }

    public Tramite ConsultarPorId(int id){
        var tramite = context.Tramites.Where(t => t.Id == id).SingleOrDefault();
        if(tramite == null){
            throw new RepositorioException($"No existe trámite que tenga el id #{id}");
        }
        return tramite;
    }

    public List<Tramite> ConsultarPorExpediente(int expedienteID){
        var tramites = context.Tramites.Where(t => t.ExpedienteId == expedienteID).ToList();
        if(tramites == null){
            throw new RepositorioException($"No existen trámites asociados al expediente con id #{expedienteID}");
        }
        return tramites;
    }

    public void EliminarPorExpediente(int expedienteID){
        var expediente = context.Expedientes.Where(e => e.Id == expedienteID).SingleOrDefault();
        if(expediente == null){
            throw new RepositorioException($"No existe expediente que tenga el id #{expedienteID}");
        }
        
        var tramites = context.Tramites.Where(t => t.ExpedienteId == expedienteID).ToList();
        if(tramites == null){
            throw new RepositorioException($"No existen trámites asociados al expediente con id #{expedienteID}");
        }

        context.Remove(tramites);
        context.SaveChanges();
    }
}
