namespace SGE.Repositorios;

using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using SGE.Aplicacion;


public class RepositorioUsuario : IUsuarioRepositorio
{

    public void Agregar(Usuario usuario)
    {
        using var context = new SGEContext();
        if(context.Usuarios.Where(u => u.Email == usuario.Email).SingleOrDefault() != null)
        {
            throw new RepositorioException($"Ya existe un usuario con el email #{usuario.Email}");
        }
        context.Add(usuario);
        context.SaveChanges();
    }

    public Usuario ConsultarPorEmail(string email)
    {
        using var context = new SGEContext();
        var usuario = context.Usuarios.Where(u => u.Email == email).SingleOrDefault();
        if(usuario == null){
            throw new RepositorioException($"No existe usuario que tenga el email #{email}");
        }
        return usuario;
    }

    public Usuario ConsultarPorID(int id){
        using var context = new SGEContext();
        var usuario = context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
        if(usuario == null){
            throw new RepositorioException($"No existe usuario que tenga el id #{id}");
        }
        return usuario;
    }

    public List<Usuario> ConsultarTodos(){
        using var context = new SGEContext();
        return context.Usuarios.ToList();
    }

    public Usuario Eliminar(int id) 
    {
        using var context = new SGEContext();
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
        using var context = new SGEContext();
        var usuarioExistente = context.Usuarios.Where(u => u.Id == usuario.Id).SingleOrDefault();
        if(usuarioExistente == null){
            throw new RepositorioException($"No existe usuario que tenga el id #{usuario.Id}");
        }
        if(usuario.Email != usuarioExistente.Email)
        {
            if(context.Usuarios.Where(u => u.Email == usuario.Email).SingleOrDefault() != null)
            {
                throw new RepositorioException($"Ya existe un usuario con el email #{usuario.Email}");
            }
        }
        usuario.Id = usuarioExistente.Id;
        usuarioExistente.Nombre = usuario.Nombre;
        usuarioExistente.Apellido = usuario.Apellido;
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.Contraseña = usuario.Contraseña;
        context.SaveChanges();
    }
    
}