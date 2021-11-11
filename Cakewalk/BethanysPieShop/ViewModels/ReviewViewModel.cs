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
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Range(0,5)]
        [Required]
        public decimal Rating { get; set; }
        [MaxLength(500, ErrorMessage = "Miaximum Characters Exceeded ( {1} characters.)")]
        [Required]
        public string Description { get; set; }
        public int PieId { get; set; }
    }
}
