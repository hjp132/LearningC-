using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Models
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Type of food")]

        public int cuisineTypeID { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Maximum Characters Exceeded ( {1} characters.")]
        [MinLength(4, ErrorMessage = "Must have atleast characters ( {1} characters.")]
        public string Desc { get; set; }

        public List<SelectListItem> CuisineTypesList { get; set; }

        [Display(Name = "Restaurant Images")]
        public List<RestaurantImagesViewModel> RestaurantImages { get; set; }

        public string CuisineText { get; set;  }
    }
}