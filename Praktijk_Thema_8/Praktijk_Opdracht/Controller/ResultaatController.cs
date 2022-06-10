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
                string sqlQuery = "SELECT *" +
                    "FROM tbl.Resultaat" +
                    "JOIN Wedstrijd ON Resultaat.WedstrijdId = Wedstrijd.WedstrijdId" +
                    "JOIN Speler ON Resultaat.SpelerId = Speler.SpelerId";

                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        ResultaatModel ResultaatItem = new ResultaatModel();
                        WedstrijdModel WedstrijdItem = new WedstrijdModel();
                        SpelerModel SpelerItem = new SpelerModel();

                    }
                }
            }
        }
    }
}
