using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LokaleBookingSystem.Pages
{
    public class BooklokaleModel : PageModel
    {
        
        // Du kan definere dine egenskaber her, som du vil vise i Razor Page
        public string LokaleNavn { get; set; }
        public string StartTid { get; set; }

        // Dette er OnGet-metoden, som h�ndterer HTTP GET-anmodninger
        public void OnGet()
        {
            // Du kan f.eks. hente data her, som skal vises i Razor Page
            LokaleNavn = "M�delokale A";
            StartTid = "12:00 PM";
        }

        // Hvis du ogs� �nsker at h�ndtere POST-anmodninger (som ved en formindsendelse), kan du definere OnPost-metoden
        public void OnPost()
        {
            // Logik for h�ndtering af POST-data, hvis det er n�dvendigt
        }
    }
        
    }

