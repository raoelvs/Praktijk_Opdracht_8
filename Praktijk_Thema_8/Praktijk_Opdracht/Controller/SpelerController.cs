/*
 * Author: Jarno van Overdijk
 * Date: 14-6-2022
 * Description: Speler Controller
 */
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
    public class SpelerController
    {
        // connection string voor unix testing
        //string connectionString = "Data Source=360580-vluggehandjes.database.windows.net;Initial Catalog = VluggeHandjes; Integrated Security = False; User ID = Quinten; Password=P@ssword";

        private string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDeVluggehandjes"].ConnectionString;

        /// <summary>
        /// Real all methode to get information from the database
        /// </summary>
        /// <returns> This returns information from the tables Speler and School </returns>
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
                        else
                        {
                            spelerItem.Tussenvoegsel = (string)reader["Tussenvoegsel"];
                        }

                        string achternaam = (string)reader["Achternaam"];
                        DateTime geboortedatum = Convert.ToDateTime(reader["Geboortedatum"]);
                        int groep = (byte)reader["Groep"];

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

        /// <summary>
        /// This method ask for the data from the database 
        /// </summary>
        /// <returns> List with information from the database without doubles</returns>
        public List<SpelerModel> ReadAllDistinct()
        {
            List<SpelerModel> resultList = new List<SpelerModel>();

            // stap 1 Connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //stap 2 sqlcommand aanmaken
                string sqlQuery = "SELECT DISTINCT Voornaam FROM Speler";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    con.Open();

                    // stap 3 commando uitvoeren
                    SqlDataReader reader = command.ExecuteReader();

                    //stap 4 door de sql reader heen loopen en objecten aanmaken
                    while (reader.Read() == true)
                    {
                        SpelerModel spelerItem = new SpelerModel();

                        // ophalen table speler gegevens
                        string voornaam = (string)reader["Voornaam"];

                        spelerItem.Voornaam = voornaam;

                        // object toevoegen aan de List<>
                        resultList.Add(spelerItem);
                    }
                }
            }
            return resultList;
        }

        /// <summary>
        /// This method filters the information on firstname of the speler
        /// </summary>
        /// <param name="selectedSpeler"></param>
        /// <returns> List with information from the database </returns>
        public List<SpelerModel> ReadFilter(string selectedSpeler)
        {
            // Lijst aanmaken om alle Taken in op te slaan
            List<SpelerModel> result = new List<SpelerModel>();

            // SQL query als string
            string query = "SELECT * FROM Speler " +
                "JOIN School " +
                "ON Speler.SchoolId = School.SchoolId " +
                "WHERE Voornaam = @selectedSpelerValue";

            // SQL Connectie maken
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Commando object maken
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@selectedSpelerValue", selectedSpeler);
                    // Openen van de connectie
                    con.Open();

                    // Uivoeren van het SQL commando en opslaan in een reader
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Datareader uitlezen Taakvoor Taak en omzetten naar een object
                    while (reader.Read() == true)
                    {
                        SpelerModel filterSpeler = new SpelerModel();
                        SchoolModel filterSchool = new SchoolModel();

                        // ophalen table speler gegevens
                        int spelerId = (int)reader["SpelerId"];
                        string voornaam = (string)reader["Voornaam"];

                        if (reader["Tussenvoegsel"] == DBNull.Value)
                        {
                            filterSpeler.Tussenvoegsel = "";
                        }
                        else
                        {
                            filterSpeler.Tussenvoegsel = (string)reader["Tussenvoegsel"];
                        }

                        string achternaam = (string)reader["Achternaam"];
                        DateTime geboortedatum = Convert.ToDateTime(reader["Geboortedatum"]);
                        int groep = (byte)reader["Groep"];

                        // ophalen table school gegevens
                        int schoolId = (int)reader["SchoolId"];
                        string schoolNaam = (string)reader["Naam"];

                        // object properties een waarde geven
                        // table Speler
                        filterSpeler.SpelerId = spelerId;
                        filterSpeler.Voornaam = voornaam;
                        filterSpeler.Achternaam = achternaam;
                        filterSpeler.Geboortedatum = geboortedatum;
                        filterSpeler.Groep = groep;

                        // table school
                        filterSchool.SchoolId = schoolId;
                        filterSchool.Naam = schoolNaam;

                        // schoolitem toevoegen aan speleritem
                        filterSpeler.SchoolId = filterSchool;

                        // object toevoegen aan de List<>
                        result.Add(filterSpeler);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// This method deletes the speler from database Speler
        /// </summary>
        /// <param name="speler"> this variable has the speler that needs to be deleted</param>
        /// <returns> The rows affected </returns>
        public int Delete(SpelerModel speler)
        {
            int rowsAffected = 0;

            // Opstarten connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Opstarten van SqlCommand
                string query = "DELETE FROM Speler WHERE SpelerId = @SpelerIdValue";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("SpelerIdValue", speler.SpelerId);

                    // Open de connection
                    conn.Open();

                    // Voer de query uit en vang de doctor op
                    rowsAffected = command.ExecuteNonQuery();

                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// This methode is for updating the speler
        /// </summary>
        /// <param name="update"> This variable has the new information to change the speler</param>
        /// <returns> The rows affected </returns>
        public int Update(SpelerModel update)
        {
            int rowsAffected = 0;
            string sqlQuery = "UPDATE Speler SET Voornaam = @VoornaamValue, Tussenvoegsel = @TussenvoegselValue, Achternaam = @AchternaamValue, Geboortedatum = " +
                "@GeboortedatumValue, Groep = @GroepValue, SchoolId = @SchoolIdValue WHERE SpelerId = @SpelerIdValue ";

            // Opstarten connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Opstarten van SqlCommand
                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    command.Parameters.AddWithValue("SpelerIdValue", update.SpelerId);
                    command.Parameters.AddWithValue("VoornaamValue", update.Voornaam);
                    command.Parameters.AddWithValue("TussenvoegselValue", update.Tussenvoegsel);
                    command.Parameters.AddWithValue("AchternaamValue", update.Achternaam);
                    command.Parameters.AddWithValue("GeboortedatumValue", update.Geboortedatum);
                    command.Parameters.AddWithValue("GroepValue", update.Groep);
                    command.Parameters.AddWithValue("SchoolIdValue", update.SchoolId.SchoolId);

                    con.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
        
        /// <summary>
        /// This method is to make a new speler in the database
        /// </summary>
        /// <param name="item"> In this variable item is the information to create a new speler</param>
        /// <returns> The rows affected</returns>
        public int Create(SpelerModel item)
        {
            int rowsAffected = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO Speler VALUES (@VoornaamValue, @TussenvoegselValue, @AchternaamValue, @GeboortedatumValue, @GroepValue, @SchoolIdValue)";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    command.Parameters.AddWithValue("VoornaamValue", item.Voornaam);
                    command.Parameters.AddWithValue("TussenvoegselValue", item.Tussenvoegsel);
                    command.Parameters.AddWithValue("AchternaamValue", item.Achternaam);
                    command.Parameters.AddWithValue("GeboortedatumValue", item.Geboortedatum);
                    command.Parameters.AddWithValue("GroepValue", item.Groep);
                    command.Parameters.AddWithValue("SchoolIdValue", item.SchoolId.SchoolId);

                    con.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
        /// <summary>
        /// Read waar niet de speler niet in zit
        /// </summary>
        /// <param name="speler"> SpelerModel </param>
        /// <returns> List with information from the database</returns>
        public List<SpelerModel> ReadWhereIsNot(SpelerModel speler)
        {
            List<SpelerModel> resultList = new List<SpelerModel>();

            // stap 1 Connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //stap 2 sqlcommand aanmaken
                string sqlQuery = "SELECT * FROM Speler " +
                    "JOIN School ON Speler.SchoolId = School.SchoolId " +
                    "WHERE SpelerId != @SpelerIdValue";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    command.Parameters.AddWithValue("SpelerIdValue", speler.SpelerId);
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
                        else
                        {
                            spelerItem.Tussenvoegsel = (string)reader["Tussenvoegsel"];
                        }

                        string achternaam = (string)reader["Achternaam"];
                        DateTime geboortedatum = Convert.ToDateTime(reader["Geboortedatum"]);
                        int groep = (byte)reader["Groep"];

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
