﻿namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpendienteRepositorio repoExpediente, ITramiteRepositorio repoTramite, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int expedienteId, int idUsuario)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja))
        {
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para realizar bajas de expedientes");
        }
        repoExpediente.Eliminar(expedienteId);
        foreach (Tramite tramite in repoTramite.ConsultarPorExpediente(expedienteId))
        {
            repoTramite.Eliminar(tramite.Id);
        }
    }
}
