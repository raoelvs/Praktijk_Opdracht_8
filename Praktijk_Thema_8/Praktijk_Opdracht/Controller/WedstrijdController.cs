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
                        thuis.SpelerId = (int)reader["ThuisId"];
                        thuis.Voornaam = (string)reader["ThuisVoornaam"];
                        thuis.Tussenvoegsel = (string)reader["ThuisTussenvoegsel"];
                        thuis.Achternaam = (string)reader["ThuisAchternaam"];
                        thuis.Groep = (int)reader["ThuisGroep"];
                        thuis.Geboortedatum = (DateTime)reader["ThuisGeboortedatum"];

                        SchoolModel thuisSchool = new SchoolModel();
                        thuisSchool.SchoolId = (int)reader["ThuisSchoolId"];
                        thuisSchool.Naam = (string)reader["ThuisNaam"];

                        SpelerModel uit = new SpelerModel();
                        uit.SpelerId = (int)reader["UitId"];
                        uit.Voornaam = (string)reader["UitVoornaam"];
                        uit.Tussenvoegsel = (string)reader["UitTussenvoegsel"];
                        uit.Achternaam = (string)reader["UitAchternaam"];
                        uit.Groep = (int)reader["UitGroep"];
                        uit.Geboortedatum = (DateTime)reader["UitGeboortedatum"];

                        SchoolModel uitSchool = new SchoolModel();
                        uitSchool.SchoolId = (int)reader["UitSchoolId"];
                        uitSchool.Naam = (string)reader["UitNaam"];

                        SpelerModel winnaar = new SpelerModel();
                    }
                }
            }
            return list;
        }
    }
}
