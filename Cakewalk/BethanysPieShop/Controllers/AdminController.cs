using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace BethanysPieShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPieReviewRepository _reviewRepository;

        public AdminController(IPieRepository pieRepository, ICategoryRepository categoryRepository, IPieReviewRepository reviewRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            _reviewRepository = reviewRepository;
        }

        public IActionResult Index()
        {

            IEnumerable<Pie> pies;
            pies = _pieRepository.AllPies.OrderBy(p => p.PieId);


            return View(new AdminViewModel
            {
                Pies = pies
            });

         

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PiesItemViewModel pie, IFormFile file)
        {
            var model = new Models.Pie()
            {
                Name = pie.Name,
                ShortDescription = pie.ShortDescription,
                LongDescription = pie.LongDescription,
                AllergyInformation = pie.AllergyInformation,
                Price = pie.Price,
                IsPieOfTheWeek = pie.IsPieOfTheWeek,
                InStock = pie.InStock,
                CategoryId = pie.CategoryId
            };

            if (file != null)
            {
                if (file.Length > 0 )
                {
                    byte[] byteImage = null;
                    using (var fs1 = file.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        byteImage = ms1.ToArray();
                    }
                    model.ImageFileToDisplay = byteImage;
                }
            }

            

            if (ModelState.IsValid)
            {
                _pieRepository.Add(model);
                return RedirectToAction("Details", "Pie", new { id = model.PieId });
            }

            return RedirectToAction("Create", "Admin", new { id = model.PieId });
        }

        
        public IActionResult Delete(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {

                return NotFound();
            } else
            {
                _pieRepository.Delete(id);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }

            var model = new PiesItemViewModel()
            {
                PieId = pie.PieId,
                Name = pie.Name,
                ShortDescription = pie.ShortDescription,
                LongDescription = pie.LongDescription,
                AllergyInformation = pie.AllergyInformation,
                Price = pie.Price,
                IsPieOfTheWeek = pie.IsPieOfTheWeek,
                InStock = pie.InStock,
                ImageFileToDisplay = pie.ImageFileToDisplay

            };


            var categories = _categoryRepository.AllCategories;
            model.CategoriesList = categories.Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() })
                .ToList();


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pie pie, IFormFile file)
        {
   

            var model = new PiesItemViewModel()
            {
                Name = pie.Name,
                ShortDescription = pie.ShortDescription,
                LongDescription = pie.LongDescription,
                AllergyInformation = pie.AllergyInformation,
                Price = pie.Price,
                IsPieOfTheWeek = pie.IsPieOfTheWeek,
                InStock = pie.InStock,
                CategoryId = pie.CategoryId
            };

            if (file != null)
            {
                if (file.Length > 0)
                {
                    byte[] byteImage = null;
                    using (var fs1 = file.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        byteImage = ms1.ToArray();
                    }
                    model.ImageFileToDisplay = byteImage;
                }
            }

            if (ModelState.IsValid)
            {
                _pieRepository.Update(pie);
                TempData["Message"] = "You have saved the changes";
                return RedirectToAction("Details", "Pie", new { id = pie.PieId });
            }
            return View();
        }
    }

    
}
