using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieReview
    {

        public int id { get; set; }
        public string Title { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int PieId { get; set; }
    }
}
