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
                        ResultaatModel resultaatItem = new ResultaatModel();
                        WedstrijdModel wedstrijdItem = new WedstrijdModel();
                        SpelerModel spelerItem = new SpelerModel();

                        resultaatItem.ResultaatId = (int)reader["ResultaatId"];
                        resultaatItem.Punt = Convert.ToInt32(reader["Punt"]);
                        resultaatItem.Overgave = (bool)reader["Overgave"];

                        wedstrijdItem.WedstrijdId = (int)reader["WedstrijdId"];
                        spelerItem.SpelerId = (int)reader["SpelerId"];

                        resultList.Add(resultaatItem);
                    }
                }
            }
            return resultList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public int Update(ResultaatModel update)
        {
            int rowsAffected = 0;
            string sqlQuery = "UPDATE Resultaat SET Punt = @PuntValue, Overgave = @OvergaveValue, WedstrijdId = @WedstrijdIdValue, SpelerId = @SpelerIdValue" +
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
                    command.Parameters.AddWithValue("SpelerIdValue", update.SpelerId);

                    con.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Create(ResultaatModel item)
        {
            int rowsAffected = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO Resultaat VALUES (@PuntValue, @OvergaveValue)";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    command.Parameters.AddWithValue("PuntValue", item.Punt);
                    command.Parameters.AddWithValue("OvergaveValue", item.Overgave);
         
                    con.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultaat"></param>
        /// <returns></returns>
        public int Delete(ResultaatModel resultaat)
        {
            int rowsAffected = 0;

            // Opstarten connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Opstarten van SqlCommand
                string query = "DELETE FROM Resultaat WHERE ResultaatId = @ResultaatIdValue "; 

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

        /* public List<ResultaatModel> Update()
         {
             List<ResultaatModel> resultList = new List<ResultaatModel>();

             using (SqlConnection con = new SqlConnection(connectionString))
             {
                 string sqlQuery = "SELECT * " +
                     "FROM Resultaat " +
                     "WHERE WedstrijdId = @WedstrijdIdValue " +
                     "AND SpelerId = @SpelerIdValue";
                 *//*"JOIN Wedstrijd ON Resultaat.WedstrijdId = Wedstrijd.WedstrijdId" +
                 "JOIN Speler ON Resultaat.SpelerId = Speler.SpelerId"*//*

                 using (SqlCommand command = new SqlCommand(sqlQuery, con))
                 {
                     con.Open();
                     SqlDataReader reader = command.ExecuteReader();

                     while (reader.Read() == true)
                     {
                         ResultaatModel resultaatItem = new ResultaatModel();
                         WedstrijdModel wedstrijdItem = new WedstrijdModel();
                         SpelerModel spelerItem = new SpelerModel();

                         resultaatItem.ResultaatId = (int)reader["ResultaatId"];
                         resultaatItem.Punt = (int)reader["SeriesNumber"];
                         resultaatItem.Overgave = (bool)reader["Overgave"];

                         wedstrijdItem.WedstrijdId = (int)reader["WedstrijdId"];
                         spelerItem.SpelerId = (int)reader["SpelerId"];

                         resultList.Add(resultaatItem);
                     }
                 }
             }
             return resultList;
         }*/
    }
}
