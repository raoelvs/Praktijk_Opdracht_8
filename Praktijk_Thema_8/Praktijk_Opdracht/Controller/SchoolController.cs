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
    class SchoolController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDeVluggehandjes"].ConnectionString;

        public List<SchoolModel> ReadAll()
        {
            List<SchoolModel> schoolList = new List<SchoolModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM School ORDER BY Naam";
                using(SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

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

        public int Create(SchoolModel school)
        {
            int rowsAffected = 0;
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO School(Naam) VALUES(@NaamValue)";
                using(SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("NaamValue", school.Naam);
                    con.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        public int Update(SchoolModel school)
        {
            int rowsAffected = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE School SET Naam = @NaamValue WHERE SchoolId = @SchoolIdValue";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("NaamValue", school.Naam);
                    command.Parameters.AddWithValue("SchoolIdValue", school.SchoolId);
                    con.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="school"> this variable has the school that needs to be deleted</param>
        /// <returns> The rows affected </returns>
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
