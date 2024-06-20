namespace SGE.Aplicacion;

public class Tramite
{
    public int Id { get; set; }
    public int ExpedienteId { get; set; }
    public EtiquetaTramite Etiqueta { get; set; }
    public string Contenido { get; set; }
    public DateTime FechaHoraCreacion { get; set; }
    public DateTime FechaHoraUltimaModificacion { get; set; }
    public int IdUsuarioUltimaModificacion { get; set; }

    public Tramite (){

    }
    
    public Tramite(string contenido, int expedienteId) {
        Contenido = contenido;
        ExpedienteId = expedienteId;
    }

    public override string ToString()
    {
        return $"(Id:{Id}) Perteneciente al Expediente:{ExpedienteId}\nTipo:{Etiqueta}\nCreado:{FechaHoraCreacion}, Modificado por ultima vez:{FechaHoraUltimaModificacion} por Usuario #{IdUsuarioUltimaModificacion}\n{Contenido} ";
    }
}
