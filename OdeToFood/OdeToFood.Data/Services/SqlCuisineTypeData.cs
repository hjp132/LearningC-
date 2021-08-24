using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlCuisineTypeData : ICuisineTypeData
    {
        private readonly OdeToFoodDbContext db;

        public SqlCuisineTypeData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<CuisineType> GetAll()
        {
            return from r in db.CuisineTypes
                   orderby r.Name
                   select r;
        }

        public CuisineType Get(int id)
        {
            return db.CuisineTypes.FirstOrDefault(r => r.Id == id);
        }

        public void Add(CuisineType cuisineType)
        {
            db.CuisineTypes.Add(cuisineType);
            db.SaveChanges();
        }

        public void Update(CuisineType cuisineType)
        {
            var entry = db.Entry(cuisineType);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var cuisineType = db.CuisineTypes.Find(id);
            db.CuisineTypes.Remove(cuisineType);
            db.SaveChanges();
        }

        
    }
}
