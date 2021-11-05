using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class ReviewViewModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        [Range(0,5)]
        public decimal Rating { get; set; }
        [MaxLength(300, ErrorMessage = "Miaximum Characters Exceeded ( {1} characters.)")]
        public string Description { get; set; }
        public int PieId { get; set; }
    }
}
