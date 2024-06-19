namespace SGE.Repositorios;

using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using SGE.Aplicacion;

public class RepositorioExpediente : IExpendienteRepositorio
{
    private int ProximoId { get; set; } = 1;
    private SGEContext context;

    public RepositorioExpediente(SGEContext context)
    {
         this.context = context;
    }


    // El método FormatExpediente nos seguiría sirviendo para algo? 

    // private string FormatExpediente(Expediente expediente)
    // {
    //     return $"{expediente.Id},{expediente.Caratula},{expediente.Estado},{expediente.FechaHoraCreacion},{expediente.FechaHoraUltimaModificacion},{expediente.IdUsuarioUltimaModificacion}";
    // }

    public void Agregar(Expediente expediente)
    {
        context.Add(expediente);
        context.SaveChanges();
    }

    public Expediente ConsultarPorID(int id){
        var expediente = context.Expedientes.Where(e => e.Id == id).SingleOrDefault();
        if(expediente == null){
            throw new RepositorioException($"No existe expediente que tenga el id #{id}");
        }
        return expediente;
    }

    public List<Expediente> ConsultarTodos(){
        return context.Expedientes.ToList();
    }

    public Expediente Eliminar(int id) 
    {
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
        var expedienteExistente = context.Expedientes.Where(e => e.Id == expediente.Id).SingleOrDefault();
        if(expedienteExistente == null){
            throw new RepositorioException($"No existe expediente que tenga el id #{expediente.Id}");
        }
        expedienteExistente.Caratula = expediente.Caratula;
        expedienteExistente.Estado = expediente.Estado;
        context.SaveChanges();
    }
}
