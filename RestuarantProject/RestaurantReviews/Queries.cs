using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews
{
    class Queries
    {
        private readonly string _orderBy;
        public Queries(string orderBy)
        {
            _orderBy = orderBy;
        }
        public List<Restaurant> Query(IEnumerable<Restaurant> restaurants)
        {
            switch (_orderBy.ToLower())
            {
                case "name":
                    return restaurants.OrderBy(x => x.Name).ToList();
                case "rating":
                    return restaurants.OrderBy(x => x.AvgRating).ToList();
                default:
                    return restaurants.OrderBy(x => x.Name).ToList();

              
            }
        }
    }
}
