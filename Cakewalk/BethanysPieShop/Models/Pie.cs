using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class Pie
    {
        public int PieId { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Name length can't be more than {1}")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Description can't be logner than {1} characters.")]
        public string ShortDescription { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "Description can't be logner than {1} characters.")]
        public string LongDescription { get; set; }
        public string AllergyInformation { get; set; }
        [Required]
        public decimal Price { get; set; }
        public byte[] ImageFileToDisplay { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [ForeignKey("PieId")]
        public ICollection<PieReview> Reviews { get; set; }
        [NotMapped]
        public decimal? ReviewScore
        {
            get
            {
                if (this.Reviews?.Any() == true)
                {
                    decimal reviewScore = this.Reviews.Average(x => x.Rating);
                    return Math.Round(reviewScore, 2, MidpointRounding.ToEven);
                }
                return null;
            }
            set { }
        }
    }
}
