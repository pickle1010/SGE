namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void Agregar(Tramite tramite);
    void Eliminar(int id);
    void Modificar(Tramite tramite);
    List<Tramite> ConsultarPorEtiqueta(EtiquetaTramite etiqueta);
    List<Expediente> ConsultaPorExpediente(int ExpedienteID);
}
