using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Models
{
    public class RestaurantViewDetails
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Type of food")]

        public int cuisineTypeID { get; set; }

        public List<SelectListItem> CuisineTypesList { get; set; }

        public string CuisineStringValue { get; set; }
    }
}