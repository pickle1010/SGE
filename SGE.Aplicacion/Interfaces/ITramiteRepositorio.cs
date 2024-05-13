namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void Agregar(Tramite tramite);
    Tramite Eliminar(int id);
    void Modificar(Tramite tramite);
    List<Tramite> ConsultarPorEtiqueta(EtiquetaTramite etiqueta);
    Tramite? ConsultarPorId(int tramiteID);
    List<Tramite> ConsultarPorExpediente(int expedienteID);
}
