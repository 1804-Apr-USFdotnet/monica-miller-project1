using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestaurantWeb.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHomeController()
        {
            public void HomeControllerIndex()
            {
                HomeController con = new HomeController();

                var details = con.Details(1) as ViewResult;
                var actual = details.Model;

                Assert.IsNotNull(actual);
            }
        }
    }
}
