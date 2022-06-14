/*
 * Author: Quinten Kornalijnslijper
 * Date: 10-6-2022
 * Description: wedstrijd controller with methods fot CRUD
 */
using Praktijk_Opdracht.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktijk_Opdracht.Controller
{
    class WedstrijdController
    {
        // connection string
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDeVluggehandjes"].ConnectionString;

        /// <summary>
        /// read all matches from database
        /// </summary>
        /// <returns>List with WedstrijModel</returns>
        public List<WedstrijdModel> ReadAll()
        {
            List<WedstrijdModel> list = new List<WedstrijdModel>();
            // create connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM vWedstrijden ORDER BY Ronde,WedstrijdNummer";
                using (SqlCommand command = new SqlCommand(query, con))
                {
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

                        ScheidsrechterModel scheidsrechter = new ScheidsrechterModel();
                        scheidsrechter.ScheidsrechterCode = (string)reader["ScheidsrechterCode"];
                        scheidsrechter.Voornaam = (string)reader["ScheidsrechterVoornaam"];
                        scheidsrechter.Tussenvoegsel = "";
                        if (reader["ScheidsrechterTussenvoegsel"] != DBNull.Value)
                        {
                            scheidsrechter.Tussenvoegsel = (string)reader["ScheidsrechterTussenvoegsel"];
                        }
                        scheidsrechter.Achternaam = (string)reader["ScheidsrechterAchternaam"];
                        scheidsrechter.Wachtwoord = (string)reader["Wachtwoord"];

                        SpelerModel thuis = new SpelerModel();
                        thuis.SpelerId = (int)reader["Thuis"];
                        thuis.Voornaam = (string)reader["ThuisVoornaam"];
                        thuis.Tussenvoegsel = "";
                        if (reader["ThuisTussenvoegsel"] != DBNull.Value)
                        {
                            thuis.Tussenvoegsel = (string)reader["ThuisTussenvoegsel"];
                        }
                        thuis.Achternaam = (string)reader["ThuisAchternaam"];
                        thuis.Groep = Convert.ToInt32(reader["ThuisGroep"]);
                        thuis.Geboortedatum = (DateTime)reader["ThuisGeboortedatum"];

                        SchoolModel thuisSchool = new SchoolModel();
                        thuisSchool.SchoolId = (int)reader["ThuisSchoolId"];
                        thuisSchool.Naam = (string)reader["ThuisSchoolNaam"];

                        SpelerModel uit = new SpelerModel();
                        uit.SpelerId = (int)reader["Uit"];
                        uit.Voornaam = (string)reader["UitVoornaam"];
                        uit.Tussenvoegsel = "";
                        if (reader["UitTussenvoegsel"] != DBNull.Value)
                        {
                            uit.Tussenvoegsel = (string)reader["UitTussenvoegsel"];
                        }
                        uit.Achternaam = (string)reader["UitAchternaam"];
                        uit.Groep = Convert.ToInt32(reader["UitGroep"]);
                        uit.Geboortedatum = (DateTime)reader["UitGeboortedatum"];

                        SchoolModel uitSchool = new SchoolModel();
                        uitSchool.SchoolId = (int)reader["UitSchoolId"];
                        uitSchool.Naam = (string)reader["UitSchoolNaam"];

                        SpelerModel winnaar = new SpelerModel();
                        winnaar.SpelerId = 0;
                        winnaar.Voornaam = "";
                        winnaar.Tussenvoegsel = "";
                        winnaar.Achternaam = "";
                        winnaar.Groep = 0;
                        winnaar.Geboortedatum = DateTime.MinValue;

                        SchoolModel winnaarSchool = new SchoolModel();
                        winnaarSchool.SchoolId = 0;
                        winnaarSchool.Naam = "";

                        if (reader["Winnaar"] != DBNull.Value)
                        {
                            winnaar.SpelerId = (int)reader["Winnaar"];
                            winnaar.Voornaam = (string)reader["WinnaarVoornaam"];
                            winnaar.Tussenvoegsel = "";
                            if (reader["WinnaarTussenvoegsel"] != DBNull.Value)
                            {
                                winnaar.Tussenvoegsel = (string)reader["WinnaarTussenvoegsel"];
                            }
                            winnaar.Achternaam = (string)reader["WinnaarAchternaam"];
                            winnaar.Groep = Convert.ToInt32(reader["WinnaarGroep"]);
                            winnaar.Geboortedatum = (DateTime)reader["WinnaarGeboortedatum"];

                            winnaarSchool.SchoolId = (int)reader["WinnaarSchoolId"];
                            winnaarSchool.Naam = (string)reader["WinnaarSchoolNaam"];
                        }
                        winnaar.SchoolId = winnaarSchool;
                        uit.SchoolId = uitSchool;
                        thuis.SchoolId = thuisSchool;

                        item.ScheidsrechterCode = scheidsrechter;
                        item.Thuis = thuis;
                        item.Uit = uit;
                        item.Winnaar = winnaar;

                        list.Add(item);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// read match where match in round
        /// </summary>
        /// <param name="round">ronde</param>
        /// <param name="match">wedstrijd</param>
        /// <returns>WedstrijdModel</returns>
        public WedstrijdModel ReadWhereRoundMatch(int round, int match)
        {
            WedstrijdModel item = new WedstrijdModel();
            // creatre connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM vWedstrijden WHERE Ronde = @RondeValue AND WedstrijdNummer = @WedstrijdNummerValue";
                using(SqlCommand command = new SqlCommand(query,con))
                {
                    // sql parameters
                    command.Parameters.AddWithValue("RondeValue", round);
                    command.Parameters.AddWithValue("WedstrijdNummerValue", match);

                    // open connection
                    con.Open();

                    // execute command
                    SqlDataReader reader = command.ExecuteReader();

                    // fill wWedstrijdModel and add to list
                    while (reader.Read() == true)
                    {
                        
                        item.WedstrijdId = (int)reader["WedstrijdId"];
                        item.Starttijd = (DateTime)reader["Starttijd"];
                        item.Eindtijd = (DateTime)reader["Eindtijd"];
                        item.Ronde = Convert.ToInt32(reader["Ronde"]);
                        item.WedstrijdNummer = Convert.ToInt32(reader["WedstrijdNummer"]);

                        ScheidsrechterModel scheidsrechter = new ScheidsrechterModel();
                        scheidsrechter.ScheidsrechterCode = (string)reader["ScheidsrechterCode"];
                        scheidsrechter.Voornaam = (string)reader["ScheidsrechterVoornaam"];
                        scheidsrechter.Tussenvoegsel = "";
                        if (reader["ScheidsrechterTussenvoegsel"] != DBNull.Value)
                        {
                            scheidsrechter.Tussenvoegsel = (string)reader["ScheidsrechterTussenvoegsel"];
                        }
                        scheidsrechter.Achternaam = (string)reader["ScheidsrechterAchternaam"];
                        scheidsrechter.Wachtwoord = (string)reader["Wachtwoord"];

                        SpelerModel thuis = new SpelerModel();
                        thuis.SpelerId = (int)reader["Thuis"];
                        thuis.Voornaam = (string)reader["ThuisVoornaam"];
                        thuis.Tussenvoegsel = "";
                        if (reader["ThuisTussenvoegsel"] != DBNull.Value)
                        {
                            thuis.Tussenvoegsel = (string)reader["ThuisTussenvoegsel"];
                        }
                        thuis.Achternaam = (string)reader["ThuisAchternaam"];
                        thuis.Groep = Convert.ToInt32(reader["ThuisGroep"]);
                        thuis.Geboortedatum = (DateTime)reader["ThuisGeboortedatum"];

                        SchoolModel thuisSchool = new SchoolModel();
                        thuisSchool.SchoolId = (int)reader["ThuisSchoolId"];
                        thuisSchool.Naam = (string)reader["ThuisSchoolNaam"];

                        SpelerModel uit = new SpelerModel();
                        uit.SpelerId = (int)reader["Uit"];
                        uit.Voornaam = (string)reader["UitVoornaam"];
                        uit.Tussenvoegsel = "";
                        if (reader["UitTussenvoegsel"] != DBNull.Value)
                        {
                            uit.Tussenvoegsel = (string)reader["UitTussenvoegsel"];
                        }                        
                        uit.Achternaam = (string)reader["UitAchternaam"];
                        uit.Groep = Convert.ToInt32(reader["UitGroep"]);
                        uit.Geboortedatum = (DateTime)reader["UitGeboortedatum"];

                        SchoolModel uitSchool = new SchoolModel();
                        uitSchool.SchoolId = (int)reader["UitSchoolId"];
                        uitSchool.Naam = (string)reader["UitSchoolNaam"];

                        SpelerModel winnaar = new SpelerModel();
                        winnaar.SpelerId = 0;
                        winnaar.Voornaam = "";
                        winnaar.Tussenvoegsel = "";
                        winnaar.Achternaam = "";
                        winnaar.Groep = 0;
                        winnaar.Geboortedatum = DateTime.MinValue;

                        SchoolModel winnaarSchool = new SchoolModel();
                        winnaarSchool.SchoolId = 0;
                        winnaarSchool.Naam = "";

                        if (reader["Winnaar"] != DBNull.Value)
                        {
                            winnaar.SpelerId = (int)reader["Winnaar"];
                            winnaar.Voornaam = (string)reader["WinnaarVoornaam"];
                            winnaar.Tussenvoegsel = "";
                            if (reader["WinnaarTussenvoegsel"] != DBNull.Value)
                            {
                                winnaar.Tussenvoegsel = (string)reader["WinnaarTussenvoegsel"];
                            }                            
                            winnaar.Achternaam = (string)reader["WinnaarAchternaam"];
                            winnaar.Groep = Convert.ToInt32(reader["WinnaarGroep"]);
                            winnaar.Geboortedatum = (DateTime)reader["WinnaarGeboortedatum"];

                            winnaarSchool.SchoolId = (int)reader["WinnaarSchoolId"];
                            winnaarSchool.Naam = (string)reader["WinnaarSchoolNaam"];
                        }
                        winnaar.SchoolId = winnaarSchool;
                        uit.SchoolId = uitSchool;
                        thuis.SchoolId = thuisSchool;

                        item.ScheidsrechterCode = scheidsrechter;
                        item.Thuis = thuis;
                        item.Uit = uit;
                        item.Winnaar = winnaar;                        
                    }
                }
            }
            return item;
        }

        /// <summary>
        /// add match to database
        /// </summary>
        /// <param name="wedstrijd">WedstrijdModel</param>
        /// <returns>rows affected</returns>
        public int Create(WedstrijdModel wedstrijd)
        {
            int rowsAffected = 0;

            // create connection
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Wedstrijd(Ronde, WedstrijdNummer, Starttijd, Eindtijd, Thuis, Uit, ScheidsrechterCode) " +
                    "VALUES(@RondeValue, @WedstrijdNummerValue, @StartijdValue, @EindtijdValue, @ThuisValue, @UitValue, @ScheidsrechterCodeValue);";
                using(SqlCommand command = new SqlCommand(query, con))
                {
                    // sql parameters
                    command.Parameters.AddWithValue("RondeValue", wedstrijd.Ronde);
                    command.Parameters.AddWithValue("WedstrijdNummerValue", wedstrijd.WedstrijdNummer);
                    command.Parameters.AddWithValue("StartijdValue", wedstrijd.Starttijd);
                    command.Parameters.AddWithValue("EindtijdValue", wedstrijd.Eindtijd);
                    command.Parameters.AddWithValue("ThuisValue", wedstrijd.Thuis.SpelerId);
                    command.Parameters.AddWithValue("UitValue", wedstrijd.Uit.SpelerId);
                    command.Parameters.AddWithValue("ScheidsrechterCodeValue", wedstrijd.ScheidsrechterCode.ScheidsrechterCode);
                   
                    // open connection
                    con.Open();

                    // execute command
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        /// <summary>
        /// Update match in the database
        /// </summary>
        /// <param name="wedstrijd">WedstrijdModel</param>
        /// <returns>rows affected</returns>
        public int Update(WedstrijdModel wedstrijd)
        {
            int rowsAffected = 0;

            // create connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Wedstrijd " +
                    "SET Ronde = @RondeValue, " +
                        "WedstrijdNummer = @WedstrijdNummerValue, " +
                        "Starttijd = @StartijdValue, " +
                        "Eindtijd = @EindtijdValue, " +
                        "Thuis = @ThuisValue, " +
                        "Uit = @UitValue, " +
                        "ScheidsrechterCode = @ScheidsrechterCodeValue " +
                    "WHERE WedstrijdId = @WedstrijdIdValue;";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // sql parameters
                    command.Parameters.AddWithValue("WedstrijdIdValue", wedstrijd.WedstrijdId);
                    command.Parameters.AddWithValue("RondeValue", wedstrijd.Ronde);
                    command.Parameters.AddWithValue("WedstrijdNummerValue", wedstrijd.WedstrijdNummer);
                    command.Parameters.AddWithValue("StartijdValue", wedstrijd.Starttijd);
                    command.Parameters.AddWithValue("EindtijdValue", wedstrijd.Eindtijd);
                    command.Parameters.AddWithValue("ThuisValue", wedstrijd.Thuis.SpelerId);
                    command.Parameters.AddWithValue("UitValue", wedstrijd.Uit.SpelerId);
                    command.Parameters.AddWithValue("ScheidsrechterCodeValue", wedstrijd.ScheidsrechterCode.ScheidsrechterCode);
                    
                    // open connection
                    con.Open();

                    // execute commands
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        /// <summary>
        /// Update winner of the match in the database
        /// </summary>
        /// <param name="wedstrijd">WedstrijdModel</param>
        /// <returns>rows affected</returns>
        public int UpdateWinner(WedstrijdModel wedstrijd)
        {
            int rowsAffected = 0;

            // create connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Wedstrijd " +
                    "SET Winnaar = @WinnaarValue " +
                    "WHERE WedstrijdId = @WedstrijdIdValue;";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // sql parameters
                    command.Parameters.AddWithValue("WedstrijdIdValue", wedstrijd.WedstrijdId);
                    command.Parameters.AddWithValue("WinnaarValue", wedstrijd.Winnaar.SpelerId);

                    // open connection
                    con.Open();

                    // execute commands
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        /// <summary>
        /// delete match in the database
        /// </summary>
        /// <param name="wedstrijd">WedstrijdModel</param>
        /// <returns>rows affected</returns>
        public int Delete(WedstrijdModel wedstrijd)
        {
            int rowsAffected = 0;

            // Opstarten connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Opstarten van SqlCommand
                string query = "DELETE FROM Wedstrijd WHERE WedstrijdId = @WedstrijdIdValue";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    //sql parameters
                    command.Parameters.AddWithValue("WedstrijdIdValue", wedstrijd.WedstrijdId);

                    // Open de connection
                    conn.Open();

                    // Voer de query uit en vang de doctor op
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }



    }
}
