using Microsoft.EntityFrameworkCore;
using Prueba3Parcial.Modelo;
public class ApplicationDBContext : DbContext
{
    public DbSet<Clientes> clientes { get; set; }
    public DbSet<Vehiculo> vehiculos { get; set; }
    public DbSet<TareaMantenimiento> tareaMantenimientos { get; set; }


    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Clientes>()
                .OwnsOne(c => c.Ubicacion);
    }
}
