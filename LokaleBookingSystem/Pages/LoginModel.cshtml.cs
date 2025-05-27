using LokaleBookingSystem.Models;
using LokaleBookingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace LokaleBookingSystem.Pages
{
    public class LoginModel : PageModel
    {
        private IBrugerService _repo;
        public LoginModel(IBrugerService repo)
        {
            _repo = repo;
        }

        public List<Bruger> Bruger { get; set; }

        public void OnGet()
        {
            Bruger = _repo.GetAll();
        }

        [BindProperty]
        public string Brugernavn { get; set; }

        [BindProperty]
        public string Adgangskode { get; set; } // Now a string!  

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            var bruger = _repo.Login(Brugernavn, Adgangskode);

            if (bruger != null)
            {
                // Login successful – redirect to user's page  
                return RedirectToPage("MinSideModel");
            }
            else
            {
                // Login failed  
                ErrorMessage = "Forkert brugernavn eller adgangskode";
                return Page();
            }
        }
    }
    //public class LoginModel : PageModel
    //{

    //    private IBrugerService _repo;
    //    public LoginModel(IBrugerService repo)
    //    {
    //        _repo = repo;
    //    }

    //    public List<Bruger> Bruger { get; set; }

    //    public void OnGet()
    //    {
    //        //Lokaler = new List<Lokale>
    //        //{
    //        //    new Lokale(1, "Lokale A", "Undervisning", "30 personer", "Projektor, Smartboard", true, true, 5),
    //        //    new Lokale(2, "Lokale B", "Mødelokale", "12 personer", "Skærm, Mødebord", true, false, 3)
    //        //};

    //        Bruger = _repo.GetAll();
    //    }
    //    [BindProperty]
    //    public string Brugernavn { get; set; }

    //    [BindProperty]
    //    public string Adgangskode { get; set; } // Holder adgangskode som int

    //    public string ErrorMessage { get; set; }
    //    public IActionResult OnPost()
    //    {
    //        // Kalder Login-metoden fra IBrugerService
    //        var bruger = _repo.Login(Brugernavn, Adgangskode);

    //        if (bruger != null)
    //        {
    //            // Login succesfuld – redirect til brugerens side
    //            return RedirectToPage("/MinSide");
    //        }
    //        else
    //        {
    //            // Login fejlede
    //            ErrorMessage = "Forkert brugernavn eller adgangskode";
    //            return Page();
    //        }
    //    }
    //public LoginModel(IBrugerService brugerService)
    //{
    //    _brugerService = brugerService;
    //}

    //public void OnGet()
    //{
    //}

    //public IActionResult OnPost()
    //{
    //    var bruger = _brugerService.Login(Brugernavn, Adgangskode);

    //    if (bruger != null)
    //    {
    //        // Gem brugerdata i session
    //        HttpContext.Session.SetString("BrugerId", bruger.Id);
    //        HttpContext.Session.SetString("Brugernavn", bruger.Brugernavn);
    //        HttpContext.Session.SetString("Rolle", bruger.Rolle.ToString());
    //        HttpContext.Session.SetString("GruppeId", bruger.GruppeId);

    //        return RedirectToPage("/MinSide");
    //    }
    //    else
    //    {
    //        ErrorMessage = "Forkert brugernavn eller adgangskode";
    //        return Page();
    //    }
    //}
}



        
   
//        public IActionResult OnPost()
//        {
//            //Sammenligner adgangskode som int (husk at ændre koden til et tal)
//            if (Brugernavn == "Malyun" && Adgangskode == 1234) // Brug int i stedet for string
//            {

//                return RedirectToPage("/MinSide");
//            }
//            else
//            {
//                ErrorMessage = "Forkert Brugernavn eller adgangskode";
//                return Page();
//            }
//        }
//    }

//}
    