using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews
{
    public class BLRestaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Hours { get; set; }
        public int AvgRating { get; set; }
        public List<BLReview> Reviews = new List<BLReview>();

        public void addReview(BLReview r)
        {
            Reviews.Add(r);
        }

        public static List<Restaurant> GetRestaurant()
        {
            throw new NotImplementedException();
        }

        public string ToString()
        {
            StringBuilder restaurantString = new StringBuilder();

            restaurantString.Append("Restaurant: " + this.Name + "\nAddress: " + this.Address + "\n\t" + this.City + " " + this.State + ", " + this.Zip);
            restaurantString.Append("\nPhone: " + this.Phone + "\nHours: " + this.Hours);
            return restaurantString.ToString();
            //return $"{Name}, {Ratings}"; //displays name and ratings
        }

        public double CalculateAverageRating()
        {
            double runningTotal = 0.0d;
            double avg = 0.0d;
            foreach (BLReview r in Reviews)
            {
                runningTotal += r.rating;
            }
            avg = runningTotal / Reviews.Count;

            return avg;
        }

    }
}
        