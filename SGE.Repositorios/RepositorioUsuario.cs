﻿namespace SGE.Repositorios;

using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using SGE.Aplicacion;


public class RepositorioUsuario : IUsuarioRepositorio
{

    public void Agregar(Usuario usuario)
    {
        using var context = new SGEContext();
        context.Add(usuario);
        context.SaveChanges();
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
        usuario.Id = usuarioExistente.Id;
        usuarioExistente.Nombre = usuario.Nombre;
        usuarioExistente.Apellido = usuario.Apellido;
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.Contraseña = usuario.Contraseña;
        context.SaveChanges();
    }

    
}