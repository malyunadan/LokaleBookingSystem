using LokaleBookingSystem.Models;

namespace LokaleBookingSystem.Services
{
    public interface IBrugerService
    {
       Bruger Login(string brugernavn, String adgangskode);
    
      List<Bruger> GetAll();
    }
}



