using LokaleBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LokaleBookingSystem.Services
{
    public class BookingService : IBookingService
    {
      
        private List<Lokale> _lokaler; // liste af alle lokaler
        private List<Booking> _bookinger;// liste af alle bookings
        private int _nextBookingId = 1; // til at give nye bookinger et unik ID.

        //Constructor
        //Modtager en liste med lokaler som input.
        //Initialiserer listen over bookinger som tom.
        // LAVE EN REFFERENCE TIL LOKALE REPO - ROSBIL - USER 
        public BookingService()
        {
            _bookinger = new List<Booking>();
        }
        //metoder

        public List<Booking> GetAlleBookinger() => _bookinger;
        // returner alle bookinger i systemet

        public List<Lokale> GetAlleLokaler() => _lokaler;
        // returner alle lokaler, der kan bookes

        public List<Booking> GetBookingerForLokale(int LokaleId)
        {
            return _bookinger.Where(b => b.lokale.Id == LokaleId).ToList();
        }
        //Finder alle bookinger for ét bestemt lokale ved hjælp af dets ID.
        //her bruges LINQ - IEnumerable som filtere et sæt af værdier udfra en paramenter.
        public bool KanBookes(Lokale lokale, DateTime startTid)
        {
            int eksisterende = _bookinger.Count(b =>
                b.lokale.LokaleId == lokale.LokaleId &&
                b.StartTid == startTid);

            return eksisterende < lokale.MaksBookinger;
        }
        
        //Tjekker, om et lokale kan bookes på et bestemt tidspunkt.
        // Finder antallet af eksisterende bookinger med samme lokale og tidspunkt.
        // Hvis der er færre bookinger end det maks. tilladte, returnerer den true.

        public Booking OpretBooking(Bruger bruger, int lokaleId, DateTime startTid, bool smartboard)
       // Bruger bruger: den person der laver bookingen.
      //int lokaleId: ID’et på det lokale der ønskes booket.
      // DateTime startTid: tidspunktet for bookingen.
      // bool smartboard: om der ønskes smartboard.

        {
            Lokale lokale = _lokaler.FirstOrDefault(l => lokaleId == lokaleId);
            //Søger i listen _lokaler efter et lokale med det ønskede ID.
            if (lokale == null) throw new Exception("Lokalet findes ikke.");
            //Hvis lokalet ikke findes, kastes en undtagelse.

            if (!KanBookes(lokale, startTid))
                throw new Exception("Lokalet er allerede booket til dette tidspunkt.");
             //Metoden KanBookes bruges til at se, om lokalet er ledigt på det ønskede tidspunkt.

            // Automatisk tilføj smartboard til mødelokaler
            //if (lokale.Type == Lokaler.MoedeLokale)
                smartboard = true;
            //Hvis lokalet er et mødelokale, sættes smartboard automatisk  til true – uanset hvad brugeren bad om.

            var booking = new Booking(_nextBookingId++, bruger.Brugernavn, lokale, startTid, 2, smartboard);
            _bookinger.Add(booking);
            //En ny booking oprettes med:
            // Et unikt booking-ID (_nextBookingId++)
            // Brugerens navn
            // Lokalet
            // Starttidspunktet
            // En varighed på 2 timer (hardcoded)
            // Om der skal være smartboard
            return booking;
            //Bookingen gemmes i systemet og returneres.
        }

        public bool AflysBooking(Bruger bruger, int bookingId)
        {
            var booking = _bookinger.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null)
                throw new Exception("Booking ikke fundet.");

            bool erEjer = booking.Brugernavn == bruger.Brugernavn;
            bool underviser = bruger.Rolle == Rolle.Lærer;
            TimeSpan tidTilStart = booking.StartTid - DateTime.Now;

            if (!underviser && !erEjer )
                throw new Exception("Du har ikke tilladelse til at aflyse denne booking.");
                //kun ejer af booking eller underviser kan aflyse 
            
            if (tidTilStart.TotalDays < 3)
                throw new Exception("Booking kan kun aflyses 3 dage før.");
            

            _bookinger.Remove(booking);
            return true;
        }
    
    }

}
