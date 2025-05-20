
using LokaleBookingSystem.Models;

namespace LokaleBookingSystem.Services
{
    public interface IBookingService
    {
        List<Booking> GetAlleBookinger();
        List<Lokale> GetAlleLokaler();
        List<Booking> GetBookingerForLokale(int lokaleId);
        bool KanBookes(Lokale lokale, DateTime startTid);
        Booking OpretBooking(Bruger bruger, int lokaleId, DateTime startTid, bool smartboard);
        bool AflysBooking(Bruger bruger, int bookingId);
    }
}
