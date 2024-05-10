namespace SGE.Aplicacion;

public class Tramite
{
    public int Id { get; }
    public int ExpedienteId { get; }
    public EtiquetaTramite Tipo { get; set; }
    public string? Contenido { get; set; }
    public DateTime FechaCreacion { get; }
    public DateTime FechaUltimaModificacion { get; set; }
    public int UltimaModificacionUserId { get; set; }

    public Tramite()
    {

    }
}
