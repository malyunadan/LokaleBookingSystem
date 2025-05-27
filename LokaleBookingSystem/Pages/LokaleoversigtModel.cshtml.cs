using LokaleBookingSystem.Models;
using LokaleBookingSystemHej.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



    namespace LokaleBookingSystem.Pages
    {
        public class LokaleoversigtModel : PageModel
        {
        private ILokaleRepo _repo;
            public LokaleoversigtModel(ILokaleRepo repo)
        {
            _repo = repo;
        }

            public List<Lokale> Lokaler { get; set; }

            public void OnGet()
            {
                //Lokaler = new List<Lokale>
                //{
                //    new Lokale(1, "Lokale A", "Undervisning", "30 personer", "Projektor, Smartboard", true, true, 5),
                //    new Lokale(2, "Lokale B", "Mødelokale", "12 personer", "Skærm, Mødebord", true, false, 3)
                //};

            Lokaler = _repo.GetAll();
            }
        }
    }