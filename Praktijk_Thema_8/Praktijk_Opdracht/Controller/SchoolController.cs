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

        /// <summary>
        /// This method deletes the school from the database. Gets the information from FrmSpelerDeleteConstraint
        /// </summary>
        /// <param name="school"> this variable has the school that needs to be deleted</param>
        /// <returns> The rows affected </returns>
        public int DeleteSchoolFromSpeler(SpelerModel school)
        {
            int rowsAffected = 0;

            // Opstarten connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Opstarten van SqlCommand
                string query = "DELETE School FROM School JOIN Speler ON Speler.SchoolId = School.SchoolId WHERE Speler.SchoolId = @SchoolIdValue; " +
                    "DELETE FROM Speler WHERE School = @SchoolIdValue; "; /// klopt nog niet (jarno)

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
