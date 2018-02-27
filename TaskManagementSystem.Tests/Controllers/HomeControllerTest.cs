using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagementSystem;
using TaskManagementSystem.Controllers;
using TaskManagementSystem.Models.CustomClass;

namespace TaskManagementSystem.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTest
    {
        [TestMethod()]
        public void GetLeavesByResoucesTest()
        {
            LeaveController lv = new LeaveController();
            LeaveModel lvModel = new LeaveModel();
            lvModel.ResourceID = 2;
            lv.GetLeavesByResouces(lvModel);
            Assert.Fail();
        }
    }
}

namespace TaskManagementSystem.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
