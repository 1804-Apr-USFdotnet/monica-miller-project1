using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using WebTests;
//using WebTests.Tests.Controllers;


//namespace WebTests.Tests.Controllers
//{


//    [TestClass]
//        public class RestaurantControllerTest
//        {
//            [TestMethod]
//            public void Index()
//            {
//                // Arrange
//                RestaurantController controller = new RestaurantController();

//            var detailCheck = controller.Details(5) as ViewResult;
//            var actual = detailCheck.Model as Restaurant;

//            Assert.AreEqual("subway", actual.RestaurantName, "Actual result = "actual.RestaurantName);

             
//            }

//            [TestMethod]
//            public void About()
//            {
//                // Arrange
//                RestaurantController controller = new RestaurantController();

//                // Act
//                ViewResult result = controller.About() as ViewResult;

//                // Assert
//                Assert.AreEqual("Your application description page.", result.ViewBag.Message);
//            }

//            [TestMethod]
//            public void Contact()
//            {
//                // Arrange
//                RestaurantController controller = new RestaurantController();

//                // Act
//                ViewResult result = controller.Contact() as ViewResult;

//                // Assert
//                Assert.IsNotNull(result);
//            }
//        }
//    }

