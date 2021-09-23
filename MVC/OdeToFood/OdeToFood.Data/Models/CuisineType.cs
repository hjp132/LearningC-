using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OdeToFood.Data.Models
{
    public class CuisineType
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Upload File")]
        public string ImagePath { get; set; }
        public  Byte[] ImageFile { get; set; }
    }




}
