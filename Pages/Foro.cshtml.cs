using DevelopersHub.Models;
using DevelopersHub.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Claims;

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

        public List<Publicacion> Publicaciones {get; set;} = new ();

        [BindProperty]
        public InputModel Input {get; set;} = new();
        public class InputModel
        {
            public string Titulo {get; set;} = string.Empty;
            public string Contenido {get; set;} = string.Empty;
        }

        private async Task CargarPublicacionesAsync()
        {
            Publicaciones = await _context.Publicaciones
            .Include(p => p.Usuario)
            .OrderByDescending(p => p.FechaCreacion)
            .ToListAsync();
        }
        public async Task OnGetAsync()
        {
            await CargarPublicacionesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
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
                FechaCreacion = DateTime.UtcNow,
                UsuarioId = userId
            };

            _context.Publicaciones.Add(nuevaPublicacion);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

    }
}
