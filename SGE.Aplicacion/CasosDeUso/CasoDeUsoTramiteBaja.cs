namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, TramiteValidador validador, IServicioAutorizacion servicioAutorizacion)
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
        repo.Eliminar(idUsuario);
    }
}
