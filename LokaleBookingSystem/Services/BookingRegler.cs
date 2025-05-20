

using System;
using System.Collections.Generic;
using System.Linq;
using LokaleBookingSystem.Models;

namespace LokaleBookingSystem.Services
{

    public class BookingRegler : IBookingRegler
    {
     
        // reglen går ud på at der højest må være 2 aktive boookinger samtidig 
        public bool LokaleHarPlads(List<Booking> eksisterendeBookinger)

        {
            return eksisterendeBookinger.Count < 2;
        }
        // gruppen må kun have en aktiv booking ad gangen
        public bool GruppeHarIkkeFlereAktiveBookinger(string gruppeId, List<Booking> alleBookinger)
        {
            return !alleBookinger.Any(b => b.GruppeId == gruppeId && b.SlutTid > DateTime.Now);
        }

        // Undervisere må kun annullere med 3 dages varsel
        public bool ErGyldigAnnulleringUnderviser(DateTime startTidspunkt)
        {
            return (startTidspunkt - DateTime.Now).TotalDays >= 3;
        }
    
   
   // Studerende må kun annullere med 1 dags varsel
    public bool ErGyldigAnnulleringStuderende ( DateTime startTidspunkt )
    {
        return (startTidspunkt - DateTime.Now ) .TotalDays >= 1;
    }

        // lokalet skal være ledigt i det ønskede tidsrum
        public bool ErLokaleLedigt(List<Booking> eksisterendeBookinger, int lokaleId, DateTime ønsketStart, DateTime ønsketSlut)
        {
            return !eksisterendeBookinger.Any(b =>
                b.lokale.LokaleId == lokaleId &&
                b.StartTid < ønsketSlut &&
                b.SlutTid > ønsketStart);
        }


        // bekræft at smartboardet hører med i booking af lokalet 
        public string HentSmartboardBekræftelse (Lokale lokale)
    {
        return lokale.HarSmartboard ? "Smartboard er inkluderet i din booking." : ""  ;
       
     }

        public bool ErLokaleLedigt(List<Booking> eksisterendeBookinger, DateTime ønsketStart, DateTime ønsketSlut)
        {
            throw new NotImplementedException();
        }
    }

}









































