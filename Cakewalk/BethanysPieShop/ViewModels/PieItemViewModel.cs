using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BethanysPieShop.ViewModels
{
    public class PiesItemViewModel
    {
        public int PieId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name length can't be more than {1}")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Description can't be logner than {1} characters.")]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "Description can't be logner than {1} characters.")]
        [DisplayName("Long Description")]
        public string LongDescription { get; set; }
        [DisplayName("Allergy Information")]
        public string AllergyInformation { get; set; }
        [Required]
        public decimal Price { get; set; }
        [DisplayName("Image of Pie")]
        [Required(ErrorMessage = "Pie image is required")]
        public byte[] ImageFileToDisplay { get; set; }
        [DisplayName("Is it Pie Of The Week?")]
        public bool IsPieOfTheWeek { get; set; }
        [DisplayName("Is it in stock?")]
        public bool InStock { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public List<SelectListItem> CategoriesList { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }

        public decimal? ReviewScore { get; set; }

        //public string GetImageSrc { get; set; }
    }
}
