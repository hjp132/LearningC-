using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class CuisineTypeController : ApiController
    {
        private readonly ICuisineTypeData db;

        public CuisineTypeController(ICuisineTypeData db)
        {
            this.db = db;
        }

        public IEnumerable<CuisineType> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
