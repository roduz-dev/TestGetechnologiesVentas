using Microsoft.EntityFrameworkCore;
using ServicioRest.Models;

namespace ServicioRest.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :   base(options)
        {
            
        }
    }
}
