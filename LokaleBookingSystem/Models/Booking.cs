namespace LokaleBookingSystem.Models
{
    //Properties
    public class Booking
    {
        public int Id { get; set; }
        public string Brugernavn { get; set; }
        public Lokale lokale { get; set; } 
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public string GruppeId { get; set; }
        public bool HarSmartboard { get; set; }

        //Constructor
            public Booking(int id, string brugernavn, Lokale lokale, DateTime startTid, int varighedTimer, bool smartboard)
        {
            Id = id;
            Brugernavn = brugernavn;
            lokale = lokale;
            StartTid = startTid;
            SlutTid = startTid.AddHours(varighedTimer);
            HarSmartboard = smartboard;
            
        }

     
   
    /// Tjekker om denne booking overlapper med en anden booking
  
    public bool OverlapperMed(Booking andenBooking)
        {
            return StartTid < andenBooking.SlutTid && SlutTid > andenBooking.StartTid;
        }
    }
}