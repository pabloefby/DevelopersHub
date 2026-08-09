using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DevelopersHub.Data;
using DevelopersHub.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DevelopersHub.Pages;

public class RegistroModel : PageModel
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;

    public RegistroModel(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [BindProperty]
    public InputModel Input {get; set;} = new();

    public class InputModel
    {
        [Required(ErrorMessage = "El usuario es obligatorio.")]
            public string Username { get; set; } = string.Empty;

            [Required(ErrorMessage = "El correo es obligatorio.")]
            [EmailAddress(ErrorMessage = "Formato de correo no válido.")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "La contraseña es obligatoria.")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
    }
    
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            {
                return Page();
            }

            var usuario = new Usuario 
            { 
                UserName = Input.Username, 
                Email = Input.Email 
            };

            // UserManager crea el usuario y encripta la contraseña
            var result = await _userManager.CreateAsync(usuario, Input.Password);

            if (result.Succeeded)
            {
                // Inicia sesión automáticamente tras el registro
                await _signInManager.SignInAsync(usuario, isPersistent: false);
                return RedirectToPage("/Index");
            }

            // Si hay errores de validación por parte de Identity (ej. correo duplicado)
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
    }
}
