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
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM vWedstrijden ORDER BY Ronde,WedstrijdNummer";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

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

        public WedstrijdModel ReadWhereRoundMatch(int round, int match)
        {
            WedstrijdModel item = new WedstrijdModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM vWedstrijden WHERE Ronde = @RondeValue AND WedstrijdNummer = @WedstrijdNummerValue";
                using(SqlCommand command = new SqlCommand(query,con))
                {
                    command.Parameters.AddWithValue("RondeValue", round);
                    command.Parameters.AddWithValue("WedstrijdNummerValue", match);
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read() == true)
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
    }
}
