namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultarTodos(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar()
    {   
        return repo.ConsultarTodos();
    }
}
