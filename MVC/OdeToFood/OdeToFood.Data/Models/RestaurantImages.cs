using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Models
{
    public class RestaurantImages
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public Byte[] ImageFile { get; set; }

        
    }
}
