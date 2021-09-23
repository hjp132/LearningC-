using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantImagesController : ApiController
    {
        private readonly IRestaurantImagesData db;

        public RestaurantImagesController(IRestaurantImagesData db)
        {
            this.db = db;
        }

        public IEnumerable<RestaurantImages> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
