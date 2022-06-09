using Praktijk_Opdracht.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktijk_Opdracht.Controller
{
    class SpelerController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDeVluggehandjes"].ConnectionString;

        public List<SpelerModel> ReadAll()
        {
            List<SpelerModel> resultList = new List<SpelerModel>();

            // stap 1 Connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //stap 2 sqlcommand aanmaken
                string sqlQuery = "SELECT * FROM Speler " +
                    "JOIN School ON Speler.SchoolId = School.SchoolId";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    con.Open();

                    // stap 3 commando uitvoeren
                    SqlDataReader reader = command.ExecuteReader();

                    //stap 4 door de sql reader heen loopen en objecten aanmaken
                    while (reader.Read() == true)
                    {
                        SpelerModel spelerItem = new SpelerModel();
                        SchoolModel schoolItem = new SchoolModel();

                        // ophalen table speler gegevens
                        int spelerId = (int)reader["SpelerId"];
                        string voornaam = (string)reader["Voornaam"];

                        if (reader["Tussenvoegsel"] == DBNull.Value)
                        {
                            spelerItem.Tussenvoegsel = "";
                        }

                        string achternaam = (string)reader["Achternaam"];
                        DateTime geboortedatum = Convert.ToDateTime(reader["Geboortedatum"]);
                        int groep = (int)reader["Groep"];

                        // ophalen table school gegevens
                        int schoolId = (int)reader["SchoolId"];
                        string naam = (string)reader["Naam"];

                        // object properties een waarde geven
                        // table Speler
                        spelerItem.SpelerId = spelerId;
                        spelerItem.Voornaam = voornaam;
                        spelerItem.Achternaam = achternaam;
                        spelerItem.Geboortedatum = geboortedatum;
                        spelerItem.Groep = groep;

                        // table school
                        schoolItem.SchoolId = schoolId;
                        schoolItem.Naam = naam;

                        // schoolitem toevoegen aan speleritem
                        spelerItem.SchoolId = schoolItem;

                        // object toevoegen aan de List<>
                        resultList.Add(spelerItem);
                    }
                }
            }
            return resultList;
        }
    }
}
