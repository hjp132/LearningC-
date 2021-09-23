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

        public int cuisineTypeID{  get; set; }

        [Required]
        [Display(Name = "Restaurant Description")]
        [MaxLength(1000, ErrorMessage = "Maximum Characters Exceeded ( {1} characters.")]
        [MinLength(4, ErrorMessage = "Must have atleast characters ( {1} characters.")]
        public string Desc { get; set; }

        
    }
}
