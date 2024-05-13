namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, TramiteValidador validador, IServicioAutorizacion servicioAutorizacion, ServicioActualizacionEstado servicioActualizacion)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteAlta)){
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para realizar altas de Tramite");
        }
        if (!validador.Validar(tramite, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        tramite.FechaHoraUltimaModificacion = DateTime.Now;
        tramite.IdUsuarioUltimaModificacion = idUsuario;
        repo.Modificar(tramite);
        servicioActualizacion.ActualizarEstado(tramite.ExpedienteId); //IDEM ANTERIORES, aca está inyectado pero confunde cuando quiero invocarlo en Program 
    }
}

