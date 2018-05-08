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

        public static void CreateRestaurant(Restaurant restaurant)
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
                    msg.Append(restaurant.Name)
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
                return db.Restaurants.Where(x => x.Name.Contains(key)).Include("Reviews").ToList();
                //return db.Restaurants.Where(x=>x.Name.Contains(key));
            }
        }
        public static IEnumerable<Restaurant> ReadRestaurantsSortByName()
        {
            using (db = new RestaurantReviewsEntities())
            {
                return db.Restaurants.OrderByDescending(x => x.Name).Include("Reviews").ToList();
            }
        }
        public static IEnumerable<Restaurant> ReadRestaurantsSortByRating(int count)
        {
            using (db = new RestaurantReviewsEntities())
            {
                return db.Restaurants.OrderByDescending(x => x.AvgRating).Take(3).Include("Reviews").ToList();
            }
        }


        public static void UpdateReview(Review review)
        {
            using (db = new RestaurantReviewsEntities())
            {
                Logger log = LogManager.GetCurrentClassLogger();
                StringBuilder msg = new StringBuilder();

                Review rev = db.Reviews.Find(review.id);

                rev.rating = review.rating;
                rev.name = review.name;
                rev.text = review.text;
            }
        }

        public static void UpdateRestaurant(Restaurant newRestaurant)
        {
            using (db = new RestaurantReviewsEntities())
            {
                Logger log = LogManager.GetCurrentClassLogger();
                StringBuilder msg = new StringBuilder();

                Restaurant oldRestaurant = db.Restaurants.Find(newRestaurant.ID);

                oldRestaurant.ID = newRestaurant.ID;
                oldRestaurant.Name = newRestaurant.Name;
                oldRestaurant.Address = newRestaurant.Address;
                oldRestaurant.email = newRestaurant.email;
                oldRestaurant.phone = newRestaurant.phone;
                oldRestaurant.AvgRating = newRestaurant.AvgRating;

            }
        }

        public static void CreateReview(Review rev)
        {
            using (db = new RestaurantReviewsEntities())
            {
                Logger log = LogManager.GetCurrentClassLogger();
                StringBuilder msg = new StringBuilder();

                db.Reviews.Add(rev);
            }
        }

        public static void DeleteReviewByID(int id)
        {
            using (db = new RestaurantReviewsEntities())
            {
                Logger log = LogManager.GetCurrentClassLogger();
                StringBuilder msg = new StringBuilder();

                Review rev = db.Reviews.Find(id);

                db.Reviews.Remove(rev);
            }
        }

        public static void DeleteRestaurantByID(int id)
        {
            using (db = new RestaurantReviewsEntities())
            {
                Logger log = LogManager.GetCurrentClassLogger();
                StringBuilder msg = new StringBuilder();

                Restaurant rest = db.Restaurants.Find(id);

                db.Restaurants.Remove(rest);

                ICollection<Review> reviews = db.Reviews.Where(x => x.id == rest.ID).ToList();
                foreach (Review rev in reviews)
                {
                    db.Reviews.Remove(rev);
                }
            }
        }

        public static IEnumerable<Review> GetReviews()
        {
            using (db = new RestaurantReviewsEntities())
            {
                return db.Reviews.ToList();
            }
        }
        public static List<Review> GetAllReviewsForRestaurant(int id)
        {
            var reviewList = GetReviews();
            IEnumerable<Review> reviews = new List<Review>();
            return reviewList.Where(x => x.RestID == id).ToList();

        }
    }
}
    


