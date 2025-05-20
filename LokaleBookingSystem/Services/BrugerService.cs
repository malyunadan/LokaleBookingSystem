using System;
using System.Collections.Generic;
using System.Linq;
using LokaleBookingSystem.Models;  // Husk at inkludere dit Models namespace

namespace LokaleBookingSystem.Services
{

    //skole mm
    // BrugerService klasse, der håndterer brugere og login
    public class BrugerService : IBrugerService
    {
        // Liste over brugere, som kan logge ind
        private List<Bruger> brugere = new List<Bruger>
        {
            // Opretter brugere med brugernavn, adgangskode og rolle
            new Bruger { Brugernavn = "Malyun", Adgangskode = 1234, Rolle = Rolle.Admin },
            new Bruger { Brugernavn = "Samira", Adgangskode = 5678, Rolle = Rolle.Lærer },
            new Bruger { Brugernavn = "Nasro", Adgangskode = 91011, Rolle = Rolle.Elev }
        };

        // Login-metode, der tjekker om brugernavn og adgangskode stemmer
        public Bruger? Login(string brugernavn, int adgangskode)
        {
            // Søger efter den første bruger, der matcher brugernavn og adgangskode
            return brugere.FirstOrDefault(b =>
                b.Brugernavn.Equals(brugernavn, StringComparison.OrdinalIgnoreCase) && b.Adgangskode == adgangskode);
        }
    }
}















