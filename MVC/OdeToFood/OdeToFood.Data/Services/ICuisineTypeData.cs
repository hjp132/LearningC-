using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public interface ICuisineTypeData
    {
        IEnumerable<CuisineType> GetAll();
        CuisineType Get(int id);
        void Add(CuisineType cuisineType);
        void Update(CuisineType cuisineType);
        void Delete(int id);



    }
}
