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
                ID = dbRestaurant.id,
                Name = dbRestaurant.name,
                Address = dbRestaurant.address,
                Phone = dbRestaurant.phone,
                Email = dbRestaurant.email,
                Reviews = new List<BLReview>()

            };

            foreach (Review rev in dbRestaurant.Review)
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
                review1 = review.review.Substring(0, Math.Min(100, review.review.Length)),
                rating = review.rating,
                name = review.name,
            };

            return result;
        }

        
    }
 
    
}
