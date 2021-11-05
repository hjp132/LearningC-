using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string AllergyInformation { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageFileToDisplay { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> CategoriesList { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }

        public decimal ReviewScore { get; set; }
        public string GetImageSrc
        {
            get
            {
                var base64 = Convert.ToBase64String(this.ImageFileToDisplay);
                return string.Format("data:image/gif;base64,{0}", base64);
            }
        }
    }
}
