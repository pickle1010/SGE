using System.ComponentModel;

namespace SGE.Aplicacion;

public class Expediente
{
    // Preguntar sobre ID Expediente
    public int Id { get; }
    public string? Caratula { get; set; }
    public DateTime FechaHoraCreacion { get; }
    public DateTime FechaHoraUltimaModificacion { get; set; }
    public int IdUsuarioUltimaModificacion { get; set; }
    public EstadoExpediente Estado { get; set; }

    public Expediente()
    {

    }
}