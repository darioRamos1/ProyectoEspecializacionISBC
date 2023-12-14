using Microsoft.EntityFrameworkCore;
using ProyectoEspecializacionISBC.Entidades;

namespace ProyectoEspecializacionISBC;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }
        public DbSet<TarjetaCredito> TarjetaCreditos { get; set; }
    }

