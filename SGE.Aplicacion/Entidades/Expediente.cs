using System.ComponentModel;

namespace SGE.Aplicacion;

public class Expediente
{
    // Preguntar sobre ID Expediente
    public int Id { get; }
    public string? Caratula { get; set; }
    public DateTime FechaCreacion { get; }
    public DateTime FechaUltimaModificacion { get; set; }
    public int UltimaModificacionUserId { get; set; }
    public EstadoExpediente Estado { get; set; }
    
    public Expediente()
    {

    }
}