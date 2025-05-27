using LokaleBookingSystem.Models;
using Microsoft.Data.SqlClient;

namespace LokaleBookingSystemHej.Services
{
    public class LokaleRepo : ILokaleRepo
    {
        protected string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "(localdb)\\MSSQLLocalDB";
                builder.InitialCatalog = "LokaleBookingDB";

                return builder.ConnectionString;
            }
        }

        public List<Lokale> GetAll()
        {
            List<Lokale> data = new List<Lokale>();
            string queryStr = $"SELECT * FROM Lokale";

            // Etablér DB-forbindelse (med brug af using-syntaksen)
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            // 2) Definér og udfør SQL-statement
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            // 3) Processér de læste data
            while (reader.Read())
            {
                data.Add(GetRow(reader));
            }

            return data;
        }
     
            private Lokale GetRow(SqlDataReader reader)
        {
            int lokaleId = reader.GetInt32(reader.GetOrdinal("ID"));
            string navn = reader.GetString(reader.GetOrdinal("Navn"));
            string type = reader.GetString(reader.GetOrdinal("Type"));
            string kapacitet = reader.GetString(reader.GetOrdinal("Kapacitet"));
            string udstyr = reader.GetString(reader.GetOrdinal("Udstyr"));
            bool tilgænglighed = reader.GetBoolean(reader.GetOrdinal("Tilgængelighed"));
            bool harSmartboard = reader.GetBoolean(reader.GetOrdinal("HarSmartboard"));
            int maksBookinger = reader.GetInt32(reader.GetOrdinal("Maksbookinger"));

            return new Lokale(lokaleId, navn, type, kapacitet, udstyr, tilgænglighed, harSmartboard, maksBookinger);

        }
    }
}



