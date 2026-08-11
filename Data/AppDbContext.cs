using Microsoft.EntityFrameworkCore;
using DevelopersHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DevelopersHub.Data
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Publicacion>Publicaciones {get; set;}

    }
}