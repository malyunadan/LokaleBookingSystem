 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace LokaleBookingSystem.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Brugernavn { get; set; }

        [BindProperty]
        public int Adgangskode { get; set; } // Holder adgangskode som int

        public string ErrorMessage { get; set; }

        //public IActionResult OnGet()
        //{ }

        public IActionResult OnPost()
        {
            //Sammenligner adgangskode som int (husk at ændre koden til et tal)
            if (Brugernavn == "Malyun" && Adgangskode == 1234) // Brug int i stedet for string
            {
               
                return RedirectToPage("/MinSide");
            }
            else
              {
                   ErrorMessage = "Forkert Brugernavn eller adgangskode";
                   return Page();
              }
            }

        }
    }