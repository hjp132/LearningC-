using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web.Api
{
    public class CuisineTypeController : ApiController
    {

        private readonly ICuisineTypeData db;

        public CuisineTypeController(ICuisineTypeData db)
        {
            this.db = db;
        }

        // GET: CuisineType
        public enum<CuisineType2> Get()
        {
            var model; //CuisineType
            return model
        }
    }
}