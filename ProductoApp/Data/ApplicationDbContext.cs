using Microsoft.EntityFrameworkCore;
using ProductoApp.Models;

namespace ProductoApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // Agrega tus DbSet aquí, por ejemplo:
        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Proveeder> Proveeders { get; set; }
    }
}
