namespace SGE.Aplicacion;

public class ServicioActualizacionEstado(IEspecificacionCambioEstado especificacion, IExpendienteRepositorio repoExpediente, ITramiteRepositorio repoTramite) : IServicioActualizacionEstado
{
    public void ActualizarEstado(int expedienteId)
    {
        List<Tramite> tramites = repoTramite.ConsultarPorExpediente(expedienteId);
        if(tramites.Count() > 0)
        {
            Tramite ultimoTramite = tramites[0];
            foreach (Tramite tramite in tramites)
            {
                if(tramite.FechaHoraUltimaModificacion > ultimoTramite.FechaHoraUltimaModificacion)
                {
                    ultimoTramite = tramite;
                }
            }
            Expediente expediente = repoExpediente.ConsultarPorID(expedienteId);
            especificacion.CambiarEstado(expediente, ultimoTramite.Etiqueta);
            repoExpediente.Modificar(expediente);
        }
    }
}
