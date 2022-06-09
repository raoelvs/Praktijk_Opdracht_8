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
    class WedstrijdController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDeVluggehandjes"].ConnectionString;

        public List<WedstrijdModel> ReadAll()
        {
            List<WedstrijdModel> list = new List<WedstrijdModel>();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "";
                using(SqlCommand command = new SqlCommand(query,con))
                {
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read() == true)
                    {
                        WedstrijdModel item = new WedstrijdModel();
                        item.WedstrijdId = (int)reader["WedstrijdId"];
                        item.Starttijd = (DateTime)reader["Starttijd"];
                        item.Eindtijd = (DateTime)reader["Eindtijd"];
                        item.Ronde = (int)reader["Ronde"];

                        ScheidsrechterModel scheidsrechter = new ScheidsrechterModel();

                        SpelerModel thuis = new SpelerModel();

                        SpelerModel uit = new SpelerModel();

                        SpelerModel winnaar = new SpelerModel();
                    }
                }
            }
            return list;
        }
    }
}
