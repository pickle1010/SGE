namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorID(IExpendienteRepositorio repoExpediente, ITramiteRepositorio repoTramite)
{
    public Expediente Ejecutar(int expedienteId)
    {
        Expediente expediente = repoExpediente.ConsultarPorID(expedienteId) ?? throw new RepositorioException($"No existe expediente que tenga el id #{expedienteId}");
        expediente.Tramites = repoTramite.ConsultarPorExpediente(expedienteId);
        return expediente;
    }
}
