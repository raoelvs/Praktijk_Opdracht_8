﻿using Praktijk_Opdracht.Model;
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
        /// This method deletes the speler from database at all tables
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
                string query = "DELETE FROM Speler WHERE SpelerId = @SpelerIdValue"; // Query nog aanpassen vanwegen constraint

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
                    command.Parameters.AddWithValue("SchoolIdValue", update.SchoolId);

                    con.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
        
        /// <summary>
        /// This methode is to make a new speler in the database
        /// </summary>
        /// <param name="item"> In this variable item is the information to create a new speler</param>
        /// <returns> The rows affected</returns>
        public int Create(SpelerModel item)
        {
            int rowsAffected = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO Speler VALUES (@VoornaamValue, @TussenvoegselValue, @AchternaamValue, @GeboortedatumValue, @GroepValue, SchoolIdValue)";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    command.Parameters.AddWithValue("VoornaamValue", item.Voornaam);
                    command.Parameters.AddWithValue("TussenvoegselValue", item.Tussenvoegsel);
                    command.Parameters.AddWithValue("AchternaamValue", item.Achternaam);
                    command.Parameters.AddWithValue("GeboortedatumValue", item.Geboortedatum);
                    command.Parameters.AddWithValue("GroepValue", item.Groep);
                    command.Parameters.AddWithValue("SchoolIdValue", item.SchoolId);

                    con.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

    }
}
