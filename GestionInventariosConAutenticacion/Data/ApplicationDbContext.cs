using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionInventariosConAutenticacion.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestionInventariosConAutenticacion.Models.Categoría> Categoría { get; set; } = default!;
        public DbSet<GestionInventariosConAutenticacion.Models.Producto> Producto { get; set; } = default!;
    }
}
