using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;
namespace SGE.Repositorios;

public class SGEContext : DbContext
{
    #nullable disable
    public DbSet<Expediente> Expedientes { get; set; }
    public DbSet<Tramite> Tramites { get; set; } 
    public DbSet<Usuario> Usuarios { get; set; }
#nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=SGE.sqlite");
    }
}
