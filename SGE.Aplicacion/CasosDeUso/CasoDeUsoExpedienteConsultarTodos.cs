namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultarTodos(IExpedienteRepositorio repo)
{
    public List<Expediente> Ejecutar()
    {   
        return repo.ConsultarTodos();
    }
}
