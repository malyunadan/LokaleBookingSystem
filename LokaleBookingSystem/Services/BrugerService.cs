using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LokaleBookingSystem.Models;
using Microsoft.Data.SqlClient;  // Husk at inkludere dit Models namespace

namespace LokaleBookingSystem.Services
{

    public class BrugerService : IBrugerService
    {
        protected string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "(localdb)\\MSSQLLocalDB",
                    InitialCatalog = "LokalebookingDB"
                };
                return builder.ConnectionString;
            }
        }
        public List<Bruger> GetAll()
        {
            List<Bruger> data = new List<Bruger>();
            string queryStr = $"SELECT * FROM Bruger";

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

        //Login-metode: henter bruger fra DB hvis brugernavn + kode matcher


        public Bruger? Login(string brugernavn, string adgangskode)
        {
            List<Bruger> brugere = GetAll();
            return brugere.FirstOrDefault(b => b.Brugernavn == brugernavn && b.Adgangskode == adgangskode);
        }

        private Bruger GetRow(SqlDataReader reader)
        {
            return new Bruger
            {
                Id = reader.GetInt32(reader.GetOrdinal("ID")).ToString(),
                Brugernavn = reader["Brugernavn"].ToString() ?? "",
                Adgangskode = reader["Adgangskode"].ToString(),
                Rolle = (Rolle)reader.GetInt32(reader.GetOrdinal("RolleID")),
                GruppeId = reader["GruppeID"]?.ToString() ?? ""
            };
        }
    }





    //Bruger? bruger = null;
    //string query = "SELECT * FROM Bruger WHERE Brugernavn = @brugernavn AND Adgangskode = @adgangskode";

    //using SqlConnection connection = new SqlConnection(ConnectionString);
    //connection.Open();

    //using SqlCommand cmd = new SqlCommand(query, connection);
    //cmd.Parameters.AddWithValue("@brugernavn", brugernavn);
    //cmd.Parameters.AddWithValue("@adgangskode", adgangskode);

    //using SqlDataReader reader = cmd.ExecuteReader();

    //if (reader.Read())
    //{
    //    bruger = GetRow(reader);
    //}

}//Rolle = Enum.TryParse(reader["RolleID"]?.ToString(), out Rolle rolle) ? rolle : Rolle.Elev,
 //Adgangskode = int.TryParse(reader["Adgangskode"].ToString(), out int kode) ? kode : 0,

//        private Rolle ParseRolle(string? rolleIdStr)
//        {
//            if (int.TryParse(rolleIdStr, out int rolleId))
//            {
//                return rolleId switch
//                {
//                    1 => Rolle.Admin,
//                    2 => Rolle.Elev,
//                    3 => Rolle.Lærer,
//                    _ => Rolle.Elev
//                };
//            }
//            return Rolle.Elev;
//        }
//    }
//}

//// BrugerService klasse, der håndterer brugere og login
//public class BrugerService : IBrugerService
//{
//    //Liste over brugere, som kan logge ind
//    private List<Bruger> brugere = new List<Bruger>
//    {
//        // Opretter brugere med brugernavn, adgangskode og rolle
//        new Bruger { Brugernavn = "Malyun", Adgangskode = 1234, Rolle = Rolle.Admin },
//        new Bruger { Brugernavn = "Samira", Adgangskode = 5678, Rolle = Rolle.Lærer },
//        new Bruger { Brugernavn = "Nasro", Adgangskode = 91011, Rolle = Rolle.Elev }
//    };

//    // Login-metode, der tjekker om brugernavn og adgangskode stemmer
//    public Bruger? Login(string brugernavn, int adgangskode)
//    {
//        // Søger efter den første bruger, der matcher brugernavn og adgangskode
//        return brugere.FirstOrDefault(b =>
//            b.Brugernavn.Equals(brugernavn, StringComparison.OrdinalIgnoreCase) && b.Adgangskode == adgangskode);
//    }
//}
















