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

        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Career Path", Descripcion = "Dudas y tips sobre cómo llevar tu carrera", ColorHexa="#019fce"},
                new Categoria { Id = 2, Nombre = "Back-end", Descripcion = "Desarrollo del lado del servidor, APIs y lógica de negocio", ColorHexa="#01aca6" },
                new Categoria { Id = 3, Nombre = "Front-end", Descripcion = "Diseño de interfaces, componentes y experiencia de usuario" , ColorHexa="#7fb539"},
                new Categoria { Id = 4, Nombre = "Bases de datos", Descripcion = "Consultas, modelado SQL, NoSQL y optimización" , ColorHexa="#ffd401"}, 
                new Categoria { Id = 5, Nombre = "DevOps & Cloud", Descripcion = "Despliegues, CI/CD, Docker, Linux y proveedores en la nube" , ColorHexa="#fa9d1c"},
                new Categoria { Id = 6, Nombre = "Ciberseguridad", Descripcion = "Buenas prácticas de seguridad, autenticación, JWT y protección de APIs", ColorHexa="#c61935" },
                new Categoria { Id = 7, Nombre = "Showcase / Proyectos", Descripcion = "Muestra tus proyectos personales y recibe feedback de la comunidad" , ColorHexa="#f598aa"},
                new Categoria { Id = 8, Nombre = "Off-Topic", Descripcion = "Charlas casuales, tecnología en general, setups y comunidad", ColorHexa="#6950a1" }
            );
        }

    }
}