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
    class ScheidsrechterController
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDeVluggehandjes"].ConnectionString;

        /// <summary>
        /// Real all methode to get information from the database
        /// </summary>
        /// <returns> This returns information from the tables Speler and School </returns>
        public List<ScheidsrechterModel> ReadAll()
        {
            List<ScheidsrechterModel> resultList = new List<ScheidsrechterModel>();

            // stap 1 Connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //stap 2 sqlcommand aanmaken
                string sqlQuery = "SELECT * FROM Scheidsrechter ";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    con.Open();

                    // stap 3 commando uitvoeren
                    SqlDataReader reader = command.ExecuteReader();

                    //stap 4 door de sql reader heen loopen en objecten aanmaken
                    while (reader.Read() == true)
                    {
                        ScheidsrechterModel scheidsrechterItem = new ScheidsrechterModel();

                        // ophalen table scheidsrechter gegevens
                        string scheidsrechterCode = (string)reader["ScheidsrechterCode"];
                        string voornaam = (string)reader["Voornaam"];

                        if (reader["Tussenvoegsel"] == DBNull.Value)
                        {
                            scheidsrechterItem.Tussenvoegsel = "";
                        }
                        else
                        {
                            scheidsrechterItem.Tussenvoegsel = (string)reader["Tussenvoegsel"];
                        }

                        string achternaam = (string)reader["Achternaam"];
                        string wachtwoord = (string)reader["Wachtwoord"];


                        // object properties een waarde geven
                        scheidsrechterItem.ScheidsrechterCode = scheidsrechterCode;
                        scheidsrechterItem.Voornaam = voornaam;
                        scheidsrechterItem.Achternaam = achternaam;
                        scheidsrechterItem.Wachtwoord = wachtwoord;


                        // object toevoegen aan de List<>
                        resultList.Add(scheidsrechterItem);
                    }
                }
            }
            return resultList;
        }

        /// <summary>
        /// This method deletes the scheidsrechter from database table scheidsrechter
        /// </summary>
        /// <param name="scheidsrechter"> this variable has the scheidsrechter that needs to be deleted</param>
        /// <returns> The rows affected </returns>
        public int Delete(ScheidsrechterModel scheidsrechter)
        {
            int rowsAffected = 0;

            // Opstarten connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Opstarten van SqlCommand
                string query = "DELETE FROM Scheidsrechter WHERE ScheidsrechterCode = @ScheidsrechterCodeValue";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("ScheidsrechterCodeValue", scheidsrechter.ScheidsrechterCode);

                    // Open de connection
                    conn.Open();

                    // Voer de query uit en vang de doctor op
                    rowsAffected = command.ExecuteNonQuery();

                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// This methode is for updating the Scheidsrechter
        /// </summary>
        /// <param name="update"> This variable has the new information to change the Scheidsrechter</param>
        /// <returns> The rows affected </returns>
        public int Update(ScheidsrechterModel update)
        {
            int rowsAffected = 0;
            string sqlQuery = "UPDATE Scheidsrechter SET Voornaam = @VoornaamValue, Tussenvoegsel = @TussenvoegselValue, Achternaam = @AchternaamValue, Wachtwoord = " +
                "@WachtwoordValue WHERE ScheidsrechterCode = @ScheidsrechterCodeValue ";

            // Opstarten connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Opstarten van SqlCommand
                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    command.Parameters.AddWithValue("ScheidsrechterCodeValue", update.ScheidsrechterCode);
                    command.Parameters.AddWithValue("VoornaamValue", update.Voornaam);
                    command.Parameters.AddWithValue("TussenvoegselValue", update.Tussenvoegsel);
                    command.Parameters.AddWithValue("AchternaamValue", update.Achternaam);
                    command.Parameters.AddWithValue("WachtwoordValue", update.Wachtwoord);

                    con.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// This method is to make a new scheidsrechter in the database
        /// </summary>
        /// <param name="item"> In this variable item is the information to create a new scheidsrechter </param>
        /// <returns> The rows affected</returns>
        public int Create(ScheidsrechterModel item)
        {
            int rowsAffected = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO Scheidsrechter VALUES (@VScheidsrechterCodeValue, @VoornaamValue, @TussenvoegselValue, @AchternaamValue, @WachtwoordValue)";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    command.Parameters.AddWithValue("VScheidsrechterCodeValue", item.ScheidsrechterCode);
                    command.Parameters.AddWithValue("VoornaamValue", item.Voornaam);
                    command.Parameters.AddWithValue("TussenvoegselValue", item.Tussenvoegsel);
                    command.Parameters.AddWithValue("AchternaamValue", item.Achternaam);
                    command.Parameters.AddWithValue("WachtwoordValue", item.Wachtwoord);

                    con.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// Read methode that shows the password from scheidsrechter
        /// </summary>
        /// <param name="password"> this variable contains the id from scheidsrechter</param>
        /// <returns> Rows affected </returns>
        public ScheidsrechterModel ReadWhere(string password)
        {
            ScheidsrechterModel scheidsrechterItem = new ScheidsrechterModel();
            // stap 1 Connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //stap 2 sqlcommand aanmaken
                string sqlQuery = "SELECT * FROM Scheidsrechter WHERE ScheidsrechterCode = @ScheidsrechterCodeValue ";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    command.Parameters.AddWithValue("ScheidsrechterCodeValue", password);
                    con.Open();

                    // stap 3 commando uitvoeren
                    SqlDataReader reader = command.ExecuteReader();

                    //stap 4 door de sql reader heen loopen en objecten aanmaken


                    while(reader.Read() == true)
                    {
                        // ophalen table scheidsrechter gegevens
                        string scheidsrechterCode = (string)reader["ScheidsrechterCode"];
                        string voornaam = (string)reader["Voornaam"];
              
                    
                        if (reader["Tussenvoegsel"] == DBNull.Value)
                        {
                            scheidsrechterItem.Tussenvoegsel = "";
                        }
                        else
                        {
                            scheidsrechterItem.Tussenvoegsel = (string)reader["Tussenvoegsel"];
                        }

                        string achternaam = (string)reader["Achternaam"];
                        string wachtwoord = (string)reader["Wachtwoord"];


                        // object properties een waarde geven
                        scheidsrechterItem.ScheidsrechterCode = scheidsrechterCode;
                        scheidsrechterItem.Voornaam = voornaam;
                        scheidsrechterItem.Achternaam = achternaam;
                        scheidsrechterItem.Wachtwoord = wachtwoord;
                    }
                }
            }
            return scheidsrechterItem;
        }
    }
}
