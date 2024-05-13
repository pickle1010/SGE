namespace SGE.Aplicacion;

public class EspecificacionCambioEstado : IEspecificacionCambioEstado
{
    public void CambiarEstado(Expediente expediente, EtiquetaTramite etiqueta)
    {
        switch (etiqueta)
        {
            case EtiquetaTramite.Resolucion: 
                expediente.Estado = EstadoExpediente.ConResolucion;
                break;
            case EtiquetaTramite.PaseAEstudio: 
                expediente.Estado = EstadoExpediente.ParaResolver;
                break;
            case EtiquetaTramite.PaseAlArchivo: 
                expediente.Estado = EstadoExpediente.Finalizado;
                break;
            default:
                break;
        }
    }

}
