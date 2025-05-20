namespace LokaleBookingSystemHej.Services
{
    // Generisk repository interface for CRUD-operationer
    public interface Irepo<T> where T : class
    {
        // Hent alle objekter
        IEnumerable<T> GetAll();

        // Hent ét objekt på ID
        T? GetById(int id);

        // Tilføj et nyt objekt
        void Add(T entity);

        // Opdater et eksisterende objekt
        void Update(T entity);

        // Slet et objekt på ID
        void Delete(int id);
    }
}
