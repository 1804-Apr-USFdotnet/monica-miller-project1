using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews
{
    public static class Converter
    {
        public static BLRestaurant
            convertRestaurantFromDB(Restaurant dbRestaurant)
        {
            BLRestaurant result = new BLRestaurant
            {
                ID = dbRestaurant.ID,
                Name = dbRestaurant.Name,
                Address = dbRestaurant.Address,
                Phone = dbRestaurant.phone,
                Email = dbRestaurant.email,
                Reviews = new List<BLReview>()

            };

            foreach (Review rev in dbRestaurant.Reviews)
            {
                result.Reviews.Add(ConvertReviewFromDB(rev));
            }

            return result;

        }
        private static BLReview ConvertReviewFromDB(Review dbReview)
        {
            BLReview result = new BLReview
            {
                id = dbReview.id,
                name = dbReview.name,
                rating = dbReview.rating,
            };
            return result;
        }

        static Review ConvertReviewToDB(BLReview review)
        {
            Review result = new Review
            {
                id = review.id,
                rating = review.rating,
                name = review.name,
                text = review.text,
            };

            return result;
        }
        public static void Addrestaurant(BLRestaurant restaurants)
        {
            var temp = ConvertFromBL(restaurants);
            CRUD.CreateRestaurant(temp);
        }
        public static Restaurant ConvertFromBL(BLRestaurant restaurant)
        {
            Restaurant result = new Restaurant
            {
                ID = restaurant.ID,
                Name = restaurant.Name,
                Address = restaurant.Address,
                phone = restaurant.Phone,
                email = restaurant.Email,
                Reviews = new List<Review>()
            };
            return result;
        }
        public static void UpdateRestaurant(BLRestaurant restaurant)
        {
            CRUD.UpdateRestaurant(ConvertFromBL(restaurant));
        }
        public static void DeleteRestaurantByID(int id)
        {
            CRUD.DeleteRestaurantByID(id);
        }
        public static void CreateRestaurant(BLRestaurant restaurant)
        {
            CRUD.CreateRestaurant(ConvertFromBL(restaurant));
        }

        public static void AddReview(BLReview reviews)
        {
            var temp = ConvertFromBL(reviews);
            CRUD.CreateReview(temp);
        }

        public static Review ConvertFromBL(BLReview review)
        {
            Review result = new Review
            {
                id = review.id,
                name = review.name,
                rating = review.rating,
                text = review.text,
            };
            return result;
        }
    }
}




        


     

        
        
    
 
    

