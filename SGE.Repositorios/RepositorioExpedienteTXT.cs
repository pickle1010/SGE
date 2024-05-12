﻿namespace SGE.Repositorios;

using System.Collections.Generic;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT : IExpendienteRepositorio
{
    private List<Expediente> Expedientes { get; set; }
    private int ProximoId { get; set; } = 1;
    private string DireccionTXT { get; set; }

    public RepositorioExpedienteTXT(string direccionTXT)
    {
        DireccionTXT = direccionTXT;        
        Expedientes = CargarExpedientes();
    }

    private List<Expediente> CargarExpedientes()
    {
        List<Expediente> expedientes = new List<Expediente>();
        using StreamReader sr = new StreamReader(DireccionTXT, true);
        while(!sr.EndOfStream)
        {
            string[]? atributos = sr.ReadLine()?.Split(',');
            if(atributos != null){
                Expediente expediente = new Expediente(atributos[1]);
                expediente.Id = int.Parse(atributos[0]);
                expediente.Estado = (EstadoExpediente) Enum.Parse(typeof(EstadoExpediente), atributos[2]);
                expediente.FechaHoraCreacion = DateTime.Parse(atributos[3]);
                expediente.FechaHoraUltimaModificacion = DateTime.Parse(atributos[4]);
                expediente.IdUsuarioUltimaModificacion = int.Parse(atributos[5]);
                expedientes.Add(expediente);
            }
        }
        return expedientes;
    }

    public void Agregar(Expediente expediente)
    {
        expediente.Id = ProximoId++;
        Expedientes.Add(expediente);
        GuardarExpediente(expediente);
    }

    public void GuardarExpediente(Expediente expediente)
    {
        using StreamWriter sw = new StreamWriter(DireccionTXT, true);
        sw.WriteLine($"{expediente.Id},{expediente.Caratula},{expediente.Estado},{expediente.FechaHoraCreacion},{expediente.FechaHoraUltimaModificacion},{expediente.IdUsuarioUltimaModificacion}");
    }
    
    public void SobreescribirArchivoExpedientes(List<Expediente> lista)
    {
        //Fijarse implementar uyn recorrido en el TXT para no sobreescribir todo.
        using StreamWriter sw = new StreamWriter(DireccionTXT, false); //el writer en false me sobreescribe el archivo
        foreach(Expediente expediente in lista)
        {
        sw.WriteLine($"{expediente.Id},{expediente.Caratula},{expediente.Estado},{expediente.FechaHoraCreacion},{expediente.FechaHoraUltimaModificacion},{expediente.IdUsuarioUltimaModificacion}");
        }
    }

    public Expediente? ConsultarPorID(int id)
    {
        foreach(Expediente expediente in Expedientes)
        {
            if (expediente.Id == id) return expediente;
        }
        return null;
    }

    public List<Expediente> ConsultarTodos() => Expedientes;

    public void Eliminar(int id) 
    {
        foreach(Expediente expediente in Expedientes)
        {
            if (expediente.Id == id)
            {
                Expedientes.Remove(expediente);
                SobreescribirArchivoExpedientes(Expedientes); //REVISAR
                break;
            }
        }
    }

    public void Modificar(Expediente expediente)
    {
    }
}
