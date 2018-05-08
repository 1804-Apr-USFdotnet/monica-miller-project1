using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantReviews;
using Microsoft.Ajax.Utilities;

namespace RestaurantWeb.Controllers
{
    public class RestaurantsController : Controller
    {
        private RestaurantReviewsEntities db = new RestaurantReviewsEntities();


        // GET: Restaurants

        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }
        [HttpGet]
        public ActionResult Index(string searchString, string sort)
        {
            ViewBag.Search = searchString;
            IEnumerable<Restaurant> rest;
            if (!String.IsNullOrEmpty(searchString))
            {
                rest = (CRUD.FindRestaurantByName(searchString));
            }
            else
            {
                rest = (CRUD.GetRestaurants());
            }

            
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(CRUD.FindRestaurantByName(searchString));
            }
            
            



            ViewBag.NameSortParm = sort == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.TopRatingSortParm = sort == "TopRating" ? "rating_top" : "TopRating";
            ViewBag.Top3RatingSortParm = sort == "Top3Rating" ? "rating_top3" : "Top3Rating";

            

            switch (sort)
            {
                case "name_desc":
                   return View(Sort1.SortDescending((List<Restaurant>)(CRUD.GetRestaurants())));
                    break;
                case "name_asc":
                    return View(Sort1.SortAscending((List<Restaurant>)(CRUD.GetRestaurants())));
                    break;
                case "rating_top":
                    return View(Sort1.SortTopRating((List<Restaurant>)(CRUD.GetRestaurants())));
                    break;
                case "rating_top3":
                    return View(Sort1.SortTop3Rating((List<Restaurant>)(CRUD.GetRestaurants())));
                    break;
                default:
                    break;
            }
            return View(rest);
        }
 
        
       

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,address,phone,email,AvgRating")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,address,phone,email,AvgRating")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
