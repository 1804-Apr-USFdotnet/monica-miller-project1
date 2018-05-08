//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NLog;
//using RestaurantReviews;

//namespace Client
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            // Functionality and Logging


//            Logger log = LogManager.GetCurrentClassLogger();


//            //Console Application
//            //console.WriteLine();

//            string input = "";
//            string howMuchInfo = "";
//            string ordering = "";


//            List<Restaurant> restaurants = BLRestaurant.GetRestaurant();
//            List<Restaurant> restaurantsTemp = null;

//            while (input != "Exit")
//            {
//                try
//                {
//                    Console.WriteLine();
//                    Console.WriteLine("Type [exit] to exit");
//                    Console.WriteLine("View [all] " + "restaurants" + "Only [Top3]" + "[search] by name");
//                    Console.WriteLine();
//                    Console.WriteLine("<input> ");
//                    input = Console.ReadLine().ToLower();
//                    log.Info(input);
//                    while (input != "all" && input != "top3" && input != "search" && input != "exit")
//                    {
//                        Console.WriteLine($"Response [{input}] is invalid. Select [all], [top3], [search] or [exit]");
//                        Console.Write("<input> ");
//                        input = Console.ReadLine().ToLower();
//                        log.Info(input);
//                    }
//                    switch (input)
//                    {
//                        case "all":
//                            restaurantsTemp = restaurants;
//                            break;
//                        case "top3":
//                            restaurantsTemp = Restaurant.GetTop3(restaurants);
//                            break;
//                        case "search":
//                            restaurantsTemp = Restaurant.SearchByName(restaurants);
//                            Console.WriteLine(restaurantsTemp.Count + " matches:");
//                            break;

//                    }
//                }
//                catch (Exception e)
//                {
//                    log.Error(e, e.StackTrace);
//                }




//            }

//        }
//    }
//}
 
