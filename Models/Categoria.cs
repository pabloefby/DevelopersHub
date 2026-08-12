using System.ComponentModel.DataAnnotations;

namespace DevelopersHub.Models
{
    public class Categoria
    {
        public int Id {get; set;} 

        [Required]
        [StringLength(50)]
        public string Nombre {get; set;} = string.Empty;
        
        [StringLength(255)]
        public string Descripcion { get; set; } = string.Empty;
        
        [StringLength(7)]
        public string ColorHexa {get; set;} = "#000000";

        // Relación 1 a N
        public List<Publicacion> Publicaciones { get; set; } = new();
    }
}