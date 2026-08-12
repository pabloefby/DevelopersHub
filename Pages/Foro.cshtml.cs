using DevelopersHub.Models;
using DevelopersHub.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DevelopersHub.Pages
{
    [Authorize]
    public class ForoModel : PageModel
    {

        private readonly AppDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public ForoModel(AppDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Publicacion> Publicaciones { get; set; } = new();
        public List<Categoria> Categorias { get; set; } = default!;

        private async Task CargarPublicacionesAsync()
        {
            Publicaciones = await _context.Publicaciones
            .Include(p => p.Usuario)
            .Include(p => p.Categoria)
            .OrderByDescending(p => p.FechaCreacion)
            .ToListAsync();
        }
        private async Task CargarCategoriasPublicacionAsync()
        {
            Categorias = await _context.Categorias.ToListAsync();
        }


        public async Task OnGetAsync()
        {
            await CargarPublicacionesAsync();
            await CargarCategoriasPublicacionAsync();
        }


        [BindProperty]
        public InputModel Input { get; set; } = new();
        public class InputModel
        {
            [Required]
            public int CategoriaId { get; set; }
            public string Titulo { get; set; } = string.Empty;
            public string Contenido { get; set; } = string.Empty;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await CargarPublicacionesAsync();
                await CargarPublicacionesAsync();
                return Page();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToPage("/Login");
            }

            var nuevaPublicacion = new Publicacion
            {
                Titulo = Input.Titulo,
                Contenido = Input.Contenido,
                CategoriaId = Input.CategoriaId,
                FechaCreacion = DateTime.UtcNow,
                UsuarioId = userId
            };

            _context.Publicaciones.Add(nuevaPublicacion);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

    }
}
