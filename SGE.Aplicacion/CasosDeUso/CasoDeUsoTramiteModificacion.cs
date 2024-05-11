namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, TramiteValidador validador, IServicioAutorizacion servicioAutorizacion)
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
        if(repo.ConsultarPorId(tramite.Id) == null){
            throw new RepositorioException($"No existe tramite que tenga el id #{tramite.Id}");
        }
        tramite.FechaHoraUltimaModificacion = DateTime.Now;
        tramite.IdUsuarioUltimaModificacion = idUsuario;
        repo.Modificar(tramite);
    }
}

