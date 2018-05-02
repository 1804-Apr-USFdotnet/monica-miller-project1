using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace RestaurantReviews
{
    public static class CRUD
    {
        //Read from database
        static RestaurantReviewsEntities db;
  
        public static void CreateRestuarant(Restaurant restaurant)
        {
            using (db = new RestaurantReviewsEntities())
            {
                Logger log = LogManager.GetCurrentClassLogger();
                StringBuilder msg = new StringBuilder();

                db.Restaurants.Add(restaurant);

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    msg.Append(restaurant.name)
                        .Append("--");

                    foreach (var eve in e.EntityValidationErrors)
                    {
                        msg.Append("Entity")
                            .Append(eve.Entry.Entity.GetType().Name)
                            .Append("in state")
                            .Append(eve.Entry.State)
                            .Append("has validation errors.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            msg.Append("Property")
                                .Append(ve.PropertyName)
                                .Append("Error")
                                .Append(ve.ErrorMessage)
                                .Append("\n");
                        }
                    }
                   
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public static IEnumerable<Restaurant> GetRestaurants()
        {
            using (db = new RestaurantReviewsEntities())
            {
                return db.Restaurants.ToList();
            }


        }
        public static IEnumerable<Restaurant> GetTop3Restaurants()
        {
            using (db = new RestaurantReviewsEntities())
            {
                return db.Restaurants.OrderByDescending(x => x.AvgRating).Take(3).Include("Review").ToList();
            }


        }
        public static IEnumerable<Restaurant> ReadRestaurants()
        {
            using (db = new RestaurantReviewsEntities())
            {
                return db.Restaurants.Include("Review").ToList();
            }
        }
        public static IEnumerable<Restaurant> FindRestaurantByID(int id)
        {
            using (db = new RestaurantReviewsEntities())
            {
                yield return db.Restaurants.Find(id);
            }
        }
        public static IEnumerable<Restaurant> FindRestaurantByName(string key)
        {
            using (db = new RestaurantReviewsEntities())
            {
                return db.Restaurants.Where(x => x.name.Contains(key)).Include("Reviews").ToList();
            }
        }
        public static IEnumerable<Restaurant> ReadRestaurantsSortByName()
        {
            using (db = new RestaurantReviewsEntities())
            {
                return db.Restaurants.OrderByDescending(x => x.name).Include("Reviews").ToList();
            }
        }
        public static IEnumerable<Restaurant> ReadRestaurantsSortByRating(int count)
        {
            using (db = new RestaurantReviewsEntities())
            {
                return db.Restaurants.OrderByDescending(x => x.AvgRating).Take(3).Include("Reviews").ToList();
            }
        }
    }
}
    


