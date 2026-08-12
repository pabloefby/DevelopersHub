using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace DevelopersHub.Models
{
    public class Publicacion
    {
        public int Id {get; set;}

        [Required]
        [StringLength(200)]
        public string Titulo {get; set;} = string.Empty;

        [Required]
        public string Contenido {get; set;} = string.Empty;

        public DateTime FechaCreacion {get; set;} = DateTime.UtcNow;

        public int CategoriaId { get; set; }
        public Categoria? Categoria {get;set;}

        public string UsuarioId {get;set;} = string.Empty;
        public Usuario? Usuario {get; set;}
        
    }
}