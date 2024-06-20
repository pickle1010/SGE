namespace SGE.Repositorios;

using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using SGE.Aplicacion;

public class RepositorioExpediente : IExpedienteRepositorio
{

    public void Agregar(Expediente expediente)
    {
        using var context = new SGEContext();
        context.Add(expediente);
        context.SaveChanges();
    }

    public Expediente ConsultarPorID(int id){
        using var context = new SGEContext();
        var expediente = context.Expedientes.Where(e => e.Id == id).SingleOrDefault();
        if(expediente == null){
            throw new RepositorioException($"No existe expediente que tenga el id #{id}");
        }
        return expediente;
    }

    public List<Expediente> ConsultarTodos(){
        using var context = new SGEContext();
        return context.Expedientes.ToList();
    }

    public Expediente Eliminar(int id) 
    {
        using var context = new SGEContext();
        var expediente = context.Expedientes.Where(e => e.Id == id).SingleOrDefault();
        if(expediente == null){
            throw new RepositorioException($"No existe expediente que tenga el id #{id}");
        }
        context.Remove(expediente);
        context.SaveChanges();
        return expediente;  
    }

    public void Modificar(Expediente expediente)
    {
        using var context = new SGEContext();
        var expedienteExistente = context.Expedientes.Where(e => e.Id == expediente.Id).SingleOrDefault();
        if(expedienteExistente == null){
            throw new RepositorioException($"No existe expediente que tenga el id #{expediente.Id}");
        }
        expedienteExistente.Caratula = expediente.Caratula;
        expedienteExistente.Estado = expediente.Estado;
        expedienteExistente.FechaHoraUltimaModificacion = expediente.FechaHoraUltimaModificacion;
        expedienteExistente.IdUsuarioUltimaModificacion = expediente.IdUsuarioUltimaModificacion;
        context.SaveChanges();
    }
}
