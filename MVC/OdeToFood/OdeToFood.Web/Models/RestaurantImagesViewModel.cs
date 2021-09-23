using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Models
{
    public class RestaurantImagesViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public Byte[] ImageFile { get; set; }
    }
}