
using System.Collections.Generic;
using LokaleBookingSystem.Models;

namespace LokaleBookingSystem.Services
{

    public interface IBookingRegler
    {
        bool LokaleHarPlads(List<Booking> eksisterendeBookinger);
        bool GruppeHarIkkeFlereAktiveBookinger(string gruppeId, List<Booking> alleBookinger);
        bool ErGyldigAnnulleringUnderviser(DateTime startTidspunkt);
        bool ErGyldigAnnulleringStuderende(DateTime startTidspunkt);
        bool ErLokaleLedigt(List<Booking> eksisterendeBookinger, DateTime ønsketStart, DateTime ønsketSlut);
        string HentSmartboardBekræftelse(Lokale lokale);
    }
}

    

