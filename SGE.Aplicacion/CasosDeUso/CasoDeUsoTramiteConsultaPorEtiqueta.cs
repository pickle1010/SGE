namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar(EtiquetaTramite etiqueta){
        List<Tramite> tramites = repo.ConsultarPorEtiqueta(etiqueta);     
        if(tramites == null){
            throw new RepositorioException($"No existen trámites con la etiqueta ingresada");
        }
        return tramites;
    }
}
