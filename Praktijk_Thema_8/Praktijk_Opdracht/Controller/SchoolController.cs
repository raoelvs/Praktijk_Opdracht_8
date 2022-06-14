/*
 * Author: Quinten Kornalijnslijper
 * Date: 10-6-2022
 * Description: school controller with methods for CRUD
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
    public class SchoolController
    {
        // connection string voor unix testing
        //string connectionString = "Data Source=360580-vluggehandjes.database.windows.net;Initial Catalog = VluggeHandjes; Integrated Security = False; User ID = Quinten; Password=P@ssword";


        // connection string
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDeVluggehandjes"].ConnectionString;

        /// <summary>
        /// read all schools in database
        /// </summary>
        /// <returns>list with SchoolModelreturns>
        public List<SchoolModel> ReadAll()
        {
            List<SchoolModel> schoolList = new List<SchoolModel>();
            // create connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM School ORDER BY Naam";
                // create command
                using(SqlCommand command = new SqlCommand(query, con))
                {
                    // open connection
                    con.Open();

                    // execute command
                    SqlDataReader reader = command.ExecuteReader();

                    // fill list with SschoolModel
                    while(reader.Read() == true)
                    {
                        SchoolModel school = new SchoolModel();
                        school.SchoolId = (int)reader["SchoolId"];
                        school.Naam = (string)reader["Naam"];

                        schoolList.Add(school);
                    }
                }
            }
            return schoolList;
        }

        /// <summary>
        /// add a school to the database
        /// </summary>
        /// <param name="school">SchoolModel</param>
        /// <returns>rows affected</returns>
        public int Create(SchoolModel school)
        {
            int rowsAffected = 0;

            // create connection
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO School(Naam) VALUES(@NaamValue)";
                using(SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("NaamValue", school.Naam);
                    // connection start
                    con.Open();

                    //execute query
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// update a school in the database
        /// </summary>
        /// <param name="school">SchoolModel</param>
        /// <returns>rowsaffected</returns>
        public int Update(SchoolModel school)
        {
            int rowsAffected = 0;

            // create a connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE School SET Naam = @NaamValue WHERE SchoolId = @SchoolIdValue";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // sql paramaters
                    command.Parameters.AddWithValue("NaamValue", school.Naam);
                    command.Parameters.AddWithValue("SchoolIdValue", school.SchoolId);

                    // open connection
                    con.Open();

                    // execute command
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// delete a school in the database
        /// </summary>
        /// <param name="school">SchoolModel</param>
        /// <returns>rows affected</returns>
        public int Delete(SchoolModel school)
        {
            int rowsAffected = 0;

            // Opstarten connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Opstarten van SqlCommand
                string query = "DELETE School FROM School WHERE SchoolId = @SchoolIdValue; ";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("SchoolIdValue", school.SchoolId);

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
