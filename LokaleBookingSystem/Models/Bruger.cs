namespace LokaleBookingSystem.Models
{
    // Enum til at angive brugerens rolle i systemet.
    // Anvendes f.eks. til at styre rettigheder og adgang.
    public enum Rolle
    {
        Admin = 1,
        Elev = 2,
        Lærer = 3,
    }
    public class Bruger 
    {
        public string Id { get; set; }
        public string Brugernavn { get; set; } 
        public int Adgangskode { get; set; }
        public Rolle Rolle { get; set; }
        public string GruppeId { get; set; }

        public Bruger() { }

        public Bruger(string brugernavn, string id, int adgangskode, Rolle rolle, string gruppeId)
        {
            Brugernavn = brugernavn;
            Id = id;
            Adgangskode = adgangskode;
            Rolle = rolle;
            GruppeId = gruppeId;
        }


        public string HentBrugerInfo()
        {
            return $"Navn: {Brugernavn}, Id: {Id}, Adgangskode: {Adgangskode}, Rolle: {Rolle}";
        }

        public bool ErAdmin()
        {
            return Rolle == Rolle.Admin;
        }

        public bool ErElev()
        {
            return Rolle == Rolle.Elev;
        }

        public bool ErLaerer()
        {
            return Rolle == Rolle.Lærer;
        }
    }

     
}


