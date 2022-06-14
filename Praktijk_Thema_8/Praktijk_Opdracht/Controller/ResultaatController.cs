/*
 * Author: Raoel van Schaijk
 * Date: 10-6-2022
 * Description: Resultaat controller with methods for CRUD
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
    class ResultaatController
    {
        // Wordt de connectionstring aangemaakt
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDeVluggehandjes"].ConnectionString;

        /// <summary>
        /// Verwijderd alle resultaten van een bepaalde wedstrijd
        /// </summary>
        /// <param name="wedstrijd">Wedstrijd Model</param>
        /// <returns> Geeft het aantal "Rowsaffected" terug </returns>
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
  
        /// <summary>
        /// Maakt een update voor de database
        /// </summary>
        /// <param name="update"> Resultaat model</param>
        /// <returns>Geeft de update door naar de database</returns>
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
        /// <summary>
        /// Leest de wedstrijd resultaten van een speler
        /// </summary>
        /// <param name="match"> Wedstrijd</param>
        /// <param name="playerId"> Speler</param>
        /// <returns>Geeft resultaat terug van de wedstrijd en speler</returns>
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

        /// <summary>
        /// create a new result in the database
        /// </summary>
        /// <param name="resultaat">ResultaatModel</param>
        /// <returns>rows affected</returns>
        public int Create(ResultaatModel resultaat)
        {
            int rowsAffected = 0;

            // create connection
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Resultaat(Punt, Overgave, SpelerId, WedstrijdId) " +
                                "VALUES(@PuntValue, @OvergaveValue, @SpelerIdValue, @WedstrijdIdValue)";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // sql parameters
                    command.Parameters.AddWithValue("PuntValue", resultaat.Punt);
                    command.Parameters.AddWithValue("OvergaveValue", resultaat.Overgave);
                    command.Parameters.AddWithValue("SpelerIdValue", resultaat.SpelerId.SpelerId);
                    command.Parameters.AddWithValue("WedstrijdIdValue", resultaat.WedstrijdId.WedstrijdId);

                    // open connection
                    con.Open();

                    // execute command
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// Read all wedstrijd results
        /// </summary>
        /// <param name="round"> Ronde </param>
        /// <param name="match"> Wedstrijd nummer</param>
        /// <param name="speler"> Speler Model</param>
        /// <returns> Geeft het resultaat van de Wedstrijd per speler </returns>
        public ResultaatModel ReadAllWedstrijdResultaat(int round, int match, SpelerModel speler)
        {
            ResultaatModel wedstrijdResultaat = new ResultaatModel();
            // create connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Resultaat " +
                    "JOIN Wedstrijd " +
                    "ON Resultaat.WedstrijdId = Wedstrijd.WedstrijdId " +
                    "WHERE Ronde = @RondeValue " +
                    "AND WedstrijdNummer = @WedstrijdNummerValue " +
                    "AND SpelerId = @SpelerIdValue";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("RondeValue", round);
                    command.Parameters.AddWithValue("WedstrijdNummerValue", match);
                    command.Parameters.AddWithValue("SpelerIdValue", speler.SpelerId);
                    // open connection
                    con.Open();

                    // execute command
                    SqlDataReader reader = command.ExecuteReader();

                    // fill wWedstrijdModel and add to list
                    while (reader.Read() == true)
                    {
                        WedstrijdModel item = new WedstrijdModel();
                        item.WedstrijdId = (int)reader["WedstrijdId"];
                        item.Starttijd = (DateTime)reader["Starttijd"];
                        item.Eindtijd = (DateTime)reader["Eindtijd"];
                        item.Ronde = Convert.ToInt32(reader["Ronde"]);
                        item.WedstrijdNummer = Convert.ToInt32(reader["WedstrijdNummer"]);

                        SpelerModel spelerResultaat = new SpelerModel();
                        spelerResultaat.SpelerId = (int)reader["Spelerid"];

                        
                        wedstrijdResultaat.ResultaatId = (int)reader["ResultaatId"];
                        wedstrijdResultaat.Overgave = (bool)reader["Overgave"];
                        wedstrijdResultaat.Punt = Convert.ToInt32(reader["Punt"]);
                        wedstrijdResultaat.WedstrijdId = item;
                        wedstrijdResultaat.SpelerId = spelerResultaat;


                    }
                }
            }
            return wedstrijdResultaat;
        }
    }
}
