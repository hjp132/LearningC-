using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AdminController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {

            var adminViewModel = new AdminViewModel
            {
                AllPies = _pieRepository.AllPies
            };

            return View(adminViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PiesItemViewModel();
            var categories = _categoryRepository.AllCategories;
            model.CategoriesList = categories.Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() })
                .ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreatePie(Pie pie)
        {
            var model = new Pie()
            {
                Name = pie.Name,
                ShortDescription = pie.ShortDescription,
                LongDescription = pie.LongDescription,
                AllergyInformation = pie.AllergyInformation,
                Price = pie.Price,
                ImageUrl = pie.ImageUrl,
                ImageThumbnailUrl = pie.ImageThumbnailUrl,
                IsPieOfTheWeek = pie.IsPieOfTheWeek,
                InStock = pie.InStock,
                CategoryId = pie.CategoryId,
                Category = pie.Category
            };

            if (ModelState.IsValid)
            {
                _pieRepository.Add(pie);
                return RedirectToAction("Index");
            }
            return View();
        }

        
        public IActionResult EditPie(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {

                return NotFound();
            }
                

            return View(pie);
        }
    }
}
