namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioConsultarTodos(IUsuarioRepositorio repo, IServicioAutorizacion servicioAutorizacion)
{
    public List<Usuario> Ejecutar()
    {   
        return repo.ConsultarTodos();
    }
}
