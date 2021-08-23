using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name="Type of food")]

        // How would you properly implement each CuisineType from another database?
        public CuisineType cuisineid{  get; set; }

    }
}
