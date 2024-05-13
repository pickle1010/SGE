namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar(EtiquetaTramite etiqueta){
        List<Tramite> tramites = repo.ConsultarPorEtiqueta(etiqueta);     
        return tramites;
    }
}
