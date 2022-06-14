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
    public class SchoolControllerTests
    {
        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            SchoolModel schoolModel = new SchoolModel();
            SchoolController contr = new SchoolController();

            schoolModel.SchoolId = 10;

            // Act
            int rows = contr.Delete(schoolModel);
            int expected = 1;

            //Assert
            Assert.AreEqual(expected, rows);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // Arrange
            SchoolModel schoolModel = new SchoolModel();
            SchoolController contr = new SchoolController();

            schoolModel.Naam = "Jarno";

            // Act
            int rows = contr.Create(schoolModel);
            int expected = 1;
            //Assert
            Assert.AreEqual(expected, rows);
        }
    }
}