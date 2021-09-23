using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantImagesData
    {  
        IEnumerable<RestaurantImages> GetAll();
        IEnumerable<RestaurantImages> GetByRestaurantID(int restaurantID);
        RestaurantImages Get(int id);
        void Add(RestaurantImages restaurantImages);
        void Update(RestaurantImages restaurantImages);
        void Delete(int id);


    }
}
