using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviews;
using System.IO;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string jsonStr = System.IO.File.ReadAllText(@"C:\RestaurantData.json");

            List<Restaurant> obj = Serializer.Serializer.Deserialize<List<Restaurant>>(jsonStr);

            BLRestaurant blRest;
       
            foreach(Restaurant i in obj)
            {
                blRest = Converter.convertRestaurantFromDB(i);
        

                //compare properties of blRest and i
                Assert.AreEqual(i.id, blRest.ID, "ID: \"" + i.id + "\" \"" + blRest.ID + '"');
                Assert.AreEqual(blRest.Address, i.address, "Address: \"" + i.address + "\" \"" + blRest.Address + '"');
                Assert.AreEqual(i.phone, blRest.Phone, "Phone: \"" + i.phone + "\" \"" + blRest.Phone + '"');
                Assert.AreEqual(i.email, blRest.Email, "Email: \"" + i.email + "\" \"" + blRest.Email + '"');
                Assert.AreNotEqual(i.AvgRating, blRest.AvgRating, "AvgRating: \"0" + i.AvgRating + "\" \"0" + blRest.AvgRating + '"');
                Assert.AreNotEqual(i.city, blRest.City, "City: \"" + i.city + "\" \"" + blRest.City + '"');
                Assert.AreNotEqual(i.state, blRest.State, "State: \"" + i.state + "\" \"" + blRest.Address + '"');
                Assert.AreEqual(i.zip, blRest.ZIP, "ZIP: \"" + i.zip + "\" \"" + blRest.ZIP + '"');
            }
        }
    }
}


