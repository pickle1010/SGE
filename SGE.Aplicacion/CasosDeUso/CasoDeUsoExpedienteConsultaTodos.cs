namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpendienteRepositorio repo)
{
    public List<Expediente> Ejecutar(Expediente expediente)
    {   
        List<Expediente> expedientes = repo.ConsultarTodos();
        if(expedientes == null){
            throw new RepositorioException($"No existen expedientes en el repositorio");
        }
        return expedientes;
    }
}
