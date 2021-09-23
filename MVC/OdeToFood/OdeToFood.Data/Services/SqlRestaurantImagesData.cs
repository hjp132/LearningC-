using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantImagesData : IRestaurantImagesData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantImagesData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public void Add(RestaurantImages restaurantImages)
        {
            db.RestaurantImages.Add(restaurantImages);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurantImages = db.RestaurantImages.Find(id);
            db.RestaurantImages.Remove(restaurantImages);
            db.SaveChanges();
        }

        public RestaurantImages Get(int id)
        {
            return db.RestaurantImages.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<RestaurantImages> GetByRestaurantID(int restaurantId)
        {
            return from r in db.RestaurantImages
                   where r.RestaurantId.Equals(restaurantId)
                   select r;
        }

        public IEnumerable<RestaurantImages> GetAll()
        {
            return from r in db.RestaurantImages

                   orderby r.RestaurantId
                select r;
        }

        public void Update(RestaurantImages restaurantImages)
        {
            var entry = db.Entry(restaurantImages);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
