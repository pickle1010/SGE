namespace SGE.Aplicacion;

public interface IUsuarioRepositorio
{
    void Agregar(Usuario usuario);
    Usuario Eliminar(int id);
    void Modificar(Usuario usuario);
    List<Usuario> ConsultarTodos();
}
