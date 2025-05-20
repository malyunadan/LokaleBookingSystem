using LokaleBookingSystem.Models;

namespace LokaleBookingSystem.Services
{
    public interface IBrugerService
    {
        Bruger? Login(string brugernavn, int adgangskode);
    }
}
