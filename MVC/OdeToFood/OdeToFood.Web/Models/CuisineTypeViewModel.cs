﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Web.Models
{
    public class CuisineTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte[] ImageFileToDisplay { get; set; }
    }
}