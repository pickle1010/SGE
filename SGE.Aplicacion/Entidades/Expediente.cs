using System.ComponentModel;

namespace SGE.Aplicacion;

public class Expediente
{
    public int Id { get; set; }
    public string Caratula { get; set; }
    public EstadoExpediente Estado { get; set; }
    public List<Tramite>? Tramites { get; set; }
    public DateTime FechaHoraCreacion { get; set; }
    public DateTime FechaHoraUltimaModificacion { get; set; }
    public int IdUsuarioUltimaModificacion { get; set; }

    public Expediente(string caratula) {
        Caratula = caratula;
    }

    public override string ToString()
    {
        return $"(Id:{Id}) {Caratula}, Estado:{Estado}, Creado:{FechaHoraCreacion}, Modificado por ultima vez:{FechaHoraUltimaModificacion} por Usuario #{IdUsuarioUltimaModificacion}";
    }
}