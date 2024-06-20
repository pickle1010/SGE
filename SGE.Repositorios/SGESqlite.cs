namespace SGE.Repositorios;

using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;
public class SGESqlite 
{
    public static void Inicializar(){
        using var context = new SGEContext();
        if(context.Database.EnsureCreated()){
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand()){
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
            Console.WriteLine("La base de datos ha sido creada exitosamente");
        }
        else{
            Console.WriteLine("Error al crear la base de datos");
        }
    }
}
