using Microsoft.VisualStudio.TestTools.UnitTesting;
using Praktijk_Opdracht.Controller;
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
            SpelerModel testModel = SpelerModel();
            SpelerController contr = new SpelerController();

            testModel.SpelerId = 51;
            testModel.Voornaam = "Jarno";
            testModel.Tussenvoegsel = "van";
            testModel.Achternaam = "Overdijk";
            testModel.Geboortedatum = "7-2-1999 00:00:00";
            testModel.Groep = "2";
            testModel.SchoolId = 2;

            // Act
            int rows = contr.Update(testModel);
            int expected = 1;
            //Assert
            Assert.AreEqual(expected, rows);
        }
    }
}