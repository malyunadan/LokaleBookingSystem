namespace LokaleBookingSystem.Models
{
 
    public class Lokale
    {
        public int LokaleId { get; set; }
        public int Id => LokaleId;
        public string Navn { get; set; }
        public string Type { get; set; }
        public string Kapacitet { get; set; }
        public string Udstyr { get; set; }
        public bool Tilgænglighed { get; set; }
        public bool HarSmartboard { get; set; }
        public int MaksBookinger { get; set; }


        public Lokale(int lokaleId, string navn, string type, string kapacitet, string udstyr, bool tilgænglighed, bool harSmartboard, int maksBookinger)
        {
            LokaleId = lokaleId;
            Navn = navn;
            Type = type;
            Kapacitet = kapacitet;
            Udstyr = udstyr;
            Tilgænglighed = tilgænglighed;
            HarSmartboard = harSmartboard;
            MaksBookinger = maksBookinger;
        }
    
    
    public bool ErLokaletTilgængeligt()
        {
            return Tilgænglighed;
        }

    }
}