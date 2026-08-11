using DevelopersHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevelopersHub.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<Usuario> _signInManager;

        public LogoutModel(SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if(returnUrl != null)
            {
                return LocalRedirect(returnUrl);

            }
            return RedirectToPage("/Index");
        }

    }
}
