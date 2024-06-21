namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioConsultarPorId(IUsuarioRepositorio repoUsuario)
{
    public Usuario Ejecutar(int usuarioId)
    {
        Usuario usuario = repoUsuario.ConsultarPorID(usuarioId);
        return usuario;
    }
}
