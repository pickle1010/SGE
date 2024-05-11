namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorID(IExpendienteRepositorio repoExpediente, ITramiteRepositorio repoTramite)
{
    public Expediente Ejecutar(int expedienteId)
    {
        Expediente expediente = repoExpediente.ConsultarPorID(expedienteId);
        if(expediente == null){
            throw new RepositorioException($"No existe expediente que tenga el id #{expedienteId}");
        }
        expediente.Tramites = repoTramite.ConsultaPorExpediente(expedienteId);
        return expediente;
    }
}
