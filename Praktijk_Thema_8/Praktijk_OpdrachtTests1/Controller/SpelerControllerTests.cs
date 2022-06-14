using Microsoft.VisualStudio.TestTools.UnitTesting;
using Praktijk_Opdracht.Controller;
using Praktijk_Opdracht.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktijk_Opdracht.Controller.Tests
{
    [TestClass()]
    public class SpelerControllerTests
    {
        [TestMethod()]
        public void UpdateTest()
        {

            // Arrange
            SpelerModel spelerModel = new SpelerModel();
            SchoolModel schoolModel = new SchoolModel();
            SpelerController contr = new SpelerController();

            spelerModel.SpelerId = 1;
            spelerModel.Voornaam = "Jarno";
            spelerModel.Tussenvoegsel = "van";
            spelerModel.Achternaam = "Overdijk";
            spelerModel.Geboortedatum = DateTime.Now;
            spelerModel.Groep = 2;
            schoolModel.SchoolId = 2;

            spelerModel.SchoolId = schoolModel;

            // Act
            int rows = contr.Update(spelerModel);
            int expected = 1;
            //Assert
            Assert.AreEqual(expected, rows);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            SpelerModel spelerModel = new SpelerModel();
            SchoolModel schoolModel = new SchoolModel();
            SpelerController contr = new SpelerController();

            spelerModel.Voornaam = "Jarno";
            spelerModel.Tussenvoegsel = "van";
            spelerModel.Achternaam = "Overdijk";
            spelerModel.Geboortedatum = DateTime.Now;
            spelerModel.Groep = 2;
            schoolModel.SchoolId = 2;

            spelerModel.SchoolId = schoolModel;

            // Act
            int rows = contr.Create(spelerModel);
            int expected = 1;
            //Assert
            Assert.AreEqual(expected, rows);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            SpelerModel spelerModel = new SpelerModel();
            SpelerController contr = new SpelerController();

            spelerModel.SpelerId = 34;

            // Act
            int rows = contr.Delete(spelerModel);
            int expected = 1;

            //Assert
            Assert.AreEqual(expected, rows);
        }
    }
}