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
    class ResultaatController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDeVluggehandjes"].ConnectionString;

        public List<ResultaatModel> ReadAll()
        {
            List<ResultaatModel> resultList = new List<ResultaatModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * " +
                    "FROM Resultaat " +
                    "JOIN Wedstrijd ON Resultaat.WedstrijdId = Wedstrijd.WedstrijdId " +
                    "JOIN Speler ON Resultaat.SpelerId = Speler.SpelerId ";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        ResultaatModel ResultaatItem = new ResultaatModel();
                        WedstrijdModel WedstrijdItem = new WedstrijdModel();
                        SpelerModel SpelerItem = new SpelerModel();

                        ResultaatItem.ResultaatId = (int)reader["ResultaatId"];
                        ResultaatItem.Punt =  Convert.ToInt32(reader["Punt"]);
                        ResultaatItem.Overgave = (bool)reader["Overgave"];

                        WedstrijdItem.WedstrijdId = (int)reader["WedstrijdId"];
                        WedstrijdItem.Starttijd = (DateTime)reader["Starttijd"];
                        WedstrijdItem.Eindtijd = (DateTime)reader["Eindtijd"];
                        WedstrijdItem.Ronde = Convert.ToInt32(reader["Ronde"]);
                        WedstrijdItem.WedstrijdNummer = Convert.ToInt32(reader["WedstrijdNummer"]);

                        SpelerItem.SpelerId = (int)reader["SpelerId"];
                        SpelerItem.Voornaam = (string)reader["Voornaam"];
                        if (reader["Tussenvoegsel"] == DBNull.Value)
                        {
                            SpelerItem.Tussenvoegsel = "";
                        }
                        else
                        {
                            SpelerItem.Tussenvoegsel = (string)reader["Tussenvoegsel"];
                        }
                        SpelerItem.Achternaam = (string)reader["Achternaam"];
                        SpelerItem.Geboortedatum = (DateTime)reader["Geboortedatum"];
                        SpelerItem.Groep = Convert.ToInt32(reader["Groep"]);

                        ResultaatItem.WedstrijdId = WedstrijdItem;
                        ResultaatItem.SpelerId = SpelerItem;

                        resultList.Add(ResultaatItem);
                        
                    }
                }
            }
            return resultList;
        }

        public int DeleteAllFromWedstrijd(WedstrijdModel wedstrijd)
        {
            int rowsAffected = 0;

            // Opstarten connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Opstarten van SqlCommand
                string query = "DELETE FROM Resultaat WHERE WedstrijdId = @WedstrijdIdValue";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("WedstrijdIdValue", wedstrijd.WedstrijdId);

                    // Open de connection
                    conn.Open();

                    // Voer de query uit en vang de doctor op
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public int Delete(ResultaatModel resultaat)
        {
            int rowsAffected = 0;

            // Opstarten connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Opstarten van SqlCommand
                string query = "DELETE FROM Resultaat WHERE ResultaatId = @ResultaatIdValue";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("ResultaatIdValue", resultaat.ResultaatId);

                    // Open de connection
                    conn.Open();

                    // Voer de query uit en vang de doctor op
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public int Update(ResultaatModel update)
        {
            int rowsAffected = 0;
            string sqlQuery = "UPDATE Resultaat " +
                                "SET Punt = @PuntValue, " +
                                    "Overgave = @OvergaveValue " +
                                "WHERE ResultaatId = @ResultaatIdValue ";

            // Opstarten connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Opstarten van SqlCommand
                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    command.Parameters.AddWithValue("ResultaatIdValue", update.ResultaatId);
                    command.Parameters.AddWithValue("PuntValue", update.Punt);
                    command.Parameters.AddWithValue("OvergaveValue", update.Overgave);

                    con.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
        public ResultaatModel ReadWhereMatchPlayer(int match, int playerId)
        {
            ResultaatModel ResultaatItem = new ResultaatModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * " +
                    "FROM Resultaat " +
                    "JOIN Wedstrijd ON Resultaat.WedstrijdId = Wedstrijd.WedstrijdId " +
                    "JOIN Speler ON Resultaat.SpelerId = Speler.SpelerId " +
                    "WHERE Resultaat.WedstrijdId = @WedstrijdIdValue " +
                    "AND Resultaat.SpelerId = @SpelerIdValue";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    command.Parameters.AddWithValue("WedstrijdIdValue", match);
                    command.Parameters.AddWithValue("SpelerIdValue", playerId);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        WedstrijdModel WedstrijdItem = new WedstrijdModel();
                        SpelerModel SpelerItem = new SpelerModel();

                        ResultaatItem.ResultaatId = (int)reader["ResultaatId"];
                        ResultaatItem.Punt = Convert.ToInt32(reader["Punt"]);
                        ResultaatItem.Overgave = (bool)reader["Overgave"];

                        WedstrijdItem.WedstrijdId = (int)reader["WedstrijdId"];
                        WedstrijdItem.Starttijd = (DateTime)reader["Starttijd"];
                        WedstrijdItem.Eindtijd = (DateTime)reader["Eindtijd"];
                        WedstrijdItem.Ronde = Convert.ToInt32(reader["Ronde"]);
                        WedstrijdItem.WedstrijdNummer = Convert.ToInt32(reader["WedstrijdNummer"]);

                        SpelerItem.SpelerId = (int)reader["SpelerId"];
                        SpelerItem.Voornaam = (string)reader["Voornaam"];
                        if (reader["Tussenvoegsel"] == DBNull.Value)
                        {
                            SpelerItem.Tussenvoegsel = "";
                        }
                        else
                        {
                            SpelerItem.Tussenvoegsel = (string)reader["Tussenvoegsel"];
                        }
                        SpelerItem.Achternaam = (string)reader["Achternaam"];
                        SpelerItem.Geboortedatum = (DateTime)reader["Geboortedatum"];
                        SpelerItem.Groep = Convert.ToInt32(reader["Groep"]);

                        ResultaatItem.WedstrijdId = WedstrijdItem;
                        ResultaatItem.SpelerId = SpelerItem;

                    }
                }
            }
            return ResultaatItem;
        }
    }
}
