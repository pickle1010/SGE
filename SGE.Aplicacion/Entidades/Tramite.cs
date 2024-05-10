namespace SGE.Aplicacion;

public class Tramite
{
    public int Id { get; }
    public int ExpedienteId { get; }
    public EtiquetaTramite Etiqueta { get; set; }
    public string? Contenido { get; set; }
    public DateTime FechaHoraCreacion { get; }
    public DateTime FechaHoraUltimaModificacion { get; set; }
    public int IdUsuarioUltimaModificacion { get; set; }

    public Tramite()
    {

    }
}
