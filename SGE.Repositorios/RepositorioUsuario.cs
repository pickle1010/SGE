namespace SGE.Repositorios;

using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using SGE.Aplicacion;


public class RepositorioUsuario
{
    private SGEContext context;

    public RepositorioUsuario(SGEContext context)
    {
        this.context = context;
    }

    public void Agregar(Usuario usuario)
    {
        context.Add(usuario);
        context.SaveChanges();
    }

    public Usuario ConsultarPorID(int id){
        var usuario = context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
        if(usuario == null){
            throw new RepositorioException($"No existe usuario que tenga el id #{id}");
        }
        return usuario;
    }

    public List<Usuario> ConsultarTodos(){
        return context.Usuarios.ToList();
    }

    public Usuario Eliminar(int id) 
    {
        var usuario = context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
        if(usuario == null){
            throw new RepositorioException($"No existe usuario que tenga el id #{id}");
        }
        context.Remove(usuario);
        context.SaveChanges();
        return usuario;  
    }

    public void Modificar(Usuario usuario)
    {
        var usuarioExistente = context.Usuarios.Where(u => u.Id == usuario.Id).SingleOrDefault();
        if(usuarioExistente == null){
            throw new RepositorioException($"No existe usuario que tenga el id #{usuario.Id}");
        }
        usuario.Id = usuarioExistente.Id;
        usuarioExistente = usuario;
        context.SaveChanges();
    }

    
}